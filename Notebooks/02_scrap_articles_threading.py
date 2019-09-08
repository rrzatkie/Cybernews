import numpy as np
import multiprocessing as mp
import concurrent.futures
import threading
import logging
from logging.handlers import QueueHandler, QueueListener
import datetime
import requests
import time
import sys
import pandas as pd
import newspaper as nwp
import os
import numpy

thread_local = threading.local()
lock = threading.Lock()
global_counter = 0
count = 0


def get_session():
    if not hasattr(thread_local, "session"):
        thread_local.session = requests.Session()
    return thread_local.session


def download_site(df_row):
    session =  requests.Session()
    text = ""
    try:
        url = df_row['web_sp_link']
        with session.get(url, timeout=5) as response:
            logging.info('Start processing url: {}\n'.format(url))

            article = nwp.Article(url)
            article.html = response.text
            article.download_state = 2
            article.parse()
            time.sleep(0.5)
            text = article.text
    except Exception as e:
        logging.warning("Processing failed for url: {}\n".format(url))
        logging.warning("EXCEPTION - {}\n".format(e))
        logging.warning("PID that casued exception: {}\n".format(os.getpid()))
    finally:
        global global_counter
        global count
        lock.acquire()
        global_counter += 1
        logging.info('Finished processing url: {}\n'.format(url))
        logging.info('Processed {} / {} URLs.\n'.format(global_counter, count))
        lock.release()
        df_row['text_scraped']=text
        return df_row

def download_all_sites(sites):
    global count
    count = len(sites)
    num_cores = mp.cpu_count()   
    
    with concurrent.futures.ThreadPoolExecutor(max_workers=4*num_cores) as executor:
        results = [row for row in executor.map(download_site, sites)]
        return results

def main(df):
    scraped_articles = []
    num_cores = mp.cpu_count()

    inputs = [row for k,row in df.iterrows()]
    scraped_articles.extend(download_all_sites(inputs))
        
    df = pd.DataFrame(scraped_articles)
    file_name = r'data\after-scraping-{}.csv'.format(datetime.datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
    f = open(file_name, 'w', encoding="utf-8")
    df.to_csv(path_or_buf=f)
    f.close()
    
if __name__ == '__main__':
    logger = logging.getLogger()
    logger.setLevel(logging.INFO)
    formatter = logging.Formatter('%(asctime)s - %(name)s(%(thread)d) - %(levelname)s - %(message)s')

    sh = logging.StreamHandler()
    sh.setLevel(logging.INFO)
    sh.setFormatter(formatter)

    fh = logging.FileHandler(r'logs/{}-scraping-logs'.format(datetime.datetime.now().strftime("%Y-%m-%d-%H-%M-%S")))
    
    logger.addHandler(fh)
    logger.addHandler(sh)
    
    start_time = time.time()
    
    f = open('raw_data_cyware-api-14-08-2019.csv', 'r', encoding="utf-8")
    df = pd.read_csv(f, index_col=0)
    f.close()
    
    main(df)
    
    elapsed_time = time.time()-start_time
    logging.info("Success! Elapsed time: {}".format(elapsed_time))