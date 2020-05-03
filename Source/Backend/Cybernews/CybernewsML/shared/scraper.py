import sys
import concurrent.futures
import requests
import newspaper as nwp
import multiprocessing as mp

from shared.file_helper import file_helper

class scraper:
    def __init__(self, logger, df):
        self.logger = logger
        self.df = None
        self.df_result = None

    def scrap_article(self, row):
        index, row_content = row
        text = ""
        try:
            url = row_content['web_sp_link']
            with requests.Session().get(url, timeout=5) as response:
                self.logger.info('{}. Processing url: {}\n'.format(index ,url))

                article = nwp.Article(url)
                article.html = response.text
                article.download_state = 2
                article.parse()
                
                text = article.text
        except Exception as e:
            self.logger.error("Processing failed for url: {}\n".format(url))
            raise
            
        return text

    def scrap_parallel(self, df):
        num_cores = mp.cpu_count()

        scraped_articles = []
        rows = df.iterrows()
        with concurrent.futures.ThreadPoolExecutor(max_workers=num_cores) as executor:
            scraped_articles = [row for row in executor.map(self.scrap_article, rows)]
        
        self.scraped_articles = scraped_articles
        self.logger.info("Finished processing urls")

        return results

    def save_results(self):
        df_result = self.df.reset_index(drop=True)
        
        s1 = pd.Series(name='text_scraped', data=self.scraped_articles)
        
        df_result = pd.concat([df_result, s1], axis=1)
        
        self.logger.info("Merged results to dataframe.")
        self.df_result = df_result

        return df_result

    def save_state(self, path):
        helper = file_helper(self.logger)
        class_name = 'scraper'

        if self.scraped_articles is not None: helper.save_state(class_name, 'scraped_articles', self.scraped_articles, file_helper.VarType.OBJECT)

        path = 'data/{}/{}-{}.csv'.format(datetime.now().strftime(path, path, "%m-%d-%Y-%H-%M-%S"))
        if self.df_result is not None: 
            helper.save_df_to_csv(self.df_result, path)
            helper.save_state(class_name, 'df_result', self.df_result, file_helper.VarType.DATAFRAME)



    def build(self, load_path='data/01_crawl_urls', save_path='data\02_scrap_articles'):
        helper = file_helper(self.logger)
        
        if self.df is None: self.df=helper.load_df_from_csv(load_path)
        
        try:
            if self.scraped_articles is None: self.scrap_parallel(self.df)
            if self.df_result is None: self.save_results()
        except:
            exc_type, exc_value, exc_traceback = sys.exc_info()
            self.logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
            raise
        finally:
            self.logger.info("Saving state...")
            self.save_state(save_path)

        return self
        
        
