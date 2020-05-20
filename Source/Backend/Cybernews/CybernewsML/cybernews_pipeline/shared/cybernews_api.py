import validators
import json
import requests

from .logger import logger_init
from .nlp import nlp
from .classification import classification
from .scraper import scraper


class CybernewsAPIArticleDto:
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
        articleId_1,
        articleId_2,
        value
    ):
        self.articleId_1 = articleId_1
        self.articleId_2 = articleId_2
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


    def addSimilarity(self, articleId_1, articleId_2, value):
        url = "{}/similarities/add".format(self.apiUrl)
        headers = {'Content-Type' : 'application/json'}

        dto = AddSimilarityDto(articleId_1, articleId_2, value)

        jsonString = json.dumps(dto.__dict__)
        response = requests.post(url, data=jsonString, headers=headers)

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