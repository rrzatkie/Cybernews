# To add a new cell, type '#%%'
# To add a new markdown cell, type '#%% [markdown]'


#%% Change working directory from the workspace root to the ipynb file location. Turn this addition off with the DataScience.changeDirOnImportExport setting
# ms-python.python added
import os
try:
	os.chdir(os.path.join(os.getcwd(), 'Notebooks'))
	print(os.getcwd())
except:
	pass


#%%
import pandas as pd
import os
import re
from datetime import datetime

fn_list = os.listdir("data/after-cleaning")

#after-scraping-08-29-2019-01-15-09.csv
dates = list(map(lambda x: {'fileName': x, 'date': re.search("([0-9]{2}\-[0-9]{2}\-[0-9]{4}-[0-9]{2}-[0-9]{2}-[0-9]{2})", x).group()}, fn_list)) 
dates = list(map(lambda x: {'fileName': x['fileName'], 'date': datetime.strptime(x['date'], "%m-%d-%Y-%H-%M-%S")}, dates))
dates.sort(key=lambda x: x['date'], reverse=True)

fn_newest = dates[0]['fileName']

f = open("data/after-cleaning/{}".format(fn_newest), 'r', encoding="utf-8")
df = pd.read_csv(f, index_col=0, converters={'text_scraped_words': lambda x: x[1:-1].replace("'", "").split(', ')})
f.close()

print("Successfully imported file: {}".format(fn_newest)) 


#%%
df.text_scraped_words.values[0]


#%%
import spacy

result = []
nlp = spacy.load("en_core_web_md")
# pipeline = ["tagger", "parser", "ner", "textcat"]

# Add text categorization pipe
component = nlp.create_pipe("textcat")
nlp.add_pipe(component)

df_test = df[0:3]


#%%

docs = nlp.pipe(df.text_scraped.values)
for doc in docs:
	print(doc.text)


#%%
