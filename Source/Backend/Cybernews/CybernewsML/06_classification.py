# %%
import pandas
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

if __name__ == '__main__':
    fn_list = os.listdir('/home/rrzatkie/Work/Cybernews/Source/Backend/Cybernews/Cybernews.ML/data/after-nlp-pipeline')
    fn_newest = get_newest_file(fn_list)

    f = open('/home/rrzatkie/Work/Cybernews/Source/Backend/Cybernews/Cybernews.ML/data/after-nlp-pipeline/{}'.format(fn_newest), 'r', encoding="utf-8")
    df = pandas.read_csv(f, index_col=0, converters={'text_scraped_words': lambda x: x[1:-1].replace("'", "").split(', '),'text_lemmatized': lambda x: x[1:-1].replace("'", "").split(', ') })
    f.close()

    print("Successfully imported file: {}".format(fn_newest))



# %%
samples_min_count = 1000
categories_count = df.groupby(['category_slug'], sort=False).size().reset_index(name='count')
samples_categories = categories_count.category_slug[categories_count['count'] > samples_min_count].values
df = df.loc[df.category_slug.isin(samples_categories)]
samples = df.groupby('category_slug').apply(lambda x: x.sample(n=samples_min_count)).reset_index(drop=True)
samples.category_slug.value_counts()

# %%
df['text_lemmatized'] = [" ".join(words) for words in df.text_lemmatized.values]



# %%
from sklearn.feature_extraction.text import TfidfVectorizer
vectorizer = TfidfVectorizer()
data_vectorized = vectorizer.fit_transform(df.text_lemmatized.values)


# # %%
# samples['title_lemmatized'] = [" ".join(words) for words in df.title_lemmatized.values]





# %%
data_vectorized


# %%
from sklearn.preprocessing import LabelBinarizer
from sklearn.model_selection import train_test_split

encoder = LabelBinarizer()
transfomed_label = encoder.fit_transform(df.category_id.values)

data_vectorized = data_vectorized.todense()
x_train = data_vectorized[0::2,:]
x_test = data_vectorized[1::4,:]
x_valid = data_vectorized[3::4,:]
y_train = transfomed_label[0::2,:]
y_test = transfomed_label[1::4,:]
y_valid = transfomed_label[3::4,:]


# %%
from keras import backend as K

def recall_m(y_true, y_pred):
        true_positives = K.sum(K.round(K.clip(y_true * y_pred, 0, 1)))
        possible_positives = K.sum(K.round(K.clip(y_true, 0, 1)))
        recall = true_positives / (possible_positives + K.epsilon())
        return recall

def precision_m(y_true, y_pred):
        true_positives = K.sum(K.round(K.clip(y_true * y_pred, 0, 1)))
        predicted_positives = K.sum(K.round(K.clip(y_pred, 0, 1)))
        precision = true_positives / (predicted_positives + K.epsilon())
        return precision

def f1_m(y_true, y_pred):
    precision = precision_m(y_true, y_pred)
    recall = recall_m(y_true, y_pred)
    return 2*((precision*recall)/(precision+recall+K.epsilon()))


# %%
import keras
from keras.models import Sequential
from keras.layers import Dense, Dropout, Activation
from keras.optimizers import SGD
from matplotlib import pyplot
from keras.callbacks import EarlyStopping
from keras.layers import LeakyReLU

import tensorflow as tf
sess = tf.Session(config=tf.ConfigProto(log_device_placement=True))

model = Sequential()
model.add(Dense(64, activation='relu', input_dim=data_vectorized.shape[1], use_bias=True, ))
model.add(Dropout(0.5))
model.add(Dense(64, activation='relu', input_dim=data_vectorized.shape[1], use_bias=True, ))
model.add(Dense(transfomed_label.shape[1], activation='softmax', use_bias=True))

sgd = SGD(lr=0.008, decay=1e-6, momentum=0.9, nesterov=True)
model.compile(loss='categorical_crossentropy',
              optimizer=sgd,
              metrics=['accuracy', f1_m, precision_m, recall_m])

es = EarlyStopping(monitor='val_loss', mode='min', verbose=1)
history = model.fit(x_train, y_train, validation_data=(x_valid, y_valid), epochs=50, verbose=1, callbacks=[es])

# evaluate the model
_, train_acc, f,p,r = model.evaluate(x_train, y_train, verbose=0)
_, valid_acc, f,p,r = model.evaluate(x_valid, y_valid, verbose=0)
print('Train: %.3f, Test: %.3f' % (train_acc, valid_acc))
# plot training history
pyplot.plot(history.history['loss'], label='train')
pyplot.plot(history.history['val_loss'], label='valid')
pyplot.legend()
pyplot.show()
score = model.evaluate(x_test, y_test, batch_size=128)
score


# %%
y_pred = model.predict(x_test)


# %%
from sklearn.metrics import confusion_matrix

confusion_matrix(encoder.inverse_transform(y_test), encoder.inverse_transform(y_pred))

