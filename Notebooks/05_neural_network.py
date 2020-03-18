# To add a new cell, type '#%%'
# To add a new markdown cell, type '#%% [markdown]'

#%%
import pandas as pd
import os
import re
from datetime import datetime
import logging

def logger_init():
    # q = mp.Queue()

    formatter = logging.Formatter('%(asctime)s - %(name)s(%(process)d) - %(levelname)s - %(message)s')

    sh = logging.StreamHandler()
    sh.setLevel(logging.INFO)
    sh.setFormatter(formatter)

    fh = logging.FileHandler(r'logs/{}-nlp-pipeline-logs'.format(datetime.now().strftime("%Y-%m-%d-%H-%M-%S")))
    fh.setLevel(logging.INFO)
    fh.setFormatter(formatter)

    logger = logging.getLogger()
    logger.setLevel(logging.INFO)

    logger.addHandler(fh)
    logger.addHandler(sh)

    # ql = QueueListener(q, sh, fh)
    # ql.start()

    # return ql, q

def get_newest_file(fn_list):
    dates = []
    for f in fn_list:
        match = re.search("([0-9]{2}-[0-9]{2}-[0-9]{4}-[0-9]{2}-[0-9]{2}-[0-9]{2})", f)
        if(match is not None):
            dates.append({'fileName': f, 'date': match.group()})
    
    dates = list(map(lambda x: {'fileName': x['fileName'], 'date': datetime.strptime(x['date'], "%m-%d-%Y-%H-%M-%S")}, dates))
    dates.sort(key=lambda x: x['date'], reverse=True)
    return dates[0]['fileName']

if __name__ == '__main__':
    logger_init()
    fn_list = os.listdir("data/after-nlp-pipeline")
    fn_newest = get_newest_file(fn_list)

    f = open("data/after-nlp-pipeline/{}".format(fn_newest), 'r', encoding="utf-8")
    df = pd.read_csv(f, index_col=0, converters={'text_scraped_words': lambda x: x[1:-1].replace("'", "").split(', '),'text_lemmatized': lambda x: x[1:-1].replace("'", "").split(', ') })
    f.close()

    logging.info("Successfully imported file: {}".format(fn_newest))


#%%
from sklearn.decomposition import NMF
from sklearn.feature_extraction.text import TfidfVectorizer


def custom_tokenizer(text):
    return text

n_topics = 15
n_top_words = 11

vectorizer = TfidfVectorizer(tokenizer=custom_tokenizer, stop_words='english', lowercase=False, min_df=int())    
data_vectorized = vectorizer.fit_transform(df.text_lemmatized.values)