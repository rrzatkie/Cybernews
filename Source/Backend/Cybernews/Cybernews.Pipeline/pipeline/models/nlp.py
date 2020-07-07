import sys, os, traceback
import pickle
from datetime import datetime
from enum import Enum
import multiprocessing as mp


import numpy as np
import pandas as pd
import textacy
from textacy import preprocessing, ke
from textacy.vsm.vectorizers import Vectorizer
import spacy
from nltk.corpus import stopwords
from nltk.stem import SnowballStemmer
from gensim import utils, matutils, models
from gensim.parsing.preprocessing import preprocess_string
from gensim.corpora import Dictionary

from pipeline.helpers.file_helper import file_helper
import concurrent
from math import ceil

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
    def __init__(self, logger, helper):
        self.logger = logger
        self.helper = helper
        self.stop_words = None

        self.df = None
        self.df_result = None
        self.texts = None
        self.stop_words = None

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
        self.gensim_vectorizer_tfidf = None
        self.gensim_w2v_model = None
        self.gensim_docs_vectors_w2v = None

    def stem_words(self, texts):
        self.logger.info('Started steming batch of texts.')

        stemmer = SnowballStemmer('english')
        docs = []
        if(self.stop_words is not None):
            docs = [
                [stemmer.stem(word) for word in utils.tokenize(doc) if word not in self.stop_words]
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

        self.logger.info('Finished steming.')
        
        return docs

    def gensim_trigrams(self, docs, bigram_model=None, trigram_model=None):
        if((trigram_model is None) or (bigram_model is None)):
            bigram_model = models.Phrases(docs)
            docs_bigram = [bigram_model[doc] for doc in docs]
            
            trigram_model = models.Phrases(docs_bigram)
            docs_trigram = [trigram_model[doc] for doc in docs_bigram]

            self.gensim_bigram_model = bigram_model
            self.gensim_trigram_model = trigram_model
        else:
            docs_bigram = [bigram_model[doc] for doc in docs]
            docs_trigram = [trigram_model[doc] for doc in docs_bigram]
            
        return docs_trigram

    def gensim_doc2bow(self, docs,dictionary=None):
        if(dictionary is None):
            dictionary = Dictionary(docs)
            corpus = [dictionary.doc2bow(doc) for doc in docs]

            self.gensim_dictionary = dictionary
            self.gensim_corpus = corpus
        else:
            corpus = [dictionary.doc2bow(doc) for doc in docs]

        return corpus

    def gensim_pipeline_bow(self, texts):
        docs = self.gensim_trigrams(
            self.stem_words_parallel(texts)
        )

        self.gensim_doc2bow(docs)

        self.gensim_docs = docs

        return docs
  
    def gensim_transform_tfidf(self, corpus, dictionary=None, vectorizer=None):
        if((vectorizer is None)):
            vectorizer = models.TfidfModel(
                corpus = corpus,
                dictionary = dictionary
            )
            
            corpus_tfidf = vectorizer[corpus]
            self.gensim_corpus_tfidf = corpus_tfidf
            self.gensim_vectorizer_tfidf = vectorizer
        else:
            corpus_tfidf = vectorizer[corpus]

        return corpus_tfidf
    
    def gensim_transform_w2v(self, w2v_model, corpus_tfidf, dictionary):
        word_vectors = np.array([
            [w2v_model[dictionary.id2token[w_id]]*value for w_id, value in doc_tfidf] 
            for doc_tfidf in corpus_tfidf
        ])

        doc_vectors = [
            np.mean(doc, axis=0)
            for doc in word_vectors
        ]

        self.gensim_docs_vectors_w2v = doc_vectors

        return np.array(doc_vectors)

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

        self.texts=texts
        self.logger.info('Finished preprocessing with textacy.')

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

    def merge_results(self):
        df_result = self.df.reset_index(drop=True)
        
        s1 = pd.Series(name='text_lemmatized_spacy', data=self.spacy_docs)
        s2 = pd.Series(name='text_keywords_spacy', data=self.spacy_keywords)
        # s3 = pd.Series(name='text_stemmed_gensim', data=self.spacy_docs)
        
        df_result = pd.concat([df_result, s1, s2], axis=1)
        
        self.logger.info("Merged results to dataframe.")
        self.df_result = df_result

        return df_result

    def init_spacy(self, model_name='en_core_web_md'):
        self.spacy = spacy.load(model_name)
        for word in self.stop_words:
            self.spacy.vocab[word].is_stop = True
 
    def init_gensim_w2v(self, docs):
        google_w2v_path = '{}/downloaded/GoogleNews-vectors-negative300.bin'.format(self.helper.data_path)

        # Use only pre-trained model without training
        # model = models.KeyedVectors(google_w2v_path, binary=True)
        
        model = models.Word2Vec(size = 300, window=5, min_count=1, workers = mp.cpu_count()-4)
        model.build_vocab(docs)
        model.intersect_word2vec_format(google_w2v_path, lockf=1.0, binary=True)
        model.train(docs, total_examples=len(docs), epochs=5)

        self.gensim_w2v_model = model

        return model

    def load_state(self, mode, helper):
        self.logger.info("Try to load state with mode {}...".format(mode.name))

        class_name = 'nlp'
        
        self.df = helper.load_state(class_name, 'df', file_helper.VarType.DATAFRAME)
        self.texts = helper.load_state(class_name, 'texts', file_helper.VarType.OBJECT)
        self.stop_words = helper.load_state(class_name, 'stop_words', file_helper.VarType.OBJECT, path='{}/downloaded/stopwords'.format(helper.data_path))

        if(mode in [NlpMode.SPACY, NlpMode.ALL]): 
            # TODO: Spacy object has to be pickled in other way
            # self.spacy = helper.load_state(class_name, 'spacy', file_helper.VarType.OBJECT)

            self.spacy_docs = helper.load_state(class_name, 'spacy_docs', file_helper.VarType.OBJECT)
            self.spacy_keywords = helper.load_state(class_name, 'spacy_keywords', file_helper.VarType.OBJECT)
            self.spacy_docs_tfidf = helper.load_state(class_name, 'spacy_docs_tfidf', file_helper.VarType.OBJECT)
        
        if(mode in [NlpMode.GENSIM, NlpMode.ALL]):
            self.gensim_docs = helper.load_state(class_name, 'gensim_docs', file_helper.VarType.OBJECT) 
            self.gensim_corpus = helper.load_state(class_name, 'gensim_corpus', file_helper.VarType.OBJECT) 
            self.gensim_dictionary = helper.load_state(class_name, 'gensim_dictionary', file_helper.VarType.OBJECT) 
            self.gensim_bigram_model = helper.load_state(class_name, 'gensim_bigram_model', file_helper.VarType.OBJECT) 
            self.gensim_trigram_model= helper.load_state(class_name, 'gensim_trigram_model', file_helper.VarType.OBJECT) 
            self.gensim_corpus_tfidf = helper.load_state(class_name, 'gensim_corpus_tfidf', file_helper.VarType.OBJECT) 
            self.gensim_vectorizer_tfidf = helper.load_state(class_name, 'gensim_vectorizer_tfidf', file_helper.VarType.OBJECT) 
            self.gensim_w2v_model = helper.load_state(class_name, 'gensim_w2v_model', file_helper.VarType.OBJECT) 
            self.gensim_docs_vectors_w2v = helper.load_state(class_name, 'gensim_docs_vectors_w2v', file_helper.VarType.OBJECT) 

    def save_state(self, mode, path, helper):
        class_name = 'nlp'

        if self.texts is not None: helper.save_state(class_name, 'texts', self.texts, file_helper.VarType.OBJECT)

        if(mode in [NlpMode.SPACY, NlpMode.ALL]): 
            # TODO: Spacy object has to be pickled in other way
            # if self.spacy is not None: helper.save_state(class_name, 'spacy', self.spacy, file_helper.VarType.OBJECT)
            
            if self.spacy_docs is not None: helper.save_state(class_name, 'spacy_docs', self.spacy_docs, file_helper.VarType.OBJECT)
            if self.spacy_keywords is not None: helper.save_state(class_name, 'spacy_keywords', self.spacy_keywords, file_helper.VarType.OBJECT)
            if self.spacy_docs_tfidf is not None: helper.save_state(class_name, 'spacy_docs_tfidf', self.spacy_docs_tfidf, file_helper.VarType.OBJECT)
        if(mode in [NlpMode.GENSIM, NlpMode.ALL]):
            if self.gensim_docs is not None: helper.save_state(class_name, 'gensim_docs', self.gensim_docs, file_helper.VarType.OBJECT) 
            if self.gensim_corpus is not None: helper.save_state(class_name, 'gensim_corpus', self.gensim_corpus, file_helper.VarType.OBJECT) 
            if self.gensim_dictionary is not None: helper.save_state(class_name, 'gensim_dictionary', self.gensim_dictionary, file_helper.VarType.OBJECT) 
            if self.gensim_bigram_model is not None: helper.save_state(class_name, 'gensim_bigram_model', self.gensim_bigram_model, file_helper.VarType.OBJECT) 
            if self.gensim_trigram_model is not None: helper.save_state(class_name, 'gensim_trigram_model', self.gensim_trigram_model, file_helper.VarType.OBJECT) 
            if self.gensim_corpus_tfidf is not None: helper.save_state(class_name, 'gensim_corpus_tfidf', self.gensim_corpus_tfidf, file_helper.VarType.OBJECT) 
            if self.gensim_vectorizer_tfidf is not None: helper.save_state(class_name, 'gensim_vectorizer_tfidf', self.gensim_vectorizer_tfidf, file_helper.VarType.OBJECT) 
            if self.gensim_w2v_model is not None: helper.save_state(class_name, 'gensim_w2v_model', self.gensim_w2v_model, file_helper.VarType.OBJECT) 
            if self.gensim_docs_vectors_w2v is not None: helper.save_state(class_name, 'gensim_docs_vectors_w2v', self.gensim_docs_vectors_w2v, file_helper.VarType.OBJECT) 

        path = '{}/{}-{}.csv'.format(path, path, datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
        if self.df_result is not None: 
            helper.save_df_to_csv(self.df_result, path)
            helper.save_state(class_name, 'df_result', self.df_result, file_helper.VarType.DATAFRAME)

    def build(self, mode, load_path='03_clean_entries', save_path='04_nlp_pipeline'):
        helper = self.helper

        try:
            self.load_state(mode, helper)
            
            if self.df is None: self.df=helper.load_df_from_csv(load_path)
            if self.texts is None: self.preprocess_parallel(self.df.text_scraped)

            if(mode in [NlpMode.SPACY, NlpMode.ALL]):
                if self.spacy is None: self.init_spacy('en_core_web_md')
                if self.spacy_docs is None: self.spacy_pipeline_bow(self.texts)
                if self.spacy_docs_tfidf is None: self.spacy_transform_tfidf(self.spacy_docs)
            if(mode in [NlpMode.GENSIM, NlpMode.ALL]):
                if self.gensim_corpus is None: self.gensim_pipeline_bow(self.texts)
                if self.gensim_corpus_tfidf is None: self.gensim_transform_tfidf(
                    corpus = self.gensim_corpus,
                    dictionary = self.gensim_dictionary
                )
                if self.gensim_w2v_model is None: self.init_gensim_w2v(self.gensim_docs)
                if self.gensim_docs_vectors_w2v is None: self.gensim_transform_w2v(self.gensim_w2v_model, self.gensim_corpus_tfidf, self.gensim_dictionary)

            if self.df_result is None: self.merge_results()
        except:
            exc_type, exc_value, exc_traceback = sys.exc_info()
            self.logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
            raise

        finally:
            self.logger.info("Saving state with mode {}...".format(mode.name))
            self.save_state(mode, save_path, helper)
        
        return self

    # def update(self, mode, load_path='', save_path=''):