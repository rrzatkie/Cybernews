import sys, os, traceback
import pickle
from datetime import datetime
from enum import Enum

import pandas as pd
import multiprocessing as mp
import textacy
from textacy import preprocessing, ke
from textacy.vsm.vectorizers import Vectorizer
import spacy
from nltk.corpus import stopwords
from nltk.stem import SnowballStemmer
from gensim import utils, models
from gensim.parsing.preprocessing import preprocess_string
from gensim.corpora import Dictionary


from shared.file_helper import file_helper

class NlpMode(Enum):
        ALL = 1
        SPACY = 2
        GENSIM = 3

class gensim_corpus:
    def __init__(self, path):
        self.path = path

    def __iter__(self):
        for line in open(self.path):
            yield utils.simple_preprocess(line)

class nlp:
    def __init__(self, logger):
        self.logger = logger
        self.df = None
        self.df_result = None
        
        self.texts = None

        self.spacy = None
        self.spacy_docs = None
        self.spacy_keywords = None
        self.spacy_docs_tfidf = None

        self.gensim_docs = None
        self.gensim_corpus = None
        self.gensim_dictionary = None
        self.gensim_bigram_model = None
        self.gensim_trigram_model= None
        self.gensim_corpus_tfidf = None
        self.gensim_w2v_model = None

    def gensim_pipeline_bow(self, texts):
        stemmer = SnowballStemmer('english')

        docs = [
            [stemmer.stem(word) for word in utils.tokenize(doc)]
            for doc in texts
        ]
        bigram_model = models.Phrases(docs)
        docs_bigram = [bigram_model[doc] for doc in docs]
        
        trigram_model = models.Phrases(docs_bigram)
        docs_trigram = [trigram_model[doc] for doc in docs_bigram]

        docs = docs_trigram
        
        dictionary = Dictionary(docs)
        corpus = [dictionary.doc2bow(doc) for doc in docs]

        self.gensim_docs = docs
        self.gensim_bigram_model = bigram_model
        self.gensim_trigram_mdoel = trigram_model
        self.gensim_dictionary = dictionary
        self.gensim_corpus = corpus

        return corpus, dictionary
  
    def gensim_transform_tfidf(self, corpus, dictionary):
        vectorizer = models.TfidfModel(
            corpus = corpus,
            dictionary = dictionary
        )
        
        corpus_tfidf = vectorizer[corpus]
        self.gensim_corpus_tfidf = corpus_tfidf

        return corpus_tfidf

    def spacy_pipeline_bow(self, texts):
        docs = []
        docs_keywords = []

        POS_ALLOWED = ['NOUN', 'VERB', 'ADJ', 'ADV']

        for doc in self.spacy.pipe(
            texts,
            batch_size = 50, 
            n_threads = mp.cpu_count()-4
        ):
            cve_pattern = [
                {"LOWER": "cve"},
                {"IS_SPACE": True, "OP": "?"},
                {"IS_DIGIT": True},
                {"IS_SPACE": True, "OP": "?"},
                {"IS_DIGIT": True}
            ]
            self.logger.debug("Started processing article no. {} - : [{}...]".format(len(docs), doc.text[0:20].encode("utf-8")))
            
            two_grams = [ngram.text for ngram in textacy.extract.ngrams(doc, 2, include_pos=POS_ALLOWED)]
            
            three_grams = [ngram.text for ngram in textacy.extract.ngrams(doc, 3, include_pos=POS_ALLOWED)]

            cve_list = ["({}, {})".format(cve.text.replace(' ', '-'), '1') for cve in textacy.extract.matches(doc, patterns=cve_pattern)]

            words = [token.lemma_ for token in textacy.extract.words(doc, filter_nums=True, include_pos=POS_ALLOWED) if token.is_stop==False]
            words.extend(two_grams)
            words.extend(three_grams)
            docs.append(words)

            keywords = ["({}, {})".format(term[0], term[1]) for term in ke.sgrank(doc, window_size=10, ngrams=(1,2,3), normalize='lemma', topn=0.1, include_pos=['ADJ', 'NOUN', 'PROPN'])]
            keywords.extend(cve_list)
            docs_keywords.append(keywords)

        self.spacy_docs = docs
        self.spacy_keywords = docs_keywords
        self.logger.info("Finished processing articles.")

        return docs, docs_keywords
  
    def spacy_transform_tfidf(self, docs):
        vectorizer = Vectorizer(
            apply_idf=True,
            norm="l2",
            min_df=3, 
            max_df=0.95
        )
        
        docs_tfidf = vectorizer.fit_transform(docs)
        self.spacy_docs_tfidf = docs_tfidf

        return docs_tfidf

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

        self.texts=texts
        self.logger.info('Finished preprocessing with textacy.')

        return texts

    def load_df(self, path):
        pickle_path = 'pickles/nlp/df.pickle'
        
        if(not os.path.exists(pickle_path)):
            self.logger.debug("'{}' does not exist, loading from {}.".format(pickle_path, path))
            helper = file_helper(path)
            f = open(helper.get_newest_file(), 'r', encoding="utf-8")
            self.df = pd.read_csv(f, index_col = 0, converters = {
                'text_scraped_words': lambda x: x[1:-1].replace("'", "").split(', ')
            })

            self.df.to_pickle(pickle_path)
        else:
            self.logger.debug("loading from {}".format(pickle_path))
            self.df = pd.read_pickle(pickle_path)

    def save_results(self):
        df_result = self.df.reset_index(drop=True)
        
        s1 = pd.Series(name='text_lemmatized_spacy', data=self.spacy_docs)
        s2 = pd.Series(name='text_keywords_spacy', data=self.spacy_keywords)
        s3 = pd.Series(name='text_stemmed_gensim', data=self.spacy_docs)
        
        df_result = pd.concat([df_result, s1, s2, s3], axis=1)
        
        self.logger.info("Merged results to dataframe.")
        self.df_result = df_result

        return df_result

    def init_spacy(self, model_name='en_core_web_md'):
        self.spacy = spacy.load(model_name)
        nltk_stopwords = stopwords.words('english')
        for word in nltk_stopwords:
            self.spacy.vocab[word].is_stop = True
 
    def init_gensim_w2v(self, docs):
        gensim_texts_path = 'pickles/nlp/gensim_texts.txt'
        google_w2v_path = 'data/downloaded/GoogleNews-vectors-negative300.bin'

        # Use only pre-trained model without training
        # model = models.KeyedVectors(google_w2v_path, binary=True)
        
        model = models.Word2Vec(size = 300, window=5, min_count=1, workers = mp.cpu_count()-4)
        model.build_vocab(docs)
        model.intersect_word2vec_format(google_w2v_path, lockf=1.0, binary=True)
        model.train(docs, total_examples=len(docs), epochs=5)

        self.gensim_w2v_model = model

        return model

    def gensim_transform_w2v(self, model, docs, docs_tfidf):
        pass

    def load_state(self, mode):
        helper = file_helper(self.logger)
        class_name = 'nlp'
        
        self.df = helper.load_state(class_name, 'df', file_helper.VarType.DATAFRAME)
        self.texts = helper.load_state(class_name, 'texts', file_helper.VarType.OBJECT)

        if(mode in [NlpMode.SPACY, NlpMode.ALL]): 
            # Spacy object has to be pickled in other way
            # self.spacy = helper.load_state(class_name, 'spacy', file_helper.VarType.OBJECT)

            self.spacy_docs = helper.load_state(class_name, 'spacy_docs', file_helper.VarType.OBJECT)
            self.spacy_keywords = helper.load_state(class_name, 'spacy_keywords', file_helper.VarType.OBJECT)
            self.spacy_docs_tfidf = helper.load_state(class_name, 'spacy_docs_tfidf', file_helper.VarType.OBJECT)
        
        if(mode in [NlpMode.GENSIM, NlpMode.ALL]):
            self.gensim_docs = helper.load_state(class_name, 'gensim_docs', file_helper.VarType.OBJECT) 
            self.gensim_corpus = helper.load_state(class_name, 'gensim_corpus', file_helper.VarType.OBJECT) 
            self.gensim_dictionary = helper.load_state(class_name, 'gensim_dictionary', file_helper.VarType.OBJECT) 
            self.gensim_bigram_model = helper.load_state(class_name, 'gensim_bigram_model', file_helper.VarType.OBJECT) 
            self.gensim_trigram_mdoel= helper.load_state(class_name, 'gensim_trigram_model', file_helper.VarType.OBJECT) 
            self.gensim_corpus_tfidf = helper.load_state(class_name, 'gensim_corpus_tfidf', file_helper.VarType.OBJECT) 
            self.gensim_w2v_model = helper.load_state(class_name, 'gensim_w2v_model', file_helper.VarType.OBJECT) 

    def save_state(self, mode):
        helper = file_helper(self.logger)
        class_name = 'nlp'

        if(mode in [NlpMode.SPACY, NlpMode.ALL]): 
            # Spacy object has to be pickled in other way
            # if self.spacy is not None: helper.save_state(class_name, 'spacy', self.spacy, file_helper.VarType.OBJECT)
            
            if self.spacy_docs is not None: helper.save_state(class_name, 'spacy_docs', self.spacy_docs, file_helper.VarType.OBJECT)
            if self.spacy_keywords is not None: helper.save_state(class_name, 'spacy_keywords', self.spacy_keywords, file_helper.VarType.OBJECT)
            if self.spacy_docs_tfidf is not None: helper.save_state(class_name, 'spacy_docs_tfidf', self.spacy_docs_tfidf, file_helper.VarType.OBJECT)
        if(mode in [NlpMode.GENSIM, NlpMode.ALL]):
            if self.gensim_docs is not None: helper.save_state(class_name, 'gensim_docs', self.gensim_docs, file_helper.VarType.OBJECT) 
            if self.gensim_corpus is not None: helper.save_state(class_name, 'gensim_corpus', self.gensim_corpus, file_helper.VarType.OBJECT) 
            if self.gensim_dictionary is not None: helper.save_state(class_name, 'gensim_dictionary', self.gensim_dictionary, file_helper.VarType.OBJECT) 
            if self.gensim_bigram_model is not None: helper.save_state(class_name, 'gensim_bigram_model', self.gensim_bigram_model, file_helper.VarType.OBJECT) 
            if self.gensim_trigram_model is not None: helper.save_state(class_name, 'gensim_trigram_model', self.gensim_trigram_model.file_helper.VarType.OBJECT) 
            if self.gensim_corpus_tfidf is not None: helper.save_state(class_name, 'gensim_corpus_tfidf', self.gensim_corpus_tfidf, file_helper.VarType.OBJECT) 
            if self.gensim_w2v_model is not None: helper.save_state(class_name, 'gensim_w2v_model', self.gensim_w2v_model, file_helper.VarType.OBJECT) 

        path = 'data/after-nlp-pipeline/after-nlp-pipeline-{}.csv'.format(datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
        if self.spacy is not None: helper.save_df_to_csv(self.df_result, path)

    def build(self, mode, path='data/after-cleaning'):
        helper = file_helper(self.logger)

        try:
            self.logger.info("Try to load state with mode {}...".format(mode.name))
            self.load_state(mode)
            
            if self.df is None: self.df=helper.load_df_from_csv(path)
            if self.texts is None: self.textacy_preprocess(self.df.text_scraped)

            if(mode in [NlpMode.SPACY, NlpMode.ALL]):
                if self.spacy is None: self.init_spacy('en_core_web_md')
                if self.spacy_docs is None: self.spacy_pipeline_bow(self.texts[0:2])
                if self.spacy_docs_tfidf is None: self.spacy_transform_tfidf(self.spacy_docs)
            if(mode in [NlpMode.GENSIM, NlpMode.ALL]):
                if self.gensim_corpus is None: self.gensim_pipeline_bow(self.texts)
                if self.gensim_corpus_tfidf is None: self.gensim_transform_tfidf(self.gensim_corpus)
                if self.gensim_w2v_model is None: self.init_gensim_w2v(self.gensim_docs)

            if self.df_result is None: self.save_results()
        except :
            exc_type, exc_value, exc_traceback = sys.exc_info()
            self.logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
            raise

        finally:
            self.logger.info("Saving state with mode {}...".format(mode.name))
            self.save_state(mode)
        
        return self

if __name__=='__main__':
    helper = nlp()
    helper.build(NlpMode.ALL)