from math import ceil

import tensorflow as tf

import keras
from keras import backend as K
from keras.models import Sequential
from keras.layers import Dense, Dropout, Activation
from keras.optimizers import SGD, Adam
from matplotlib import pyplot
from keras.callbacks import EarlyStopping
from keras.layers import LeakyReLU

from sklearn.preprocessing import LabelBinarizer
from sklearn.model_selection import train_test_split
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.metrics import confusion_matrix

import pandas as pd
import numpy as np
from gensim import matutils

from shared.file_helper import file_helper

class classification:
    def __init__(self, logger, seed=100):
        self.logger = logger
        self.seed = seed

        self.df = None
        self.labels_count = None
        self.gensim_dictionary = None
        self.gensim_corpus_tfidf = None

        self.x_train_bow = None
        self.x_train_vec = None
        self.y_train = None
        self.x_test_bow = None
        self.x_test_vec = None
        self.y_test = None
        self.x_val_bow = None
        self.x_val_vec = None
        self.y_val = None
        
    
    def recall_m(self, y_true, y_pred):
        true_positives = K.sum(K.round(K.clip(y_true * y_pred, 0, 1)))
        possible_positives = K.sum(K.round(K.clip(y_true, 0, 1)))
        recall = true_positives / (possible_positives + K.epsilon())
        return recall

    def precision_m(self, y_true, y_pred):
        true_positives = K.sum(K.round(K.clip(y_true * y_pred, 0, 1)))
        predicted_positives = K.sum(K.round(K.clip(y_pred, 0, 1)))
        precision = true_positives / (predicted_positives + K.epsilon())
        return precision

    def f1_m(self, y_true, y_pred):
        precision = self.precision_m(y_true, y_pred)
        recall = self.recall_m(y_true, y_pred)
        return 2*((precision*recall)/(precision+recall+K.epsilon()))

    def plot_history(self, history):
        pyplot.plot(history.history['loss'], label='train')
        pyplot.plot(history.history['val_loss'], label='valid')
        pyplot.legend()
        pyplot.show()

    def split_data(self, df, ratio_train, ratio_test, ratio_val, seed):
        assert ratio_train + ratio_test + ratio_val == 1

        count = len(df.values)
        df_copy = df.copy()

        train = df_copy.groupby('category_slug', group_keys=False).apply(
            lambda x: x.sample(
                n=int((count*ratio_train)/self.labels_count),
                random_state=seed
            )
        )
        df_copy = df_copy.drop(train.index)
        
        test = df_copy.groupby('category_slug', group_keys=False).apply(
            lambda x: x.sample(
                n=int((count*ratio_test)/self.labels_count), 
                random_state=seed
            )
        )
        df_copy = df_copy.drop(test.index)

        val = df_copy.groupby('category_slug').apply(
            lambda x: x.sample(
                n=int((count*ratio_val)/self.labels_count), 
                random_state=seed
            )
        )

        encoder = LabelBinarizer().fit(df.category_id)
        vocabulary_size = len(self.gensim_dictionary)

        self.x_train_bow = np.array([
            matutils.sparse2full(row.corpus_tfidf_gensim, vocabulary_size)
            for index, row in train.iterrows()
        ])

        self.x_test_bow = np.array([
            matutils.sparse2full(row.corpus_tfidf_gensim, vocabulary_size)
            for index, row in test.iterrows()
        ])
        
        self.x_val_bow = np.array([
            matutils.sparse2full(row.corpus_tfidf_gensim, vocabulary_size)
            for index, row in val.iterrows()
        ])

        self.x_train_vec = np.array(list(train.corpus_w2v_gensim))
        self.x_test_vec = np.array(list(test.corpus_w2v_gensim))
        self.x_val_vec = np.array(list(val.corpus_w2v_gensim))

        self.y_train = encoder.transform(train.category_id)
        self.y_test = encoder.transform(test.category_id)
        self.y_val = encoder.transform(val.category_id)

        return train, test, val

    def preprocess(self, df, min_sample_count, seed):
        # Filter categories that are not fully represented
        categories_count = df.groupby(['category_slug'], sort=False).size()
        categories = categories_count[categories_count >= min_sample_count].index
        df = df[df.category_slug.isin(categories)]

        self.logger.info("Models will be trained with {} categories: [{}], because they are fully represented".format(categories.shape[0]," ".join(list(categories))))

        # Take equal number of rows per category
        df = df.groupby('category_slug').apply(lambda x: x.sample(n=min_sample_count, random_state=seed)).reset_index(drop=True)

        self.labels_count = len(categories)
        self.df = df

        return df

    def keras_mlp(self, x_train, y_train, x_test, y_test, x_val, y_val, input_size, output_size, seed):
        batch_size = 128
        hidden_units = ceil(1.5 * input_size)
        dropout = 0.45

        model = Sequential()
        model.add(Dense(hidden_units, activation='relu', input_dim=input_size))
        model.add(Dropout(dropout))
        model.add(Dense(output_size, activation='softmax'))

        # optimizer_adam = Adam(learning_rate=0.0015)
        optimizer_sgd = SGD(lr=0.008, decay=1e-6, momentum=0.9, nesterov=True)

        model.compile(
            loss='categorical_crossentropy',
            optimizer=optimizer_sgd,
            metrics=['accuracy', self.f1_m, self.precision_m, self.precision_m]
        )

        es = EarlyStopping(monitor='val_accuracy', mode='max', verbose=1, patience=100)

        history = model.fit(
            x_train,
            y_train,
            epochs=1000,
            batch_size=batch_size,
            validation_data=(x_val, y_val),
            
            verbose=1, 
            callbacks=[es]
        )

        results = model.evaluate(
            x_test,
            y_test, 
            verbose=1
        )
        
        self.plot_history(history)
        self.logger.info("Evaluation: accuracy -> {} %".format(100*results[1]))

        # y_pred = model.predict(x_test)
        # confusion_matrix(encoder.inverse_transform(y_test), encoder.inverse_transform(y_pred)) 

        return model

    def save_state(self):
        pass

    def load_state(self, helper):
        class_name = 'nlp'

        self.df = helper.load_state(class_name, 'df_result', file_helper.VarType.DATAFRAME)
        self.gensim_dictionary = helper.load_state(class_name, 'gensim_dictionary', file_helper.VarType.OBJECT)
        self.gensim_corpus_tfidf = helper.load_state(class_name, 'gensim_corpus_tfidf', file_helper.VarType.OBJECT)

    def build(self, load_path='data/04_nlp_pipeline', save_path=''):
        helper = file_helper(self.logger)

        self.load_state(helper)

        if self.df is None: self.df=helper.load_df_from_csv(load_path)
        
        
        self.preprocess(self.df, min_sample_count=1100, seed=self.seed)
        self.split_data(self.df, 0.5, 0.25, 0.25, seed=self.seed)
        self.keras_mlp(self.x_train_bow, self.y_train, self.x_test_bow, self.y_test, self.x_val_bow, self.y_val, len(self.gensim_dictionary), self.seed)
        self.keras_mlp(self.x_train_vec, self.y_train, self.x_test_vec, self.y_test, self.x_val_vec, self.y_val, 300, self.seed)

if __name__=='__main__':
    c = classification()
    c.build()