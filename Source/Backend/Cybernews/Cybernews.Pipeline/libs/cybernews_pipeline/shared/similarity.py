from .file_helper import file_helper
import sys
from itertools import combinations, repeat
from scipy.special import comb

from gensim.similarities.termsim import SparseTermSimilarityMatrix
from gensim.similarities.docsim import SoftCosineSimilarity
from gensim.models.keyedvectors import WordEmbeddingSimilarityIndex
from joblib._multiprocessing_helpers import mp
import concurrent
from math import ceil

class similarity:
    def __init__(self, logger, helper):
        self.logger = logger
        self.helper = helper

        self.df = None

        self.gensim_corpus_similarities = None
        
        self.gensim_corpus = None
        self.gensim_dictionary = None
        self.gensim_bigram_model = None
        self.gensim_trigram_model= None
        self.gensim_corpus_tfidf = None
        self.gensim_vectorizer_tfidf = None
        self.gensim_w2v_model = None
        self.gensim_docs_vectors_w2v = None

        self.gensim_term_similarity_matrix = None
        self.gensim_w2v_similarity_index = None
        self.gensim_softcosine_similarity_index = None

    def w2v_similarity_index(self, w2v_model):
        w2v_similarity_index = WordEmbeddingSimilarityIndex(w2v_model)

        self.gensim_w2v_similarity_index = w2v_similarity_index

        return w2v_similarity_index

    def term_similarity_matrix(self, similarity_index, dictionary, vectorizer_tfidf):
        term_similarity_matrix = SparseTermSimilarityMatrix(
            similarity_index,
            dictionary,
            vectorizer_tfidf,
            nonzero_limit=100
        )
        
        self.gensim_term_similarity_matrix = term_similarity_matrix

        return term_similarity_matrix

    def softcosine_similarity_index(self, corpus_tfidf, similarity_matrix):
        index = SoftCosineSimilarity(corpus_tfidf, similarity_matrix, num_best=10)

        self.gensim_softcosine_similarity_index = index

        return index

    def chunks(self, lst, n_chunks):
        n = ceil(len(lst)/n_chunks)
        """Yield successive n-sized chunks from lst."""
        for i in range(0, len(lst), n):
            yield lst[i:i + n]

    def calc_article_similarities(self, args, index):
        article_tfidf = args[0]
        url = args[1]
        
        self.logger.info("Started calculating similarities for article: {}".format(url))
        
        similarities = index[article_tfidf]
 
        return similarities

    def calc_corpus_similarities(self, corpus_tfidf, index, df):
        num_cores = mp.cpu_count()
        index.chunksize = 512
        
        urls = list(df.web_sp_link.values)

        self.logger.debug("Started computing similarities for corpus of {} articles".format(len(urls)))

        corpus_count = len(urls)
        similarities = [
            (
                i % 2 == 0 and self.logger.info("Computed similarities for {} of {} articles".format(i, corpus_count))
            ) or sim 
            for i, sim in enumerate(index)
        ]

        self.gensim_corpus_similarities = list(zip(urls, similarities))
        self.logger.info("Finished computing similarities")

        return similarities

    def save_state(self, helper):
        class_name = 'similarity'

        if self.gensim_w2v_similarity_index is not None: helper.save_state(class_name, 'gensim_w2v_similarity_index', self.gensim_w2v_similarity_index, file_helper.VarType.OBJECT)
        if self.gensim_term_similarity_matrix is not None: helper.save_state(class_name, 'gensim_term_similarity_matrix', self.gensim_term_similarity_matrix, file_helper.VarType.OBJECT)
        if self.gensim_softcosine_similarity_index is not None: helper.save_state(class_name, 'gensim_softcosine_similarity_index', self.gensim_softcosine_similarity_index, file_helper.VarType.OBJECT)
        if self.gensim_corpus_similarities is not None: helper.save_state(class_name, 'gensim_corpus_similarities', self.gensim_corpus_similarities, file_helper.VarType.OBJECT)


    def load_state(self, helper):
        class_name = 'similarity'

        self.gensim_w2v_similarity_index = helper.load_state(class_name, 'gensim_w2v_similarity_index', file_helper.VarType.OBJECT)
        self.gensim_term_similarity_matrix = helper.load_state(class_name, 'gensim_term_similarity_matrix', file_helper.VarType.OBJECT)
        self.gensim_softcosine_similarity_index = helper.load_state(class_name, 'gensim_softcosine_similarity_index', file_helper.VarType.OBJECT)
        self.gensim_corpus_similarities = helper.load_state(class_name, 'gensim_corpus_similarities', file_helper.VarType.OBJECT)

        class_name = 'nlp'

        self.df = helper.load_state(class_name, 'df_result', file_helper.VarType.DATAFRAME)
        self.gensim_corpus = helper.load_state(class_name, 'gensim_corpus', file_helper.VarType.OBJECT)
        self.gensim_dictionary = helper.load_state(class_name, 'gensim_dictionary', file_helper.VarType.OBJECT)
        self.gensim_corpus_tfidf = helper.load_state(class_name, 'gensim_corpus_tfidf', file_helper.VarType.OBJECT)
        self.gensim_vectorizer_tfidf = helper.load_state(class_name, 'gensim_vectorizer_tfidf', file_helper.VarType.OBJECT)
        self.gensim_w2v_model = helper.load_state(class_name, 'gensim_w2v_model', file_helper.VarType.OBJECT)

    def build(self, load_path='06_classification_pipeline', save_path='07_calc_similarity'):
        helper = self.helper

        try:
            self.load_state(helper)

            if self.gensim_w2v_similarity_index is None: self.w2v_similarity_index(self.gensim_w2v_model.wv)
            if self.gensim_term_similarity_matrix is None: self.term_similarity_matrix(self.gensim_w2v_similarity_index, self.gensim_dictionary, self.gensim_vectorizer_tfidf)
            if self.gensim_softcosine_similarity_index is None: self.softcosine_similarity_index(self.gensim_corpus_tfidf, self.gensim_term_similarity_matrix)
            if self.gensim_corpus_similarities is None: self.calc_corpus_similarities(self.gensim_corpus_tfidf, self.gensim_softcosine_similarity_index, self.df)
        except :
            exc_type, exc_value, exc_traceback = sys.exc_info()
            self.logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
            raise

        finally:
            self.logger.info("Saving state ...")
            self.save_state(helper)
        
        return self