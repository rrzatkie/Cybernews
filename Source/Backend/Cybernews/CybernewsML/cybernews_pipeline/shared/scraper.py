import sys
import concurrent.futures
import requests
import newspaper as nwp
import multiprocessing as mp
import pandas as pd

from datetime import datetime

from cybernews_pipeline.shared.file_helper import file_helper

class scraper:
    def __init__(self, logger):
        self.logger = logger
        self.df = None
        self.df_result = None

    def scrap_article(self, url):
        text = ""
        try:
            with requests.Session().get(url, timeout=5) as response:
                self.logger.info('Scraping url: {}'.format(url))

                article = nwp.Article(url)
                article.html = response.text
                article.download_state = 2
                article.parse()
                
                text = article.text
        except Exception as e:
            self.logger.error("Processing failed for url: {}".format(url))
            
        return text

    def scrap_parallel(self, df):
        num_cores = mp.cpu_count()

        scraped_articles = []
        with concurrent.futures.ThreadPoolExecutor(max_workers=num_cores) as executor:
            urls = [row['web_sp_link'] for i, row in df.iterrows()]
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

    def load_state(self):
        self.logger.info("Try to load state...")
        helper = file_helper(self.logger)
        class_name = 'scraper'
        
        self.df = helper.load_state(class_name, 'df', file_helper.VarType.DATAFRAME)
        self.scraped_articles = helper.load_state(class_name, 'scraped_articles', file_helper.VarType.OBJECT)

    def save_state(self, path):
        helper = file_helper(self.logger)
        class_name = 'scraper'

        if self.df is not None: helper.save_state(class_name, 'df', self.df, file_helper.VarType.DATAFRAME)
        if self.scraped_articles is not None: helper.save_state(class_name, 'scraped_articles', self.scraped_articles, file_helper.VarType.OBJECT)

        path = '{}/{}-{}.csv'.format(path, path, datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
        if self.df_result is not None: 
            helper.save_df_to_csv(self.df_result, path)
            helper.save_state(class_name, 'df_result', self.df_result, file_helper.VarType.DATAFRAME)

    def build(self, load_path='01_crawl_urls', save_path='02_scrap_articles'):
        helper = file_helper(self.logger)

        try:
            self.load_state()
            
            if self.df is None: self.df=helper.load_df_from_csv('data/{}'.format(load_path))
            if self.scraped_articles is None: self.scrap_parallel(self.df)
            if self.df_result is None: self.merge_results()
        except:
            exc_type, exc_value, exc_traceback = sys.exc_info()
            self.logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
            raise
        finally:
            self.logger.info("Saving state...")
            self.save_state(save_path)

        return self