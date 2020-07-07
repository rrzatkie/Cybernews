import sys
from datetime import datetime
import multiprocessing as mp

import concurrent.futures
import requests
import newspaper as nwp
from newspaper import Config
import pandas as pd

from pipeline.helpers.file_helper import file_helper
import validators

class scraper:
    def __init__(self, logger, helper):
        self.logger = logger
        self.helper = helper
        self.df = None
        self.df_result = None

    def scrap_article(self, url):
        text = ""
        if(validators.url(url)):
            try:
                with requests.Session() as s:
                    self.logger.info('Scraping url: {}'.format(url))
                    s.headers = {'User-Agent': 'Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Ubuntu Chromium/83.0.4103.61 Chrome/83.0.4103.61 Safari/537.36'}
                    response = s.get(url, timeout=5)
                    article = nwp.Article(url)
                    article.html = response.text
                    article.download_state = 2
                    article.parse()
                    
                    text = article.text
                    if(text==''):
                        raise Exception

            except Exception as e:
                self.logger.error("Processing failed for url: {}".format(url))
            finally:
                return text
        else:
            self.logger.error('Bad URL format.')
            return text


    def scrap_parallel(self, urls):
        num_cores = mp.cpu_count()

        scraped_articles = []
        with concurrent.futures.ThreadPoolExecutor(max_workers=num_cores) as executor:
            scraped_articles = [text for text in executor.map(self.scrap_article, urls)]
        
        self.scraped_articles = scraped_articles
        self.logger.info("Finished processing urls")

        return scraped_articles

    def merge_results(self):
        df_result = self.df.reset_index(drop=True)
        
        s1 = pd.Series(name='text_scraped', data=self.scraped_articles)
        
        df_result = pd.concat([df_result, s1], axis=1)
        
        self.logger.info("Merged results to dataframe.")
        self.df_result = df_result

        return df_result

    def load_state(self, helper):
        self.logger.info("Try to load state...")

        class_name = 'scraper'
        
        self.df = helper.load_state(class_name, 'df', file_helper.VarType.DATAFRAME)
        self.scraped_articles = helper.load_state(class_name, 'scraped_articles', file_helper.VarType.OBJECT)

    def save_state(self, path, helper):
        class_name = 'scraper'

        if self.df is not None: helper.save_state(class_name, 'df', self.df, file_helper.VarType.DATAFRAME)
        if self.scraped_articles is not None: helper.save_state(class_name, 'scraped_articles', self.scraped_articles, file_helper.VarType.OBJECT)

        path = '{}/{}-{}.csv'.format(path, path, datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
        if self.df_result is not None: 
            helper.save_df_to_csv(self.df_result, path)
            helper.save_state(class_name, 'df_result', self.df_result, file_helper.VarType.DATAFRAME)

    def build(self, load_path='01_crawl_urls', save_path='02_scrap_articles'):
        helper = self.helper

        try:
            self.load_state(helper)
            
            if self.df is None: self.df=helper.load_df_from_csv(load_path)

            urls = [row['web_sp_link'] for i, row in self.df.iterrows()]
            if self.scraped_articles is None: self.scrap_parallel(urls)
            
            if self.df_result is None: self.merge_results()
        except:
            exc_type, exc_value, exc_traceback = sys.exc_info()
            self.logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
            raise
        finally:
            self.logger.info("Saving state...")
            self.save_state(save_path, helper)

        return self