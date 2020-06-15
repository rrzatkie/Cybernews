import pandas
import os
import re
from datetime import datetime
import requests
import json

from libs.cybernews_pipeline.shared.file_helper import file_helper
from libs.cybernews_pipeline.shared.logger import logger_init
from libs.cybernews_pipeline.shared.similarity import similarity
from libs.cybernews_pipeline.shared.cybernews_api import cybernews_api, CybernewsAPIArticleDto, AddSimilarityDto
from os.path import abspath, basename, dirname, splitext

__ROOT_DIR__ = dirname(abspath(__file__))

def addArticles(logger, helper, api):
    df = helper.load_state('classification', 'df_result', helper.VarType.DATAFRAME)

    begin = 0
    end = len(df.values)
    step = 256
    for i in range(begin, end, step):
        df_window = df[i:i+step]
        if(len(df_window) <= 0):
            break

        articles = []
        for index, article in df_window.iterrows():
            keywords = []
            for keyword in article['text_keywords_spacy']:
                keyword = keyword.strip('()').split(', ')
                keywords.append(
                    {
                        "name": keyword[0],
                        "value": float(keyword[1])
                    }
                )

            articleDto = CybernewsAPIArticleDto(
                author= 'Cyware',
                imageUrl=article['image'],
                title=article['title'],
                url=article['web_sp_link'],
                dateCreatedUnix=article['p_time'],
                categories=[article['category']],
                keywords=keywords
            )
            articles.append(articleDto)

        logger.info("Sending rows from {} to {}".format(i, i+step))
        api.addArticles(articles)

def addSimilarities(logger,helper, api):
    logger.info("Started adding articles similarities.")

    s = similarity(logger, helper)
    s.load_state(s.helper)

    df_c = helper.load_state('classification', 'df_result', helper.VarType.DATAFRAME)
    df_n = helper.load_state('nlp', 'df_result', helper.VarType.DATAFRAME)
    
    d = dict(s.gensim_corpus_similarities)

    step = 1024
    for i in range(0, df_c.shape[0], step):
        logger.info("Processed articles: {} of {}".format(i, df_c.shape[0]))
        
        dtos=[]
        for url_1 in df_c[i:i+step].web_sp_link:
            articles = d[url_1][1:]
            assert len(articles) == 9
            for article in articles:
                url_2 =  df_c.iloc[article[0]].web_sp_link

                dtos.append(
                    AddSimilarityDto(
                        Url_1= url_1,
                        Url_2= url_2,
                        value= article[1]
                    )
                )

        api.addSimilarity(dtos)

if __name__ == '__main__':
    logger = logger_init(__ROOT_DIR__, splitext(basename(__file__))[0])
    helper = file_helper(
        logger,
        pickles_path="{}/libs/cybernews_pipeline/pickles".format(__ROOT_DIR__),
        data_path="{}/libs/cybernews_pipeline/data".format(__ROOT_DIR__)
    )

    ca = cybernews_api(logger, apiUrl = 'http://localhost:4201/api/pipeline')
    
    addArticles(logger, helper, ca)
    addSimilarities(logger,helper, ca)
    