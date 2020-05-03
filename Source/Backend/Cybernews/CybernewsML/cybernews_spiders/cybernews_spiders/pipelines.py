import time

import newspaper
from scrapy.exceptions import DropItem
import json
import requests
import logging

from .seen_url_database import SeenURLDatabase

logger = logging.getLogger(__file__)

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

def addArticle(apiUrl, article):
    url = "{}/article/add".format(apiUrl)
    headers = {'Content-Type' : 'application/json'}
    
    objStrs = []
    objStrs.append(article.__dict__)
    jsonString = json.dumps(objStrs)
    logger.debug("Article is going to be sent to cybernews api: \n{}".format(jsonString))
    response = requests.post(url, data=jsonString, headers=headers)

    
    return response.status_code

class CybernewsSpidersPipeline(object):
    def process_item(self, item, spider):
        article = newspaper.Article(item['url'])
        logger.info("article %s is about to be downloaded", item['url'])
        article.download()
        # in case it fails to download immediately
        if article.download_state == 0:
            time.sleep(1)
        try:
            article.parse()
        except newspaper.ArticleException:
            raise DropItem("Article failed to download.")

        if len(article.text.split()) < 80:
            logging.debug("article too short")
            raise DropItem("Article too short.")

        item['title'] = article.title
        item['text'] = article.text
        item['length'] = len(article.text.split())
        item['image_url'] = article.top_image

        if not item['author'] and article.authors:
            item['author'] = article.authors[0]

        cybernewsArticlesApiUrl = 'http://localhost:4201/api/ArticlesUI'
        logging.debug("article creation in the db")
        
        articleDto = CybernewsAPIArticleDto(
            author= item['source'],
            imageUrl=item['image_url'],
            title=item['title'],
            url=item['url'],
            dateCreatedUnix=int(item['pub_date'].timestamp()),
            categories=[],
            keywords=[]
        )
        
        resp = addArticle(cybernewsArticlesApiUrl, articleDto)
        logger.debug("response code from Cybernews api: {}".format(resp))
        return item

    def open_spider(self, spider):
        logging.debug("spider seen_url_db opened")
        spider.seen_url_db = SeenURLDatabase()

    def close_spider(self, spider):
        logging.debug("spider seen_url_db closed")
        spider.seen_url_db.close()