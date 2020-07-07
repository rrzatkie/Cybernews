import sys
import string
import os
import pickle
from datetime import datetime
import multiprocessing as mp
from collections import defaultdict

from gensim import corpora
from gensim import models
import cufflinks as cf
import plotly.offline as py
import pandas as pd
from gensim.corpora.dictionary import Dictionary

from .nlp import NlpMode
from pipeline.helpers.file_helper import file_helper

class topics:
    def __init__(self, logger):
        self.logger = logger
        self.seed = 100
        self.df = None
        self.df_result = None

        self.lda_spacy = None
        self.lda_gensim = None
        self.lda_categories_spacy=None
        self.lda_categories_gensim=None

        self.gensim_corpus = None
        self.gensim_dictionary = None
        
        self.spacy_docs = None
        self.spacy_corpus = None
        self.spacy_dictionary = None

        cf.go_offline()
        cf.set_config_file(offline=True, world_readable=True)

    def lda(self, df, corpus, dictionary, num_topics, seed, mode):
        self.logger.info("Building LDA model for {} topics".format(num_topics))
        lda_model = models.ldamulticore.LdaMulticore(
            corpus=corpus,
            id2word=dictionary,
            num_topics=num_topics, 
            random_state=seed,
            workers=mp.cpu_count()
        )

        categories_lda = []
        for doc in corpus:
            categories_lda.append([cat[0] for cat in lda_model.get_document_topics(doc, minimum_probability=0.333)])
        df['lda_category_{}'.format(mode.name)] = categories_lda
        self.logger.info("Copied LDA categories.")

        if(mode == NlpMode.SPACY):
            self.lda_spacy = lda_model
        elif(mode == NlpMode.GENSIM):
            self.lda_gensim = lda_model
        self.logger.info("Finished building LDA model")
        return lda_model

    def plot(self, lda, df, path, mode):
        path = 'plots/{}-{}.html'.format(path, mode.name)

        title = 'Number of documents per ORIGINAL category'
        fig_histogram_original = df['category_slug'].sort_values(ascending=True).iplot(
            title=title,
            asFigure=True,
            kind="histogram"
        )

        title = 'Number of documents per LDA category'        
        lda_hist_values = {}
        for topic_id in range(lda.num_topics):
            lda_hist_values[topic_id] = 0

        for id,row in df.iterrows():
            for topic_id in row['lda_category_{}'.format(mode.name)]:
                lda_hist_values[topic_id] += 1
        
        df_lda = pd.DataFrame(columns=['CAT_ID', 'COUNT'])
        df_lda.CAT_ID = list(lda_hist_values.keys())
        df_lda.COUNT = list(lda_hist_values.values())

        fig_histogram_lda = df_lda['COUNT'].sort_values(ascending=True).iplot(
            kind='bar', 
            yTitle='Count',
            linecolor='black', 
            opacity=0.8,
            title=title,
            xTitle='Category ID',
            asFigure=True
        )

        with open(path, 'w') as f:
            f.write(fig_histogram_original.to_html(full_html=False, include_plotlyjs='cdn'))
            f.write(fig_histogram_lda.to_html(full_html=False, include_plotlyjs='cdn'))

        lda_categories = df['lda_category_{}'.format(mode.name)]
        if(mode == NlpMode.SPACY):
            self.lda_categories_spacy = lda_categories
        elif(mode == NlpMode.GENSIM):
            self.lda_categories_gensim = lda_categories

        df = df.drop(columns=['lda_category_{}'.format(mode.name)])
        self.df = df
            
    def merge_results(self, df, mode):
        df_result = df.copy()
        
        if(mode == NlpMode.SPACY):
            s1 = pd.Series(name='lda_categories_spacy', data=self.lda_categories_spacy)
        elif(mode == NlpMode.GENSIM):
            s1 = pd.Series(name='lda_categories_gensim', data=self.lda_categories_gensim)

        df_result = pd.concat([df_result, s1], axis=1)
        self.df_result= df_result

        self.logger.info("Merged results to dataframe.")
        
        return df_result

    def load_state(self):
        helper = file_helper(self.logger)
        class_name = 'topics'

        self.df = helper.load_state(class_name, 'df', file_helper.VarType.DATAFRAME)
        self.lda_gensim = helper.load_state(class_name, 'lda_gensim', file_helper.VarType.OBJECT)
        self.lda_spacy = helper.load_state(class_name, 'lda_spacy', file_helper.VarType.OBJECT)
        self.lda_categories_gensim = helper.load_state(class_name, 'lda_categories_gensim', file_helper.VarType.OBJECT)
        self.lda_categories_spacy = helper.load_state(class_name, 'lda_categories_spacy', file_helper.VarType.OBJECT)
        self.spacy_corpus = helper.load_state(class_name, 'spacy_corpus', file_helper.VarType.OBJECT)
        self.spacy_dictionary = helper.load_state(class_name, 'spacy_dictionary', file_helper.VarType.OBJECT)

        class_name = 'nlp'
        self.spacy_docs = helper.load_state(class_name, 'spacy_docs', file_helper.VarType.OBJECT)
        self.gensim_corpus = helper.load_state(class_name, 'gensim_corpus', file_helper.VarType.OBJECT)
        self.gensim_dictionary = helper.load_state(class_name, 'gensim_dictionary', file_helper.VarType.OBJECT)

    def save_state(self, path):
        helper = file_helper(self.logger)
        class_name = 'topics'

        if self.df is not None: helper.save_state(class_name, 'df', self.df, file_helper.VarType.DATAFRAME)
        if self.lda_gensim is not None: helper.save_state(class_name, 'lda_gensim', self.lda_gensim, file_helper.VarType.OBJECT)
        if self.lda_spacy is not None: helper.save_state(class_name, 'lda_spacy', self.lda_spacy, file_helper.VarType.OBJECT)
        if self.lda_categories_gensim is not None: helper.save_state(class_name, 'lda_categories_gensim', self.lda_categories_gensim, file_helper.VarType.OBJECT)
        if self.lda_categories_spacy is not None: helper.save_state(class_name, 'lda_categories_spacy', self.lda_categories_spacy, file_helper.VarType.OBJECT)
        if self.spacy_corpus is not None: helper.save_state(class_name, 'spacy_corpus', self.spacy_corpus, file_helper.VarType.OBJECT)
        if self.spacy_dictionary is not None: helper.save_state(class_name, 'spacy_dictionary', self.spacy_dictionary, file_helper.VarType.OBJECT)


        path = '{}/{}-{}.csv'.format(path, path, datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
        if self.df_result is not None: 
            helper.save_df_to_csv(self.df_result, path)
            helper.save_state(class_name, 'df_result', self.df_result, file_helper.VarType.DATAFRAME)

    def build(self, mode=NlpMode.SPACY, load_path='04_nlp_pipeline', save_path='05_topic_modeling'):
        helper = file_helper(self.logger)
        
        try:
            self.load_state()

            if self.df is None: self.df=helper.load_df_from_csv(load_path)
             
            if mode==NlpMode.SPACY:
                if self.spacy_dictionary is None: self.spacy_dictionary=dictionary = Dictionary(self.spacy_docs)
                if self.spacy_corpus is None: self.spacy_corpus = [dictionary.doc2bow(doc) for doc in self.spacy_docs]
                if self.lda_spacy is None: 
                    self.plot(
                        self.lda(
                            self.df, self.spacy_corpus, self.spacy_dictionary,
                            num_topics=16, mode=mode, seed=self.seed
                        ), 
                        self.df,
                        save_path,
                        mode
                    )
            elif mode==NlpMode.GENSIM:
                if self.lda_gensim is None:
                    self.plot(
                        self.lda(
                            self.df, self.gensim_corpus, self.gensim_dictionary,
                            num_topics=16, mode=mode, seed=self.seed
                        ), 
                        self.df,
                        save_path,
                        mode
                    )
            self.merge_results(self.df, mode)
        except :
            exc_type, exc_value, exc_traceback = sys.exc_info()
            self.logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
            raise

        finally:
            self.logger.info("Saving state.")
            self.save_state(save_path)
        
        return self