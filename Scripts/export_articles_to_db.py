import pandas
import os
import re
from datetime import datetime
import requests
import json


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
    url = "{}/article/add".format(apiUrl)
    headers = {'Content-Type' : 'application/json'}
    
    objStrs = []
    for article in articles:
        objStrs.append(article.__dict__)
    jsonString = json.dumps(objStrs)
    response = requests.post(url, data=jsonString, headers=headers)

    return response.status_code

def get_newest_file(fn_list):
    dates = []
    for f in fn_list:
        match = re.search("([0-9]{2}-[0-9]{2}-[0-9]{4}-[0-9]{2}-[0-9]{2}-[0-9]{2})", f)
        if(match is not None):
            dates.append({'fileName': f, 'date': match.group()})
    
    dates = list(map(lambda x: {'fileName': x['fileName'], 'date': datetime.strptime(x['date'], "%m-%d-%Y-%H-%M-%S")}, dates))
    dates.sort(key=lambda x: x['date'], reverse=True)
    return dates[0]['fileName']

def main():
    fn_list = os.listdir('/home/rrzatkie/Work/Cybernews/Source/Backend/Cybernews/Cybernews.ML/data/after-nlp-pipeline')
    fn_newest = get_newest_file(fn_list)

    f = open('/home/rrzatkie/Work/Cybernews/Source/Backend/Cybernews/Cybernews.ML/data/after-nlp-pipeline/{}'.format(fn_newest), 'r', encoding="utf-8")
    df = pandas.read_csv(f, 
        index_col=0, 
        converters={'text_scraped_words': lambda x: x[1:-1].replace("'", "").split(', '),
            'text_lemmatized': lambda x: x[1:-1].replace("'", "").split(', '),
            'text_ner': lambda x: x[1:-1].replace("'", "").split(', ')
        }
    )
    f.close()

    print("Successfully imported file: {}".format(fn_newest))

    cybernewsArticlesApiUrl = 'http://localhost:4201/api/ArticlesUI'
    begin = 0
    end = len(df.values)
    step = 1024
    for i in range(begin, end, step):
        df_window = df[i:i+step]
        if(len(df_window) <= 0):
            break

        articles = []
        for index, article in df_window.iterrows():
            keywords = []
            for keyword in article['text_ner']:
                keyword = keyword.split(':')
                keywords.append(keyword[0])

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
        print("Sending rows from {} to {}".format(i, i+step))
        addArticles(cybernewsArticlesApiUrl, articles)

if __name__ == '__main__':
    main()
