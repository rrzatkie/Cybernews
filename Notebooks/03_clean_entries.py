# To add a new cell, type '#%%'
# To add a new markdown cell, type '#%% [markdown]'

#%%
import pandas as pd
import os
import re
from datetime import datetime

def get_newest_file(fn_list):
    dates = []
    for f in fn_list:
        match = re.search("([0-9]{2}-[0-9]{2}-[0-9]{4}-[0-9]{2}-[0-9]{2}-[0-9]{2})", f)
        if(match is not None):
            dates.append({'fileName': f, 'date': match.group()})
    
    dates = list(map(lambda x: {'fileName': x['fileName'], 'date': datetime.strptime(x['date'], "%m-%d-%Y-%H-%M-%S")}, dates))

    dates.sort(key=lambda x: x['date'], reverse=True)

    return dates[0]['fileName']

fn_list = os.listdir("data/after-scraping")

fn_newest = get_newest_file(fn_list)

f = open("data/after-scraping/{}".format(fn_newest), 'r', encoding="utf-8")
df = pd.read_csv(f, index_col=0)
f.close()

# Remove NaN values (articles that failed to download)
df = df[df.text_scraped.isna()==False]

problematic_links = ['http://www.cio-today.com','http://www.toptechnews.com', 'http://www.sci-tech-today', 'http://www.newsfactor', 'http://www.enterprise-security-today', 'https://www.bna', 'http://www.bna', 'https://twitter', 'http://time']
for link in problematic_links:
    df = df.loc[df['web_sp_link'].str.contains(link)==False]

df = df.drop_duplicates(subset=['text_scraped'], keep='first')
    
# Convert to words arrays
df['text_scraped_words'] = [text.split(" ") for text in df.text_scraped.values]

# Count words
df['text_scraped_words_count'] = df.text_scraped_words.str.len()

df = df[df.text_scraped_words_count>200 ]
df = df[df.text_scraped_words_count<1500 ]

# Save results to file 
file_name = r'data\after-cleaning\after-cleaning-{}.csv'.format(datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
f = open(file_name, 'w', encoding="utf-8")
df.to_csv(path_or_buf=f)
f.close()


#%%
import plotly.express as px

fig = px.histogram(df_to_plot, x="text_scraped_words_count")
fig.show()


#%%
def get_problematic_links_by_article_id(id):
    results = []
    try:
        text = df.loc[id].text_scraped
        results = list(pd.Series([el.split(".com")[0] for el in df[df.text_scraped == text].web_sp_link.values]).drop_duplicates())
    except KeyError as ke:
        print("Row not found!")
    finally:
        return results

get_problematic_links_by_article_id(19935)

# id = 19935
# (df.loc[id].web_sp_link, df.loc[id].text_scraped) 


#%%




