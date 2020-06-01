# To add a new cell, type '#%%'
# To add a new markdown cell, type '#%% [markdown]'
#%% Change working directory from the workspace root to the ipynb file location. Turn this addition off with the DataScience.changeDirOnImportExport setting
# ms-python.python added
import os
try:
	os.chdir(os.path.join(os.getcwd(), 'Notebooks\\old'))
	print(os.getcwd())
except:
	pass
#%%
from IPython import get_ipython


#%%
#Link to tutorial: https://www.kaggle.com/vukglisovic/classification-combining-lda-and-word2vec


#%%
# more common imports
import pandas as pd
import numpy as np
import re
import sys

# languange processing imports
import nltk


#%%
# raw_data = pd.read_csv('./entries-cyware-api-2-cleaned.csv', index_col=0)
f = open('entries-lemmatized.csv', 'r')
train_data = pd.read_csv(f, index_col=0, converters={'text_lemmatized': lambda x: x[1:-1].replace("'", "").split(', ')})
f.close()


#%%
train_data=raw_data[raw_data['isnull'] == False]
train_data['num_of_words']=list(map(len, train_data.text.str.split(' ')))
train_data=train_data[(train_data.num_of_words > 100) & (train_data.num_of_words < 3000)]


#%%
train_data


#%%
document_lengths = np.array(list(map(len, train_data.text.str.split(' '))))

print("The average number of words in a document is: {}.".format(np.mean(document_lengths)))
print("The minimum number of words in a document is: {}.".format(min(document_lengths)))
print("The maximum number of words in a document is: {}.".format(max(document_lengths)))


#%%
fig, ax = plt.subplots(figsize=(15,6))

ax.set_title("Distribution of number of words", fontsize=16)
ax.set_xlabel("Number of words")
sns.distplot(document_lengths, bins=50, ax=ax);


#%%
from tqdm import tqdm
import multiprocessing
from joblib import Parallel, delayed

our_special_word = 'qwerty'


def containsNonAscii(word):
    return any(ord(i)>127 for i in word)

def remove_nonascii_words(text):
    words = "".join(text.split('.')).split(' ')
    cleaned_words = [word for word in words if  not containsNonAscii(word)]
#     pbar.update(1)
    return ' '.join(cleaned_words)

inputs = train_data.text.values
# pbar = tqdm(total=len(inputs))
rows = Parallel(n_jobs=2)(delayed(remove_nonascii_words)(i) for i in inputs)
train_data['text_nonascii_removed'] = rows


#%%
def remove_stopwords(doc):
    stopwords = nltk.corpus.stopwords.words('english')
    stopwords.append(our_special_word)
    return [word for word in doc if word not in stopwords]

def tokenize(doc):
    doc = nltk.word_tokenize(doc)
    return remove_stopwords(doc)

count = len(train_data.text_nonascii_removed.values)
texts_tokenized = []

num_cores = multiprocessing.cpu_count()

i=0
incr = 40

texts_part = train_data.text_nonascii_removed.values[i:i+incr]

with tqdm(total=count) as pbar:
    while(len(texts_tokenized) < count):
        inputs = texts_part
        rows = Parallel(n_jobs=num_cores)(delayed(tokenize)(i) for i in inputs)
        texts_tokenized.extend(rows)
        
        i += incr
        texts_part = train_data.text_nonascii_removed.values[i:i+incr]
        pbar.update(incr)
        
train_data['text_tokenized'] = texts_tokenized


#%%
import spacy, string
lang_model_name = 'en'
nlp = spacy.load(lang_model_name, disable=['ner'])


#%%



#%%
from tqdm import tqdm
import multiprocessing
from joblib import Parallel, delayed


def lemmatize(text_tokenized):
    punctuations = string.punctuation
    
    results = []
    docs = nlp.pipe([" ".join(x) for x in text_tokenized])
    for doc in docs:
        lemmas = []

        lemmas = [word.lemma_ if word.lemma_ not in['-PRON-', 'qwerty'] else '' 
                               for word in doc 
                               if(('caption' not in word.lemma_) &
                                      (word.pos_ in ['NOUN', 'PROPN']) &
                                      (word.is_punct == False))]
        print(lemmas)
        result = []
        for token in lemmas:
            if((token not in result) & (token not in punctuations) & (len(token) >= 3)):
                result.append(token)
        results.append(result) 
    return results
    
    
count = len(train_data.text_tokenized.values)
texts_lemmatized = []

num_cores = multiprocessing.cpu_count()

i=0
incr = 32

texts_parts = [train_data.text_tokenized.values[i:i+incr], train_data.text_tokenized.values[i+incr:i+(2*incr)]]

with tqdm(total=count) as pbar:
    pbar.update(i)
    while(len(texts_lemmatized) < (count)):
        inputs = texts_parts
        rows = Parallel(n_jobs=num_cores)(delayed(lemmatize)(i) for i in inputs)
        
        for rows_part in rows:
            texts_lemmatized.extend(rows_part)
        
        i += (2*incr)
        texts_parts = [train_data.text_tokenized.values[i:i+incr], train_data.text_tokenized.values[i+incr:i+(2*incr)] ]
        pbar.update(incr*len(rows))    
        


#%%
f = open('entries-lemmatized.csv', 'r')
train_data_lemmatized = pd.read_csv(f, index_col=0, converters={'text_lemmatized': lambda x: x[1:-1].replace("'", "").split(', ')})
f.close()


#%%
print(train_data.text_tokenized.values[-1])
print(train_data.text_lemmatized.values[-1])


#%%
f = open('entries-lemmatized.csv', "w")
train_data.to_csv(path_or_buf=f)
f.close()


#%%
bigram = Phrases(train_data.tokenized_text.values, min_count=5, threshold=100)

bigram_mod = Phraser(bigram)


def make_bigrams(texts):
    return [bigram_mod[doc] for doc in texts]

train_data['bigrams']= make_bigrams(train_data.stopwords_removed.values)


#%%
dictionary = Dictionary(documents=train_data.text_lemmatized.values)

print("Found {} words.".format(len(dictionary.values())))


#%%
dictionary.filter_extremes(no_above=0.8, no_below=3)

dictionary.compactify()  # Reindexes the remaining words after filtering
print("Left with {} words.".format(len(dictionary.values())))


#%%
def document_to_bow(df):
    df['bow'] = list(map(lambda doc: dictionary.doc2bow(doc), df.text_lemmatized))
    
document_to_bow(train_data)


#%%
cleansed_words_df = pd.DataFrame.from_dict(dictionary.token2id, orient='index')
cleansed_words_df.rename(columns={0: 'id'}, inplace=True)

cleansed_words_df['count'] = list(map(lambda id_: dictionary.dfs.get(id_), cleansed_words_df.id))
del cleansed_words_df['id']


#%%
cleansed_words_df.sort_values('count', ascending=False, inplace=True)


#%%
ax = word_frequency_barplot(cleansed_words_df)
ax.set_title("Document Frequencies (Number of documents a word appears in)", fontsize=16);


#%%
corpus = train_data.bow


#%%
get_ipython().run_cell_magic('time', '', "num_topics = 10\n#A multicore approach to decrease training time\nLDAmodel = LdaMulticore(corpus=corpus,\n                        id2word=dictionary,\n                        num_topics=num_topics,\n                        workers=4,\n                        chunksize=4000,\n                        passes=7,\n                        alpha='asymmetric')")


#%%
def document_to_lda_features(lda_model, document):
    """ Transforms a bag of words document to features.
        It returns the proportion of how much each topic was
        present in the document.
    """
    topic_importances = LDAmodel.get_document_topics(document, minimum_probability=0)
    topic_importances = np.array(topic_importances)
    return topic_importances[:,1]

train_data['lda_features'] = list(map(lambda doc: document_to_lda_features(LDAmodel, doc), train_data.bow))


#%%
len(LDAmodel.get_document_topics(train_data.bow))


#%%
def get_topic_top_words(lda_model, topic_id, nr_top_words=15):
    """ Returns the top words for topic_id from lda_model.
    """
    id_tuples = lda_model.get_topic_terms(topic_id, topn=nr_top_words)
    word_ids = np.array(id_tuples)[:,0]
    words = map(lambda id_: lda_model.id2word[id_], word_ids)
    return words


#%%
distribution = train_data['lda_features'].mean()

for x in sorted(np.argsort(distribution)[-15:]):
    top_words = get_topic_top_words(LDAmodel, x)
    print("\nFor topic {} :\n {}.".format(x, ",\n ".join(top_words)))
print("")


#%%
from sklearn.decomposition import NMF
from sklearn.feature_extraction.text import TfidfVectorizer


n_samples = 1000
n_features = 1000
n_topics = 37
n_top_words = 11


data = train_data.text_lemmatized.values
new_data = []

for doc in data:
    new_data.append(" ".join(doc))

data = new_data

vectorizer = TfidfVectorizer(
        analyzer='word',
        min_df=200,                        # minimum reqd occurences of a word
        lowercase=True,                   # convert all words to lowercase
        token_pattern='[a-zA-Z0-9]{4,}',  # num chars >= 4
        max_features=50000,             # max number of uniq words
    )
data_vectorized = vectorizer.fit_transform(data)

nmf = NMF(n_components=n_topics, random_state=1).fit(data_vectorized)

feature_names = vectorizer.get_feature_names()

for topic_idx, topic in enumerate(nmf.components_):
    print("Topic #%d:" % topic_idx)
    print(" ".join([feature_names[i]
                    for i in topic.argsort()[:-n_top_words - 1:-1]]))
    print()
    


#%%
# more common imports
import pandas as pd
import numpy as np
import re
import sys

# languange processing imports
import nltk

# raw_data = pd.read_csv('./entries-cyware-api-2-cleaned.csv', index_col=0)
f = open('entries-lemmatized.csv', 'r')
train_data = pd.read_csv(f, index_col=0, converters={'text_lemmatized': lambda x: x[1:-1].replace("'", "").split(', ')})
f.close()

train_data = train_data.reindex(np.random.permutation(train_data.index))


#%%
from sklearn.preprocessing import LabelEncoder


categories = train_data.category
encoder = LabelEncoder()

encoder.fit(categories)
categories_dict = { idx:c for idx, c in enumerate(encoder.classes_)}

categories_counts = train_data.categories_encoded.value_counts()
categories_counts_filtered_indexes = categories_counts[categories_counts > 1000].index
categories_counts_filtered_indexes


#%%
train_data = train_data.loc[train_data['categories_encoded'].isin(categories_counts_filtered_indexes)]


#%%
set_count = 1000
train_set = pd.DataFrame()

for c in categories_counts_filtered_indexes:
    temp = train_data.loc[train_data.categories_encoded == c][:set_count]
    train_set = train_set.append(temp)


#%%
X = train_set.drop(['text_tokenized', 'category', 'categories_encoded'], axis=1).text_lemmatized.values
Y = train_set.categories_encoded.values


#%%
new_encoder = LabelEncoder()
new_categories = Y

new_encoder.fit(new_categories)
new_categories_dict = { c:idx for idx, c in enumerate(new_encoder.classes_)}


#%%
for idx, c in enumerate(new_categories):
    new_categories[idx] = new_categories_dict[c]


#%%
Y = new_categories


#%%
from sklearn.feature_extraction.text import TfidfVectorizer

vectorizer = TfidfVectorizer(
        analyzer='word',
        lowercase=True,
        max_features=4000
    )

new_X = []

for doc in X:
    new_X.append(" ".join(doc))

X = new_X
X = vectorizer.fit_transform(X)


#%%
from sklearn.model_selection import train_test_split
import tensorflow as tf
import numpy

X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size=0.2, random_state=42)

# print(len(numpy.unique(numpy.array(Y_test))))
# # print(numpy.unique(numpy.array(Y_train)))

# print(len(numpy.bincount(numpy.array(Y_test))))
# # Y_train = tf.keras.utils.to_categorical(Y_train)
# # Y_test = tf.keras.utils.to_categorical(Y_test)


#%%
X_train


#%%
# SKLEARN CLASSIFIER
from sklearn.multiclass import OneVsOneClassifier
from sklearn.svm import LinearSVC
from sklearn import metrics


svclassifier = OneVsOneClassifier(LinearSVC(random_state=0), n_jobs=-1)
svclassifier.fit(X_train, Y_train)


Y_pred = svclassifier.predict(X_test)

print("Accuracy:",metrics.accuracy_score(Y_test, Y_pred))


#%%
#KERAS CLASIIFIER

import keras
from keras.models import Sequential
from keras.layers import Dense, Dropout, Activation
from keras.optimizers import SGD, Adam
import numpy as np

nof_categories = len(new_encoder.classes_)
nof_features = X_train.shape[1]

model = keras.Sequential([
    Dense(, activation='relu', input_dim=nof_features),
    Dense(64, activation='relu'),
    Dense(nof_categories, activation='softmax')
])

sgd = SGD(lr=0.0001, decay=2e-6, momentum=0.9, nesterov=False)
adam = Adam(lr=0.00005, beta_1=0.2, beta_2=0.999, epsilon=None, decay=2e-6, amsgrad=False)
model.compile(optimizer=adam,
              loss='sparse_categorical_crossentropy',
              metrics=['accuracy'])

history = model.fit(X_train, Y_train, epochs=80, batch_size=256)


#%%
score = model.evaluate(X_test, Y_test, batch_size=1)
print("Score: {}".format(score))


#%%
score = model.evaluate(X_train, Y_train, batch_size=32)
print("Score: {}".format(score))


#%%
keras.callbacks.History.on_batch_begin(model, model.batch()
                                )


#%%
X_test.shape


#%%
X_train.shape


#%%
Y_train.shape


#%%
type(Y_train)


#%%
Y_train[0]


#%%
X_train[0].nonzero()[0].shape


#%%
#do sprawdzenia bardziej recall i precision - zamiast accuracy
# overfitting
# SVM 
# croissanty i świeżo wyciskany sok dla Madzi


