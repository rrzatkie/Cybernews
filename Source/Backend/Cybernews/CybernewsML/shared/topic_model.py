# gensim imports
from collections import defaultdict
from gensim import corpora
from gensim import models

from shared.file_helper import file_helper

import pandas as pd
import string
import os
import pickle

class topic_model:
    def __init__(self, logger):
        self.logger = logger
        self.corpus = None
        self.df = None
        self.dictionary = None
        self.tfidf = None
        self.corpus_tfidf = None
        self.lda_model = None
        self.texts = None
        

    def load_df(self, path):
        pickle_path = 'pickles/lda/df.pickle'
        
        if(not os.path.exists(pickle_path)):
            self.logger.debug("'{}' does not exist, loading from {}.".format(pickle_path, path))
            helper = file_helper(path)
            f = open(helper.get_newest_file(), 'r', encoding="utf-8")
            self.df = pd.read_csv(f, index_col = 0, converters = {
                'text_scraped_words': lambda x: x[1:-1].replace("'", "").split(', '),
                'text_lemmatized': lambda x: x[1:-1].replace("'", "").split(', ') 
            })

            self.df.to_pickle(pickle_path)
        else:
            self.logger.debug("Loading from {}".format(pickle_path))
            self.df = pd.read_pickle(pickle_path)

    def preprocess(self):
        pickle_path = 'pickles/lda/texts.pickle'
        if(not os.path.exists(pickle_path)):
            self.logger.debug("'{}' does not exist, building new one.".format(pickle_path))
            self.texts = self.df.text_lemmatized.values 

            # remove words that appear only once
            frequency = defaultdict(int)
            for text in self.texts:
                for token in text:
                    frequency[token] += 1

            punctns = list(string.punctuation)
            punctns.append('”')
            self.texts = [
                [token for token in text if (frequency[token] > 1) & (token not in punctns)]
                for text in self.texts
            ]
            with open(pickle_path, 'wb') as f:
                pickle.dump(self.texts, f)
        else:
            self.logger.debug("Loading from {}".format(pickle_path))
            with open(pickle_path, 'rb') as f:
                self.texts = pickle.load(f)

    def build_tfidf_model(self):
        self.dictionary = corpora.Dictionary(self.texts)

        pickle_path = 'pickles/lda/corpus.pickle'
        if(not os.path.exists(pickle_path)):
            self.logger.debug("'{}' does not exist, building new one.".format(pickle_path))
            # Tranform to frequency matrix
            self.corpus = [self.dictionary.doc2bow(text) for text in self.texts]
            with open(pickle_path, 'wb') as f:
                pickle.dump(self.corpus, f)
        else:
            self.logger.debug("Loading from {}".format(pickle_path))
            with open(pickle_path, 'rb') as f:
                self.corpus = pickle.load(f)

        pickle_path = 'pickles/lda/tfidf_model.pickle'
        if(not os.path.exists(pickle_path)):
            # Tranform to tf-idf matrix
            self.tfidf = models.TfidfModel(self.corpus)
            self.tfidf.save(pickle_path)
        else:
            self.tfidf = models.TfidfModel.load(pickle_path)

        self.corpus_tfidf = self.tfidf[self.corpus]

    def lda(self):
        pickle_path = 'pickles/lda/lda_model.pickle'
        if(not os.path.exists(pickle_path)):
            self.logger.debug("'{}' does not exist, building new one.".format(pickle_path))
            #Create Latent Dirchlet Allocation model from tf-idf corpus
            self.lda_model = models.ldamulticore.LdaMulticore(
                corpus=self.corpus,
                id2word=self.dictionary,
                num_topics=10, 
                random_state=100,
                per_word_topics=True,
                workers=4
            )
            self.lda_model.save(pickle_path)
        else:
            self.logger.debug("Loading from {}".format(pickle_path))
            self.lda_model = models.LdaModel.load(pickle_path)

        
    def build(self, full=True):
        self.load_df('data/after-nlp-pipeline')
        self.preprocess()
        self.build_tfidf_model()
        self.lda()
        return self

if __name__ == 'main':
    helper = topic_model()
    helper.build()