# To add a new cell, type '#%%'
# To add a new markdown cell, type '#%% [markdown]'
#%%
from IPython import get_ipython


#%%

import requests, json
import newspaper
import multiprocessing
from joblib import Parallel, delayed
import datetime
from tqdm import tqdm

method = 'POST'
url = 'https://api.cyware.com/public/cyuserallstory/'
raw_headers = "User-Agent:PostmanRuntime/7.13.0\nAccept:*/*\nCache-Control:no-cache\nPostman-Token:4ae3e87e-7195-4654-9bd9-ebe230359fb7\ncookie:2fa_sessionid=fkk1a2qxxh0bc5cuxjmafezqjcjfgx6y\ncontent-length:0\nConnection:close\nHost:api.cyware.com"

headers = dict([[h.partition(':')[0], h.partition(':')[2]] for h in raw_headers.split('\n')])
url = "https://api.cyware.com/public/cyuserallstory/"

response = requests.request("POST", url, headers=headers)
    


#%%y
json_content = json.loads(response.text)
columns = list(json_content['results'][0].keys())
next_link = json_content['links']['next']
cur_count = json_content['count']

articles_api = []
for result in json_content['results']:
    row = []
    for column in columns:
        row.append(result[column])
    articles_api.append(row)

total = int(cur_count)
with tqdm(total=total) as pbar:
    while(cur_count != 0):
        url = next_link
        response = requests.request("POST", url, headers=headers)
        json_content = json.loads(response.text)
        next_link = json_content['links']['next']
        cur_count = json_content['count']
        for result in json_content['results']:
            row = []
            for column in columns:
                row.append(result[column])
            articles_api.append(row)
        pbar.update(len(json_content['results']))