import sys
from datetime import datetime

import pandas as pd
import json
from requests import request

from pipeline.helpers.file_helper import file_helper

class crawler:
    def __init__(self, logger, helper):
        self.logger = logger
        self.helper = helper

        self.df_result = None
        self.columns = None
        self.cyware_entries = None

    def cyware_headers(self):
        raw_headers = "User-Agent:PostmanRuntime/7.13.0\nAccept:*/*\nCache-Control:no-cache\nPostman-Token:4ae3e87e-7195-4654-9bd9-ebe230359fb7\ncookie:2fa_sessionid=fkk1a2qxxh0bc5cuxjmafezqjcjfgx6y\ncontent-length:0\nConnection:close\nHost:api.cyware.com"
        headers = dict([[h.partition(':')[0], h.partition(':')[2]] for h in raw_headers.split('\n')])

        return headers

    def cyware_parse_response(self, response):
        json_content = json.loads(response.text)
        columns = list(json_content['results'][0].keys())
        next_link = json_content['links']['next']

        return json_content, next_link, columns

    def crawl_cyware(self, url):
        self.logger.info("Started crawling 'Cyware' api")
        entries_api = []
        columns = []

        count = 0
        while(url != None):
            response = request("POST", url, headers=self.cyware_headers())
            json_content, next_link, columns = self.cyware_parse_response(response)
            
            entries_api.extend(
                [
                    [entry[column] for column in columns]
                    for entry in json_content['results']
                ]
            )
            url = next_link
            
            count+=len(json_content['results'])
            self.logger.info("Processed {} entries".format(count))

            self.columns = columns
            self.cyware_entries = entries_api

        return entries_api
    
    def merge_results(self):
        df_result = pd.DataFrame(columns=self.columns, data=self.cyware_entries)

        self.logger.info("Merged results to dataframe.")
        self.df_result = df_result

        return df_result
    
    def load_state(self, helper):
        self.logger.info("Try to load state...")
        
        class_name = 'crawler'
        
        self.cyware_entries = helper.load_state(class_name, 'cyware_entries', file_helper.VarType.OBJECT)
        self.columns = helper.load_state(class_name, 'columns', file_helper.VarType.OBJECT)

    def save_state(self, path, helper):
        class_name = 'crawler'
        
        if self.cyware_entries is not None: helper.save_state(class_name, 'cyware_entries', self.cyware_entries, file_helper.VarType.OBJECT)
        if self.columns is not None: helper.save_state(class_name, 'columns', self.columns, file_helper.VarType.OBJECT)

        path = '{}/{}-{}.csv'.format(path, path, datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
        if self.df_result is not None: 
            helper.save_df_to_csv(self.df_result, path)
            helper.save_state(class_name, 'df_result', self.df_result, file_helper.VarType.DATAFRAME)

    def build(self, save_path='01_crawl_urls'):
        helper = self.helper

        try:
            self.load_state(helper)

            if self.cyware_entries is None: self.crawl_cyware('https://api.cyware.com/public/cyuserallstory/')
            if self.df_result is None: self.merge_results()
        except:
            exc_type, exc_value, exc_traceback = sys.exc_info()
            self.logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
            raise
        finally:
            self.logger.info("Saving state...")
            self.save_state(save_path, helper)