from os.path import basename, splitext
import validators
from datetime import datetime

from cybernews_pipeline.shared.cybernews_api import cybernews_api

from cybernews_pipeline.shared.nlp import NlpMode, nlp
from cybernews_pipeline.shared.classification import ClassificationMode, classification
from cybernews_pipeline.shared.similarity import similarity
from cybernews_pipeline.shared.scraper import scraper 

class pipeline:
    def __init__(self, logger, helper, apiUrl):
        self.logger = logger
        self.helper = helper
        self.apiUrl = "{}/pipeline".format(apiUrl)
        self.w2v_model = self.helper.load_state('nlp', 'gensim_w2v_model',  self.helper.VarType.OBJECT)

    def scrap(self, url):
        s = scraper(self.logger)

        text=""
        if(validators.url(url)):
            self.logger.info("Analyzing url {}".format(url))
            text = s.scrap_article(url)
        else:
            self.logger.error('Bad URL format.')

        return text

    def extract(self, texts):
        n = nlp(self.logger)
        n.load_state(NlpMode.ALL, self.helper)
        n.init_spacy()
        
        texts = n.textacy_preprocess(texts)

        _, keywords = n.spacy_pipeline_bow(texts)

        docs = n.gensim_trigrams(n.stem_words(texts), n.gensim_bigram_model, n.gensim_trigram_model)

        corpus = n.gensim_doc2bow(docs, n.gensim_dictionary)

        corpus_tfidf = n.gensim_transform_tfidf(corpus, n.gensim_dictionary, n.gensim_vectorizer_tfidf)

        doc_vectors = n.gensim_transform_w2v(n.gensim_w2v_model, corpus_tfidf, n.gensim_dictionary)

        return (corpus, keywords, doc_vectors)

    def classify(self, doc_vectors):
        c = classification(self.logger)
        c.load_state(ClassificationMode.W2V)

        return c.predict(c.keras_mlp_w2v, doc_vectors, c.labels_encoder)

    def calcSimilarity(self, article_1, article_2):
        s = similarity(self.logger)
        s.load_state(self.helper)

        return s.similarity_measure(article_1, article_2, s.gensim_similarity_matrix)

    
    def run(self):
        api = cybernews_api(self.logger, self.apiUrl)

        entries = api.getArticles()
        scraped_articles = [self.scrap(entry['url']) for entry in entries]

        corpus, keywords, doc_vectors= self.extract(scraped_articles)
        sim = self.calcSimilarity(corpus[0], corpus[1])
        categoriesList = self.classify(doc_vectors)

        for entry, categories in zip(entries, categoriesList):
            status = api.updateCategories(entry['url'], [categories])
            if(status == 200):
                entry['pipelineRunAt'] = datetime.utcnow().isoformat() 
                api.upadateArticle(entry)

        