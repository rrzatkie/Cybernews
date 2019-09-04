# To add a new cell, type '#%%'
# To add a new markdown cell, type '#%% [markdown]'

#%%
import pandas as pd
import os
import re
from datetime import datetime

fn_list = os.listdir("data")


#after-scraping-08-29-2019-01-15-09.csv
dates = list(map(lambda x: {'fileName': x, 'date': re.search("([0-9]{2}\-[0-9]{2}\-[0-9]{4}-[0-9]{2}-[0-9]{2}-[0-9]{2})", x).group()}, fn_list)) 
dates = list(map(lambda x: {'fileName': x['fileName'], 'date': datetime.strptime(x['date'], "%m-%d-%Y-%H-%M-%S")}, dates))
dates.sort(key=lambda x: x['date'], reverse=True)

fn_newest = dates[0]['fileName']

f = open("data/{}".format(fn_newest), 'r', encoding="utf-8")
df = pd.read_csv(f, index_col=0)
f.close()


#%%
import chart_studio

chart_studio.tools.set_credentials_file(username='rrzatkie', api_key='05fsycucmo')
df_hist = df['text_scraped'].str.len()

df['text_scraped'].str.len().iplot(kind='histogram', filename='cufflinks/basic-histogram')


#%%
df_nan = df[df.text_scraped.isna() | df.text_scraped.isnull()]


#%%
def split_to_words(text):
    return [word for word in text.split(" ")]

df['text_scraped_words'] = list(map(split_to_words, list(df.text_scraped.values)))


#%%
words = [word for word in df.text_scraped.values[0].split(" ")]


#%%
df_nan


#%%
df_new = pd.DataFrame(df['text_scraped'].str.len())


#%%
df_new.columns = ['text_scraped_word_count']
