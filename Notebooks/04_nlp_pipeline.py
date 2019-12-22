import numpy as np
import multiprocessing as mp
from joblib import Parallel, delayed
from spacy.util import minibatch
from functools import partial 
import concurrent.futures
import threading
import logging
from logging.handlers import QueueHandler, QueueListener
import pandas as pd
import os
import re
from datetime import datetime
import time
import spacy
import pickle

# Global spaCy model object
nlp = None

# Enable text categorization by spacy
TEXT_CAT_ENABLE = False

# Global counter
counter = None

# Total count
total_count = 0

def nlp_pipeline(texts):
    global nlp
    nlp_model = "en_core_web_md"

    global total_count
    global counter

    if(nlp is None):
        nlp = spacy.load(nlp_model)
        logging.info("Loaded nlp model: {}.".format(nlp_model))
    
    # if(TEXT_CAT_ENABLE):
    #     # Add text categorization pipe
    #     component = nlp.create_pipe("textcat")
    #     nlp.add_pipe(component)
    #     logging.info("Added TextCategorization step in nlp pipeline.")

    POS_ALLOWED = ["NOUN", "VERB", "PROPN", "NUM"]

    docs_lemmatized = []
    docs_ner = []
    for doc in nlp.pipe(texts,batch_size=1, n_threads=mp.cpu_count()):
        logging.info("Started processing article [{}...]".format(doc.text[0:20].encode("utf-8")))
        doc_lemmatized = []
        doc_ner = []
        for token in doc:
            if(token.pos_ in POS_ALLOWED and token.lemma_ not in doc_lemmatized):
                doc_lemmatized.append(token.lemma_)
                if(token.ent_type_ != "" ):
                    doc_ner.append("{}:{}".format(token,token.ent_type_))
        
        docs_lemmatized.append(doc_lemmatized)
        docs_ner.append(doc_ner)
        
        with counter.get_lock():
            counter.value += 1
        
        logging.info("Processed articles: {} / {}.".format(counter.value, total_count))
    
    df = pd.DataFrame(columns = ['text_lemmatized', "text_ner"])
    df["text_lemmatized"] = docs_lemmatized
    df["text_ner"] = docs_ner

    return df

def worker_init(cntr, tc):
    # # all records from worker processes go to qh and then into q
    # qh = QueueHandler(q)
    # logger = logging.getLogger()
    # logger.setLevel(logging.INFO)
    # logger.addHandler(qh)

    global counter
    counter = cntr

    global total_count
    total_count = tc

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

def main(df):
    # q_listener, q = logger_init()

    df = df[0:]

    num_cores = mp.cpu_count()

    cnt = mp.Value("i", 0)
    total_count = len(df.values)

    worker_init(cnt, total_count)

    # inputs = np.array_split(df[0:100].text_scraped, num_cores)

    global nlp
    nlp = spacy.load("en_core_web_md")

    # results = Parallel(n_jobs=int(num_cores/4), backend="multiprocessing", prefer="processes") (
    #     delayed(nlp_pipeline)(part) for part in inputs
    # )

    # df_temp = pd.concat(results, ignore_index=True, axis=0) 
    
    df_new = nlp_pipeline(df.text_scraped)
    df_new.index = df.index
    
    df = pd.concat([df, df_new], axis=1)
        
    file_name = r'data\after-nlp-pipeline\after-nlp-pipeline-{}.csv'.format(datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
    f = open(file_name, 'w', encoding="utf-8")
    df.to_csv(path_or_buf=f)
    f.close()

    # q_listener.stop()

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

    fn_list = os.listdir("data/after-cleaning")
    fn_newest = get_newest_file(fn_list)

    f = open("data/after-cleaning/{}".format(fn_newest), 'r', encoding="utf-8")
    df = pd.read_csv(f, index_col=0, converters={'text_scraped_words': lambda x: x[1:-1].replace("'", "").split(', ')})
    f.close()

    logging.info("Successfully imported file: {}".format(fn_newest)) 

    start_time = time.time()

    main(df)

    elapsed_time = time.time()-start_time
    logging.info("Success! Elapsed time: {}".format(elapsed_time))