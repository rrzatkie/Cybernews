from os.path import basename, splitext
import validators
from datetime import datetime

from .cybernews.cybernews_api import cybernews_api, ArticleDto
from .models.nlp import NlpMode, nlp
from .models.classification import ClassificationMode, classification
from .models.similarity import similarity
from .models.scraper import scraper 
import pandas as pd
from pipeline.cybernews.cybernews_api import AddSimilarityDto
import concurrent
from joblib._multiprocessing_helpers import mp
import numpy as np

class PipelineEntry:
    def __init__(self, entry):
        self.entry = entry
        self.predictedCategory = None
        self.keywords = None
        self.text = None
        self.doc_tfidf = None
        self.doc_w2v = None

class CybernewsPipeline:
    def __init__(self, logger, helper, apiUrl):
        self.logger = logger
        self.helper = helper
        self.apiUrlPipeline = "{}/pipeline".format(apiUrl)
        self.apiUrlES = "{}/es".format(apiUrl)
        self.w2v_model = self.helper.load_state('nlp', 'gensim_w2v_model',  self.helper.VarType.OBJECT)
        self.dictionary = None,
        self.df = None

    def scrap(self, urls):
        s = scraper(self.logger, self.helper)

        self.logger.info("Scraping {} urls".format(len(urls)))
        texts = s.scrap_parallel(urls)

        return texts

    def filterUnseenWords(self, word):
        if(word in self.dictionary.token2id):
            return True
        else:
            return False
    
    def extract(self, texts):
        gensim_corpus_tfidf = self.helper.load_state('cybernews_pipeline', 'gensim_corpus_tfidf', self.helper.VarType.OBJECT)
        n = nlp(self.logger, self.helper)
        n.load_state(NlpMode.ALL, self.helper)
        n.init_spacy()
        self.dictionary = n.gensim_dictionary
        
        texts = n.preprocess_parallel(texts)
        _, docs_keywords = n.spacy_pipeline_bow(texts)  

        for i, doc_keywords in enumerate(docs_keywords):
            keywords = []
            for keyword in doc_keywords:
                keyword = keyword.strip('()').split(', ')
                keywords.append(
                    {
                        "name": keyword[0],
                        "value": float(keyword[1])
                    }
                )
            docs_keywords[i] = keywords

        docs = n.stem_words_parallel(texts)
        docs = [
            filter(self.filterUnseenWords, doc)
            for doc in docs
        ]

        docs = n.gensim_trigrams(
            docs,
            bigram_model=n.gensim_bigram_model,
            trigram_model=n.gensim_trigram_model
        )
        
        # Update
        # n.gensim_bigram_model.add_vocab(docs)
        # docs_bigram = [n.gensim_bigram_model[doc] for doc in docs]
        # n.gensim_trigram_model.add_vocab(docs_bigram)
        # docs_trigram = [n.gensim_trigram_model[doc] for doc in docs_bigram]
        # docs = docs_trigram
        # n.gensim_dictionary.add_documents(docs)

        corpus = n.gensim_doc2bow(docs, n.gensim_dictionary)
        # n.gensim_corpus.extend(corpus)

        corpus_tfidf = n.gensim_transform_tfidf(corpus, n.gensim_dictionary, n.gensim_vectorizer_tfidf)
        doc_vectors = n.gensim_transform_w2v(n.gensim_w2v_model, corpus_tfidf, n.gensim_dictionary)

        gensim_corpus_tfidf.extend(corpus_tfidf)

        return (gensim_corpus_tfidf, docs_keywords, doc_vectors)

    def classify(self, doc_vectors):
        df = self.df

        c = classification(self.logger, self.helper)
        c.load_state(helper=self.helper, mode=ClassificationMode.W2V)

        categories = c.predict(c.keras_mlp_w2v, doc_vectors, c.labels_encoder)
        categories = [
            df[df.category_slug.str.contains(category)].category.values[0] if category != 'Unknown' else category
            for category in categories
        ] 

        return categories

    def similarities(self, corpus_tfidf, urls):    
        s = similarity(self.logger, self.helper)
        s.load_state(s.helper)

        index = s.softcosine_similarity_index(corpus_tfidf, s.gensim_term_similarity_matrix)
        similarities = s.calc_corpus_similarities(index)

        similarities = list(zip(urls, similarities))

        return similarities

    def addSimilarities(self, api, similarities, df):
        self.logger.info("Started adding articles similarities.")

        d = dict(similarities)
        
        dtos_list = []
        step = 1024
        for i in range(0, df.shape[0], step):
            self.logger.info("Processed articles: {} of {}".format(i, df.shape[0]))
            
            dtos=[]
            for url_1 in df[i:i+step].web_sp_link:
                articles = d[url_1][1:]
                assert len(articles) == 9
                for article in articles:
                    url_2 =  df.iloc[article[0]].web_sp_link

                    dtos.append(
                        AddSimilarityDto(
                            Url_1= url_1,
                            Url_2= url_2,
                            value= article[1]
                        )
                    )
            dtos_list.append(dtos)

        # Parallel    
        # num_cores = mp.cpu_count()
        # with concurrent.futures.ThreadPoolExecutor(max_workers=num_cores) as executor:
        #     [chunk for chunk in executor.map(api.addSimilarity, dtos_list)]

        # Sequential
        for batch in dtos_list:
            api.addSimilarity(batch)

    def run(self):
        self.df = self.helper.load_state('cybernews_pipeline', 'df', self.helper.VarType.DATAFRAME)
        api = cybernews_api(self.logger, self.apiUrlPipeline, self.apiUrlES)
        now = datetime.utcnow().isoformat()
        
        entries = api.getArticles()

        pipelineEntries = [PipelineEntry(entry) for entry in entries]

        urls = [pipelineEntry.entry['url'] for pipelineEntry in pipelineEntries]
        scraped_articles = self.scrap(urls)
        
        invalid = []
        for i in range(len(scraped_articles)):
            text = scraped_articles[i]
            if(text != ''):    
                pipelineEntries[i].text = text
                pipelineEntries[i].entry['pipelineRunAt'] = now
            else:
                scraped_articles.pop(i)
                invalid.append(i)

        [pipelineEntries.pop(i) for i in invalid]
        
        columns = self.df.columns
        values = [['']*len(columns) for i in range(len(pipelineEntries))]
        
        for i, v in enumerate(values):
            v[0] = pipelineEntries[i].text
            v[8] = pipelineEntries[i].entry['url']

        temp_df = pd.DataFrame(values, columns=columns)

        temp_df['text'].replace('', np.nan, inplace=True)
        temp_df.dropna(subset=['text'], inplace=True)
        temp_df['category_slug'] = temp_df['category_slug'].fillna('')
        temp_df['category'] = temp_df['category'].fillna('')
        
        self.df = self.df.append(temp_df, ignore_index=True)

        corpus_tfidf, keywordsList, doc_vectors= self.extract(scraped_articles)
        categoriesList = self.classify(doc_vectors)

        corpus_similarities = self.similarities(corpus_tfidf, self.df.web_sp_link.values)

        for pipelineEntry, categories, keywords in zip(pipelineEntries, categoriesList, keywordsList):
            article = ArticleDto(
                author = pipelineEntry.entry['author'],
                imageUrl = pipelineEntry.entry['imageUrl'],
                title = pipelineEntry.entry['title'],
                url = pipelineEntry.entry['url'],
                dateCreatedUnix = 0,
                pipelineRunAt = pipelineEntry.entry['pipelineRunAt'],
                categories = [categories],
                keywords = keywords
            )
            if(categories == 'Unknown'):
                article.pipelineRunAt = None

            self.logger.info("Updating article: ['{}...']".format(article.title[:30]))
            status = api.insertOrUpdateArticles([article])

            self.logger.info("Respone from Cybernews API: {}".format(status))
        
        self.addSimilarities(api, corpus_similarities, self.df)


        self.logger.info("Reindexing Aarticles, Keywords and Categories in ElasticSearhc engine")
        api.triggerIndexing()

        self.helper.save_state('cybernews_pipeline', 'df', self.df, self.helper.VarType.DATAFRAME)
        self.helper.save_state('cybernews_pipeline', 'gensim_corpus_tfidf', corpus_tfidf, self.helper.VarType.OBJECT)

        self.logger.info("Finished pipeline.")