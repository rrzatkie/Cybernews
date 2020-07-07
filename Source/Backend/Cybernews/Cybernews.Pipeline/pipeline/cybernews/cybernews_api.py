import validators
import json
import requests
import urllib.parse as urlparse
from urllib.parse import urlencode
from datetime import datetime

from pipeline.helpers.logger import logger_init
from pipeline.models.nlp import nlp
from pipeline.models.classification import classification
from pipeline.models.scraper import scraper


class ArticleDto:
    def __init__(  self,
                    author,
                    title,
                    dateCreatedUnix, 
                    pipelineRunAt, 
                    imageUrl,
                    url,
                    keywords, 
                    categories
    ):
        self.author = author
        self.title = title
        self.dateCreatedUnix = dateCreatedUnix
        self.pipelineRunAt = pipelineRunAt
        self.imageUrl = imageUrl
        self.url = url
        self.keywords = keywords
        self.categories = categories

class UpdateCategoryDto:
    def __init__(
        self,
        articleUrl,
        categoryNames
    ):
        self.articleUrl = articleUrl
        self.categoryNames = categoryNames

class AddSimilarityDto:
    def __init__(
        self,
        Url_1,
        Url_2,
        value
    ):
        self.Url_1 = Url_1
        self.Url_2 = Url_2
        self.value = value

class cybernews_api:
    def __init__(self, logger, apiUrl):
        self.logger = logger
        self.apiUrl = apiUrl

    def getArticles(self):
        url = "{}/articles".format(self.apiUrl)

        self.logger.info("Fetching articles from {}".format(self.apiUrl))
        response = requests.get(url)
        json_content = json.loads(response.text)

        self.logger.info("Finished. Returning {} entries".format(len(json_content['data'])))

        return json_content['data']

    def insertOrUpdateArticles(self, articles):
        url = "{}/articles".format(self.apiUrl)
        headers = {'Content-Type' : 'application/json'}
        
        objStrs = []
        for article in articles:
            objStrs.append(article.__dict__)

        jsonString = json.dumps(objStrs)
        response = requests.post(url, data=jsonString, headers=headers)

        return response.status_code

    def addSimilarity(self, addSimilarityDtos):
        self.logger.info("Started sending {} similarity dtos".format(len(addSimilarityDtos)))
        url = "{}/similarities/add".format(self.apiUrl)
        headers = {'Content-Type' : 'application/json'}

        objStrs = []
        for dto in addSimilarityDtos:
            objStrs.append(dto.__dict__)

        jsonString = json.dumps(objStrs)
        response = requests.post(url, data=jsonString, headers=headers)

        self.logger.info("Finished.".format(len(addSimilarityDtos)))
        return response.status_code

    def updateCategories(self, articleUrl, categories):
        url = "{}/articles/category".format(self.apiUrl)
        headers = {'Content-Type' : 'application/json'}

        dto = UpdateCategoryDto(articleUrl, categories);
        
        jsonString = json.dumps(dto.__dict__)
        response = requests.post(url, data=jsonString, headers=headers)

        return response.status_code 

    def upadateArticle(self, article):
        url = "{}/articles/".format(self.apiUrl)
        headers = {'Content-Type' : 'application/json'}

        dto = article
        
        jsonString = json.dumps(dto)
        response = requests.post(url, data=jsonString, headers=headers)

        return response.status_code 

    def getArticlesSimilarityPendind(self, url):
        apiUrl = "{}/similarities/pending".format(self.apiUrl)
        params = { 'url':url }

        self.logger.info("Fetching articles from {}".format(apiUrl))
        
        url_parts = list(urlparse.urlparse(apiUrl))
        query = dict(urlparse.parse_qsl(url_parts[4]))
        query.update(params)

        url_parts[4] = urlencode(query)
        urlparse.urlunparse(url_parts)
        
        response = requests.get(apiUrl)
        json_content = json.loads(response.text)

        self.logger.info("Finished. Returning {} entries".format(len(json_content['data'])))

        return json_content['data']