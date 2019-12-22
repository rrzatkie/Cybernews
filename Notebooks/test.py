import multiprocessing as mp
import time

import pandas as pd
import os
import re
from datetime import datetime

from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.naive_bayes import GaussianNB

from nltk.tokenize import word_tokenize
from nltk.probability import FreqDist

from nltk.stem import WordNetLemmatizer

from sklearn.feature_extraction import text
import string

from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score
from sklearn.metrics import precision_score
from sklearn.metrics import recall_score

import multiprocessing as mp
import time

from concurrent import futures

worker_X = None
worker_Y = None
worker_min_df = None
worker_max_df = None
worker_stop_words = None

def worker_init(X,Y,min_df,max_df,stop_words):
    global worker_X
    global worker_Y 
    global worker_min_df
    global worker_max_df
    global worker_stop_words
    
    worker_X = X
    worker_Y = Y
    worker_min_df = min_df
    worker_max_df = max_df
    worker_stop_words = stop_words

def worker(max_features):
    global worker_X
    global worker_Y 
    global worker_min_df
    global worker_max_df
    global worker_stop_words
    
    start_time = time.time()
    
    tfidf_vectorizer = TfidfVectorizer(max_features=max_features, stop_words=worker_stop_words, min_df=worker_min_df, max_df=worker_max_df, ngram_range=(1,3))

    feature_vector = tfidf_vectorizer.fit_transform(worker_X)
    fill_ratio = feature_vector.nnz/(feature_vector.shape[0]*feature_vector.shape[1])
    X_dense = feature_vector.todense()
       

    x_train, x_test, y_train, y_test = train_test_split(X_dense, worker_Y, test_size = 0.2)
    clf = GaussianNB().fit(x_train, y_train)
    y_pred = clf.predict(x_test)
    acc, num_acc, prec, recall = summarize_classification(y_test, y_pred)
    
    elapsed_time = time.time()-start_time
    
    stats_row = {}
    stats_row['min_df'] = worker_min_df
    stats_row['max_df'] = worker_max_df
    stats_row['max_features'] = max_features
    stats_row['fill_ratio'] = fill_ratio
    stats_row['acc'] = acc
    stats_row['acc_count'] = num_acc
    stats_row['prec'] = prec
    stats_row['recall'] = recall
    stats_row['elapsed_time'] = elapsed_time
    
    return stats_row

def summarize_classification(y_test, y_pred):

    acc = accuracy_score(y_test, y_pred, normalize=True)
    num_acc = accuracy_score(y_test, y_pred, normalize=False)
    prec = precision_score(y_test, y_pred, average='weighted')
    recall = recall_score(y_test, y_pred, average='weighted')
    
    return acc, num_acc, prec, recall

def main(df):
    df = df[['category', 'text_scraped', 'text_scraped_words_count', 'text_lemmatized']]
    
    df_filtered = pd.DataFrame(columns=['text_scraped', 'category', 'text_scraped_words_count'])
    
    for item in df.category.value_counts().items():
        if(item[1] > 1000):
            df_filtered = df_filtered.append(df[df.category.str.contains(item[0])][0:1000][['text_lemmatized', 'category']])
    df = df_filtered
    
    wnl = WordNetLemmatizer()
    X = [" ".join([wnl.lemmatize(token) for token in text]) for text in df.text_lemmatized]
    Y = df.category 
    
    stop_words = text.ENGLISH_STOP_WORDS.union(string.punctuation)
    
    min_df_steps = range(1,17,1)
    max_df_steps = range(1000, 4200, 200)
    max_features_steps = range(100, 1060, 60)

    test_stats = pd.DataFrame(columns=['min_df', 'max_df', 'max_features', 'fill_ratio', 'acc', 'acc_count', 'prec', 'recall', 'elapsed_time'])

    num_cores = 4
    stats = []
    i=0
    for min_df in min_df_steps:
        for max_df in max_df_steps:        
            inputs = [x for x in max_features_steps]
            with futures.ProcessPoolExecutor(max_workers=num_cores, initializer=worker_init, initargs=[X,Y,min_df,max_df,stop_words]) as pool:
                rows = [row for row in pool.map(worker, inputs)]
                stats.extend(rows)

    test_stats = test_stats.append(stats)
    file_name = r'data\{}-stats.csv'.format(datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
    f = open(file_name, 'w', encoding="utf-8")
    test_stats.to_csv(path_or_buf=f)
    f.close()

def get_newest_file(fn_list):
    dates = []
    for f in fn_list:
        match = re.search("([0-9]{2}-[0-9]{2}-[0-9]{4}-[0-9]{2}-[0-9]{2}-[0-9]{2})", f)
        if(match is not None):
            dates.append({'fileName': f, 'date': match.group()})
    
    dates = list(map(lambda x: {'fileName': x['fileName'], 'date': datetime.strptime(x['date'], "%m-%d-%Y-%H-%M-%S")}, dates))
    dates.sort(key=lambda x: x['date'], reverse=True)
    return dates[0]['fileName']

if __name__ == '__main__':
    fn_list = os.listdir("data/after-nlp-pipeline")
    fn_newest = get_newest_file(fn_list)

    f = open("data/after-nlp-pipeline/{}".format(fn_newest), 'r', encoding="utf-8")
    df = pd.read_csv(f, index_col=0, converters={'text_scraped_words': lambda x: x[1:-1].replace("'", "").split(', '),'text_lemmatized': lambda x: x[1:-1].replace("'", "").split(', ') })
    f.close()
    
    print("Successfully imported file: {}".format(fn_newest))
    
    main(df)

