import json
from requests import request

import pandas as pd

from shared.file_helper import file_helper

class crawler:
    def __init__(self, logger):
        self.logger = logger

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
        cur_count = json_content['count']

        return json_content, next_link, cur_count, columns

    def crawl_cyware(self, url):
        entries_api = []
        columns = []

        cur_count = 1
        while(cur_count != 0):
            response = request("POST", url, headers=self.cyware_headers())
            json_content, next_link, cur_count, columns = self.cyware_parse_response(response)
            
            entries_api.extend(
                [
                    [entry[column] for column in columns]
                    for entry in json_content['results']
                ]
            )

        self.columns = columns
        self.cyware_entries = entries_api

        return entries_api
    
    def save_results(self):
        df_result = pd.DataFrame(columns=self.columns, data=self.cyware_entries)

        self.logger.info("Merged results to dataframe.")
        self.df_result = df_result

        return df_result

    def save_state(self, path):
        helper = file_helper(self.logger)
        class_name = 'crawler'
        
        if self.cyware_entries is not None: helper.save_state(class_name, 'cyware_entries', self.cyware_entries, file_helper.VarType.OBJECT)


    def build(self, save_path='data\01_crawl_urls'):
        try:
            self.crawl_cyware('https://api.cyware.com/public/cyuserallstory/')
            if self.df_result is None: self.save_results()
        except:
            exc_type, exc_value, exc_traceback = sys.exc_info()
            self.logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
            raise
        finally:
            self.logger.info("Saving state...")
            self.save_state(save_path)