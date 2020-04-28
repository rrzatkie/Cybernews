#%%
from os import path
import pickle



import pandas as pd
import cufflinks as cf
import plotly.offline as py

cf.go_offline()
cf.set_config_file(offline=True, world_readable=True)

# gensim #
from gensim import models
from gensim.test.utils import datapath

from shared.topic_model import topic_model
from shared.file_helper import file_helper
from shared.logger import logger_init


#%%
# if __name__ == '__main__':
logger = logger_init(path.basename(__file__))

lda = topic_model(logger).build()
logger.info("Successfully loaded LDA model.")

columns = ['categories_old_id', 'categories_old_slug', 'categories_lda']
df = pd.DataFrame(columns=columns)
df.categories_old_slug = lda.df.category_slug
df.categories_old_id = lda.df.category_id

categories_lda = []
for doc in lda.corpus_tfidf:
    categories_lda.append([cat[0] for cat in lda.lda_model.get_document_topics(doc, minimum_probability=0.333)])
df.categories_lda = categories_lda
logger.info("Copied LDA categories.")

df = df[df.categories_old_slug.notnull()]

#%%
title = 'Original categories histogram'
fig_old = df.groupby('categories_old_slug').count()['categories_old_id'].sort_values(ascending=True).iplot(
    kind='barh', 
    yTitle='Count',
    linecolor='black', 
    opacity=0.8, 
    title=title, 
    xTitle='category id',
    asFigure=True
)


#%%
lda_hist_values = {}
for topic_id in range(lda.lda_model.num_topics):
    lda_hist_values[topic_id] = 0

for id,row in df.iterrows():
    for topic_id in row.categories_lda:
        lda_hist_values[topic_id] += 1

df_lda = pd.DataFrame(columns=['CAT ID', 'COUNT'])
df_lda['CAT ID'] = list(lda_hist_values.keys())
df_lda['COUNT'] = list(lda_hist_values.values())


title = 'LDA categories histogram'
fig_lda = df_lda['COUNT'].sort_values(ascending=False).iplot(
    kind='bar', 
    yTitle='Count',
    linecolor='black', 
    opacity=0.8,
    title='LDA categories histogram', 
    xTitle='category id',
    asFigure=True
)



# %%
path = 'plots/topic_modeling/old_lda_histograms.html'

with open(path, 'w') as f:
    f.write(fig_old.to_html(full_html=False, include_plotlyjs='cdn'))
    f.write(fig_lda.to_html(full_html=False, include_plotlyjs='cdn'))

# %%
