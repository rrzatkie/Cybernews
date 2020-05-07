import sys
from textacy import preprocessing
from gensim import utils
from nltk.stem import SnowballStemmer
from datetime import datetime
import concurrent
import multiprocessing as mp

import cufflinks as cf
import plotly.offline as py
import pandas as pd

from shared.file_helper import file_helper
from math import ceil, floor

class cleaner:
    def __init__(self, logger):
        self.logger = logger
        self.df = None

        self.texts = None
        self.stopwords = None
        self.df_result = None
        self.docs = None

        cf.go_offline()
        cf.set_config_file(offline=True, world_readable=True)

    def chunks(self, lst, n_chunks):
        n = ceil(len(lst)/n_chunks)
        """Yield successive n-sized chunks from lst."""
        for i in range(0, len(lst), n):
            yield lst[i:i + n]
    
    def textacy_preprocess(self, texts):
        self.logger.info('Start preprocessing with textacy...')

        texts = list(map(preprocessing.normalize.normalize_quotation_marks, texts))
        self.logger.info('Nomalized qutoation marks.')
        
        texts = list(map(preprocessing.normalize.normalize_whitespace, texts))
        self.logger.info('Nomalized whitespaces.')
        
        texts = [text.replace('\n', ' ') for text in texts]
        self.logger.info('Normalized \\n symbols.')
        
        texts = list(map(preprocessing.normalize.normalize_unicode, texts))
        self.logger.info('Nomalized unicode charatcters.')
        
        texts = list(map(preprocessing.replace.replace_phone_numbers, texts))
        self.logger.info('Nomalized phone numbers.')
        
        texts = list(map(preprocessing.replace.replace_emails, texts))
        self.logger.info('Nomalized email addresses.')

        self.logger.info('Finished batch preprocessing with textacy.')

        return texts

    def preprocess_parallel(self, texts):
        num_cores = mp.cpu_count()

        texts_chunks = self.chunks(texts, num_cores)
        texts_result = []
        with concurrent.futures.ThreadPoolExecutor(max_workers=num_cores) as executor:
            [texts_result.extend(chunk) for chunk in executor.map(self.textacy_preprocess, texts_chunks)]
        
        self.texts=texts_result
        self.logger.info('Finished preprocessing.')

        return texts_result

    def stem_words(self, texts):
        self.logger.info('Started steming batch of texts.')

        stemmer = SnowballStemmer('english')
        docs = []
        if(self.stopwords is not None):
            docs = [
                [stemmer.stem(word) for word in utils.tokenize(doc) if word not in self.stopwords]
                for doc in texts
            ]
        
        self.logger.info('Finished steming batch of texts.')

        return docs

    def stem_words_parallel(self, texts):
        self.logger.info('Start steming texts...')
        num_cores = mp.cpu_count()

        texts_chunks = self.chunks(texts, num_cores)
        docs = []
        with concurrent.futures.ThreadPoolExecutor(max_workers=num_cores) as executor:
            [docs.extend(chunk) for chunk in executor.map(self.stem_words, texts_chunks)]

        self.docs = docs
        self.df['text_stemmed'] = docs
        self.logger.info('Finished steming.')
        
        return docs

    def clean_basic(self, df, min_words, max_words):
        self.logger.info("Cleaning articles that has less than {} and more than {} words.".format(min_words, max_words))

        df = df[df.text_stemmed.str.len() >= min_words ]
        df = df[df.text_stemmed.str.len() <= max_words ]

        self.logger.info("Finished. {} articles remained.".format(df.shape[0]))
        self.df = df

        return df

    def clean_cyware(self, df):
        self.logger.info("Cleaning cyware entries")

        df = df[df.text_scraped.isna()==False]
        df = df[df.category_id.isna()==False]
        df = df[df.category_slug.isna()==False]

        df = df.drop_duplicates(subset=['text_scraped'], keep='first')
        df = df.drop_duplicates(subset=['web_sp_link'], keep='first')

        self.logger.info("Finished. {} articles remained.".format(df.shape[0]))
        self.df = df

        return df

    def plot(self, df, path):
        path = 'plots/{}.html'.format(path)

        df['words_count'] = df.text_stemmed.str.len()

        fig_histogram = df.words_count.sort_values(ascending=True).iplot(asFigure=True, kind="histogram")

        with open(path, 'w') as f:
            f.write(fig_histogram.to_html(full_html=False, include_plotlyjs='cdn'))

    def merge_results(self, df):
        df_result = df.copy().reset_index(drop=True)
        
        s1 = pd.Series(name='text_stemmed', data=[" ".join(doc) for doc in self.df.text_stemmed.values])
        
        df_result = pd.concat([df_result, s1], axis=1)
        df = df.drop(columns=['text_stemmed'])

        self.logger.info("Merged results to dataframe.")
        self.df_result = df_result
        self.df = df

        return df_result

    def load_state(self):
        self.logger.info("Try to load state...")
        helper = file_helper(self.logger)
        class_name = 'cleaner'
        
        self.df = helper.load_state(class_name, 'df', file_helper.VarType.DATAFRAME)
        self.texts = helper.load_state(class_name, 'texts', file_helper.VarType.OBJECT)
        self.docs = helper.load_state(class_name, 'docs', file_helper.VarType.OBJECT)
        self.stopwords = helper.load_state(class_name, 'stopwords', file_helper.VarType.OBJECT, path='data/downloaded/stopwords')
 
    def save_state(self, path):
        helper = file_helper(self.logger)
        class_name = 'cleaner'

        if self.df is not None: helper.save_state(class_name, 'df', self.df, file_helper.VarType.OBJECT)
        if self.texts is not None: helper.save_state(class_name, 'texts', self.texts, file_helper.VarType.OBJECT)
        if self.docs is not None: helper.save_state(class_name, 'docs', self.docs, file_helper.VarType.OBJECT)

        path = 'data/{}/{}-{}.csv'.format(path, path, datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
        if self.df_result is not None: 
            helper.save_df_to_csv(self.df_result, path)
            helper.save_state(class_name, 'df_result', self.df_result, file_helper.VarType.DATAFRAME)

    def build(self, load_path='02_scrap_articles', save_path='03_clean_entries'):
        helper = file_helper(self.logger)
        
        try:
            self.load_state()

            if self.df is None: 
                self.df=helper.load_df_from_csv('data/{}'.format(load_path))
                self.clean_cyware(self.df) 
            
            if self.texts is None: self.preprocess_parallel(self.df.text_scraped)
            if self.docs is None: self.stem_words_parallel(self.texts)
            
            self.plot(self.df, save_path)
            self.clean_basic(self.df, 200, 1500)

            if self.df_result is None: self.merge_results()
        except:
            exc_type, exc_value, exc_traceback = sys.exc_info()
            self.logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
            raise
        finally:
            self.logger.info("Saving state...")
            self.save_state(save_path)

        return self