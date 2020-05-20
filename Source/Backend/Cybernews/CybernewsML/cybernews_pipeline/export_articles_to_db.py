import pandas
import os
import re
from datetime import datetime
import requests
import json

from shared.file_helper import file_helper
from shared.logger import logger_init

cybernewsArticlesApiUrl = 'http://localhost:4201/api/pipeline'

class ArticleDto:
    def __init__(  self,
                    author,
                    imageUrl,
                    title, 
                    url, 
                    dateCreatedUnix, 
                    categories, 
                    keywords):
        self.author = author
        self.imageUrl = imageUrl
        self.title = title
        self.url = url
        self.dateCreatedUnix = dateCreatedUnix
        self.categories = categories
        self.keywords = keywords

def addArticles(apiUrl, articles):
    url = "{}/articles/add".format(apiUrl)
    headers = {'Content-Type' : 'application/json'}
    
    objStrs = []
    for article in articles:
        objStrs.append(article.__dict__)
    jsonString = json.dumps(objStrs)
    response = requests.post(url, data=jsonString, headers=headers)

    return response.status_code

def addSimilarity(apiUrl, similarity):
    url = "{}/similarities/add".format(apiUrl)
    headers = {'Content-Type' : 'application/json'}

    jsonString = json.dumps(similarity)
    response = requests.post(url, data=jsonString, headers=headers)

    return response.status_code

def main():
    logger = logger_init('export')
    helper = file_helper(logger)

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

            articleDto = ArticleDto(
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
        addArticles(cybernewsArticlesApiUrl, articles)

if __name__ == '__main__':
    main()
    # similarity = {"articleId_1":151, "articleId_2":152, "value":0.4}
    # addSimilarity(cybernewsArticlesApiUrl, similarity)
    # similarity = {"articleId_1":152, "articleId_2":151, "value":0.4}
    # addSimilarity(cybernewsArticlesApiUrl, similarity)