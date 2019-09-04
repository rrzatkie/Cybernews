import numpy as np
import multiprocessing as mp
import logging
from logging.handlers import QueueHandler, QueueListener
import datetime
from tqdm import tqdm
import requests
import time
import sys
import pandas as pd
import newspaper as nwp
import os

def download_site(url, session):
    with session.get(url) as response:
        print(f"Read {len(response.content)} from {url}")

def download_all_sites(sites):
    with requests.Session() as session:
        for url in sites:
            download_site(url, session)

def worker_init(q):
    # all records from worker processes go to qh and then into q
    qh = QueueHandler(q)
    logger = logging.getLogger()
    logger.setLevel(logging.INFO)
    logger.addHandler(qh)
    
def worker(df_row):
    text = ""
    url = ""
    try:
        url = df_row['web_sp_link']
        logging.info('{} - Start processing url: {}\n'.format(str(datetime.datetime.now()), url))
        
        article = nwp.Article(url)
        html = requests.request("GET", url)
        article.html = html.text
        article.download_state = 2
        article.parse()
        text = article.text
    except Exception as e:
        logging.warning("{} - Processing failed for url: {}\n".format(str(datetime.datetime.now()), url))
        logging.warning("EXCEPTION - {}\n".format(e))
        logging.warning("PID that casued exception: {}\n".format(mp.getpid()))
    finally:        
        logging.info('{} - Finished processing url: {}\n'.format(str(datetime.datetime.now()), url))
        df_row['text_scraped']=text
        return df_row

def logger_init():
    q = mp.Queue()
    # this is the handler for all log records
    handler = logging.StreamHandler()
    handler.setFormatter(logging.Formatter("%(levelname)s: %(asctime)s - %(process)s - %(message)s"))

    # ql gets records from the queue and sends them to the handler
    ql = QueueListener(q, handler)
    ql.start()

    logger = logging.getLogger()
    logger.setLevel(logging.INFO)
    # add the handler to the logger so records from this process are handled
    logger.addHandler(handler)

    return ql, q


scraped_articles = []    

def main():
    q_listener, q = logger_init()

    f = open('raw_data_cyware-api-14-08-2019.csv', 'r', encoding="utf-8")
    df = pd.read_csv(f, index_col=0)
    f.close()
    
    num_cores = mp.cpu_count()
    last_output_len = 0

    start_time = time.time()

    inputs = [row for k,row in df.iterrows()]
    
    with mp.Pool(num_cores, worker_init, [q]) as pool:
        rows = [row for row in pool.map(worker, inputs)]
        scraped_articles.extend(rows)

    elapsed_time = time.time()-start_time

    q_listener.stop()
    
    df = pd.DataFrame(scraped_articles)
    
    file_name = "after-scraping-{}.csv".format(datetime.date.now().strftime("%m-%d-%Y"))
    f = open(file_name, 'w', encoding="utf-8")
    df.to_csv(path_or_buf=f)
    f.close()
    
    logging.info("Success! Elapsed time: {}".format(elapsed_time))
    
if __name__ == '__main__':
    try:
        main()
    except KeyboardInterrupt:
        file_name = "failure-during-scraping-{}.csv".format(datetime.date.now().strftime("%m-%d-%Y"))
        logging.warning("Program failed. Saving current results to file: {}".format(file_name))
        
        df = pd.DataFrame(scraped_articles)
    
        f = open(file_name, 'w', encoding="utf-8")
        df.to_csv(path_or_buf=f)
        f.close()
        
        sys.exit(1)