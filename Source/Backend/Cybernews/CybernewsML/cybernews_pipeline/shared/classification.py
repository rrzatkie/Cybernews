import sys
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

import cufflinks as cf
import plotly.offline as py
import pandas as pd
import numpy as np
from gensim import matutils
from enum import Enum
from datetime import datetime

from cybernews_pipeline.shared.file_helper import file_helper

class ClassificationMode(Enum):
    BOW = 1
    W2V = 2

class metrics:
    def __init__(self):
        pass
    
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

class classification:
    def __init__(self, logger, seed=100):
        self.logger = logger
        self.seed = seed
        self.df = None
        self.df_result = None
        self.gensim_docs_vectors_w2v=None

        self.keras_mlp_bow = None
        self.keras_mlp_w2v = None
        self.keras_mlp_history = None
        self.categories_predicted_mlp = None

        self.x_train_bow = None
        self.x_train_w2v = None
        self.y_train = None
        self.x_test_bow = None
        self.x_test_w2v = None
        self.y_test = None
        self.x_val_bow = None
        self.x_val_w2v = None
        self.y_val = None

        self.labels_count = None
        self.labels_encoder = None

        cf.go_offline()
        cf.set_config_file(offline=True, world_readable=True)

    def plot_history(self, history, path, mode):
        path = 'plots/{}-{}.html'.format(path, mode.name)

        title = 'Train loss vs Validation loss'
        df = pd.DataFrame(columns=['train_loss', 'val_loss'])
        df.train_loss = history.history['loss']
        df.val_loss = history.history['val_loss']

        fig = df.iplot(asFigure=True)

        with open(path, 'w') as f:
            f.write(fig.to_html(full_html=False, include_plotlyjs='cdn'))

    def split_data(self, df, vocabulary_size, ratio_train, ratio_test, ratio_val, seed, mode):
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

        encoder = LabelBinarizer().fit(df.category_slug)
        if(mode == ClassificationMode.BOW):
            vocabulary_size = matutils.sparse2full
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

        if(mode == ClassificationMode.W2V):
            self.x_train_w2v = np.array(list(train.gensim_docs_vectors_w2v))
            self.x_test_w2v = np.array(list(test.gensim_docs_vectors_w2v))
            self.x_val_w2v = np.array(list(val.gensim_docs_vectors_w2v))

        self.y_train = encoder.transform(train.category_slug)
        self.y_test = encoder.transform(test.category_slug)
        self.y_val = encoder.transform(val.category_slug)

        self.labels_encoder = encoder

        return train, test, val

    def preprocess(self, df, min_sample_count, mode, seed):
        if(mode == ClassificationMode.BOW): df['corpus_tfidf_gensim'] = [doc_vector for doc_vector in self.gensim_corpus_tfidf]
        if(mode == ClassificationMode.W2V): df['gensim_docs_vectors_w2v'] = [doc_vector for doc_vector in self.gensim_docs_vectors_w2v]
        
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
    
    def predict_category(self, model, vector, encoder):
        self.logger.info("Predicting category for vector: [{}...{}]".format(vector[:2], vector[-3:]))
        y = model.predict(np.array([vector]))
        
        y_decoded = encoder.inverse_transform(y)[0]
        self.logger.info("Predicted category is: {}".format(y_decoded))

        return y_decoded

    def predict(self, model, x, encoder):
        self.logger.info("Predicting category for {} vectors".format(x.shape[0]))
        categories_predicted = []
        
        categories_predicted = np.array([self.predict_category(model, vector, encoder) for vector in x])

        self.categories_predicted_mlp = categories_predicted
        self.logger.info("Finished predicting categories")

        return categories_predicted

    def keras_mlp(self, x_train, y_train, x_test, y_test, x_val, y_val, input_size, output_size, seed, mode):
        batch_size = 128
        hidden_units = ceil(1.5 * input_size)
        dropout = 0.45

        model = Sequential()
        model.add(Dense(hidden_units, activation='relu', input_dim=input_size))
        model.add(Dropout(dropout))
        model.add(Dense(output_size, activation='softmax'))

        # optimizer_adam = Adam(learning_rate=0.0015)
        optimizer_sgd = SGD(lr=0.008, decay=1e-6, momentum=0.9, nesterov=True)
        
        m = metrics()
        model.compile(
            loss='categorical_crossentropy',
            optimizer=optimizer_sgd,
            metrics=['accuracy', m.f1_m, m.recall_m, m.precision_m]
        )

        es = EarlyStopping(monitor='val_accuracy', mode='max', verbose=1, patience=100)

        history = model.fit(
            x_train,
            y_train,
            epochs=1000,
            batch_size=batch_size,
            validation_data=(x_val, y_val),
            shuffle=True,
            verbose=1, 
            callbacks=[es]
        )

        results = model.evaluate(
            x_test,
            y_test, 
            verbose=1
        )
        
        self.keras_mlp_history = history
        self.logger.info("Evaluation: accuracy -> {} %".format(100*results[1]))

        # y_pred = model.predict(x_test)
        # confusion_matrix(encoder.inverse_transform(y_test), encoder.inverse_transform(y_pred)) 
        
        if(mode == ClassificationMode.BOW):
            self.keras_mlp_bow = model
        if(mode == ClassificationMode.W2V):
            self.keras_mlp_w2v = model
        self.logger.info("Finished training of MLP model")

        return model

    def merge_results(self, df, mode):
        df_result = df.copy()
        
        s1 = pd.Series(name='category_predicted_mlp{}'.format(mode.name), data=self.categories_predicted_mlp)

        df_result = pd.concat([df_result, s1], axis=1)

        self.df_result = df_result
        self.logger.info("Merged results to dataframe.")
        
        return df_result

    def save_state(self, mode, path):
        helper = file_helper(self.logger)
        class_name = 'classification'
        
        if self.df is not None: helper.save_state(class_name, 'df', self.df, file_helper.VarType.DATAFRAME)
        if self.keras_mlp_bow is not None: helper.save_state(class_name, 'keras_mlp_bow.h5', self.keras_mlp_bow, file_helper.VarType.KERAS_MODEL)
        if self.keras_mlp_w2v is not None: helper.save_state(class_name, 'keras_mlp_w2v.h5', self.keras_mlp_w2v, file_helper.VarType.KERAS_MODEL)    
        if self.keras_mlp_history is not None: helper.save_state(class_name, 'keras_mlp_history', self.keras_mlp_history, file_helper.VarType.OBJECT)    
        if self.x_test_bow is not None: helper.save_state(class_name, 'x_test_bow', self.x_test_bow, file_helper.VarType.OBJECT)    
        if self.x_test_w2v is not None: helper.save_state(class_name, 'x_test_w2v', self.x_test_w2v, file_helper.VarType.OBJECT)    
        if self.x_train_bow is not None: helper.save_state(class_name, 'x_train_bow', self.x_train_bow, file_helper.VarType.OBJECT)    
        if self.x_train_w2v is not None: helper.save_state(class_name, 'x_train_w2v', self.x_train_w2v, file_helper.VarType.OBJECT)    
        if self.x_val_bow is not None: helper.save_state(class_name, 'x_val_bow', self.x_val_bow, file_helper.VarType.OBJECT)    
        if self.x_val_w2v is not None: helper.save_state(class_name, 'x_val_w2v', self.x_val_w2v, file_helper.VarType.OBJECT)
        if self.y_test is not None: helper.save_state(class_name, 'y_test', self.y_test, file_helper.VarType.OBJECT)    
        if self.y_train is not None: helper.save_state(class_name, 'y_train', self.y_train, file_helper.VarType.OBJECT)    
        if self.y_val is not None: helper.save_state(class_name, 'y_val', self.y_val, file_helper.VarType.OBJECT)    
        if self.labels_encoder is not None: helper.save_state(class_name, 'labels_encoder', self.labels_encoder, file_helper.VarType.OBJECT)

        path = '{}/{}-{}.csv'.format(path, path, datetime.now().strftime("%m-%d-%Y-%H-%M-%S"))
        if self.df_result is not None: 
            helper.save_df_to_csv(self.df_result, path)
            helper.save_state(class_name, 'df_result', self.df_result, file_helper.VarType.DATAFRAME)

    def load_state(self, mode):
        self.logger.info("Try to load state...")
        helper = file_helper(self.logger)
        class_name = 'classification'

        # self.keras_mlp_history = helper.load_state(class_name, 'keras_mlp_history', file_helper.VarType.OBJECT)
        self.y_test = helper.load_state(class_name, 'y_test', file_helper.VarType.OBJECT)
        self.y_train = helper.load_state(class_name, 'y_train', file_helper.VarType.OBJECT)
        self.y_val = helper.load_state(class_name, 'y_val', file_helper.VarType.OBJECT)
        self.labels_encoder = helper.load_state(class_name, 'labels_encoder', file_helper.VarType.OBJECT)

        if(mode == ClassificationMode.BOW):
            self.keras_mlp_bow = helper.load_state(class_name, 'keras_mlp_bow.h5', file_helper.VarType.KERAS_MODEL)
            self.x_test_bow = helper.load_state(class_name, 'x_test_bow', file_helper.VarType.OBJECT)
            self.x_train_bow = helper.load_state(class_name, 'x_train_bow', file_helper.VarType.OBJECT)
            self.x_val_bow = helper.load_state(class_name, 'x_val_bow', file_helper.VarType.OBJECT)
        if(mode == ClassificationMode.W2V):
            self.keras_mlp_w2v = helper.load_state(class_name, 'keras_mlp_w2v.h5', file_helper.VarType.KERAS_MODEL)
            self.x_test_w2v = helper.load_state(class_name, 'x_test_w2v', file_helper.VarType.OBJECT)
            self.x_train_w2v = helper.load_state(class_name, 'x_train_w2v', file_helper.VarType.OBJECT)
            self.x_val_w2v = helper.load_state(class_name, 'x_val_w2v', file_helper.VarType.OBJECT)
        
        class_name = 'nlp'

        self.df = helper.load_state(class_name, 'df_result', file_helper.VarType.DATAFRAME)
        self.gensim_dictionary = helper.load_state(class_name, 'gensim_dictionary', file_helper.VarType.OBJECT)

        if(mode == ClassificationMode.BOW):
            self.gensim_corpus_tfidf = helper.load_state(class_name, 'gensim_corpus_tfidf', file_helper.VarType.OBJECT)
        if(mode == ClassificationMode.W2V):
            self.gensim_docs_vectors_w2v = helper.load_state(class_name, 'gensim_docs_vectors_w2v', file_helper.VarType.OBJECT)
        
    def build(self, mode=ClassificationMode.W2V, load_path='05_topic_modeling', save_path='06_classification_pipeline'):
        helper = file_helper(self.logger)

        try:
            self.load_state(mode)

            if self.df is None: self.df=helper.load_df_from_csv('data/{}'.format(load_path))         
            self.preprocess(self.df, min_sample_count=1100, mode=mode, seed=self.seed)
            self.split_data(self.df, len(self.gensim_dictionary), 0.5, 0.25, 0.25, seed=self.seed, mode=mode)
            if(mode == ClassificationMode.BOW):
                if self.keras_mlp_bow is None: self.keras_mlp(
                    self.x_train_bow, self.y_train, 
                    self.x_test_bow, self.y_test, 
                    self.x_val_bow, self.y_val, 
                    len(self.gensim_dictionary), self.labels_count, 
                    seed=self.seed, mode=mode
                )
                self.plot_history(self.keras_mlp_history, save_path, mode)
            elif(mode == ClassificationMode.W2V):
                if self.keras_mlp_w2v is None: self.keras_mlp(
                    self.x_train_w2v, self.y_train, 
                    self.x_test_w2v, self.y_test, 
                    self.x_val_w2v, self.y_val, 
                    300, self.labels_count,
                    seed=self.seed, mode=mode
                )
                self.plot_history(self.keras_mlp_history, save_path, mode)
                if self.categories_predicted_mlp is None: self.predict(
                    self.keras_mlp_w2v, 
                    np.array(list(self.df.gensim_docs_vectors_w2v)),
                    self.labels_encoder
                )
            
            # if self.categories_predicted_mlp is None: self.predict(x)
            self.merge_results(self.df, mode)
        except :
            exc_type, exc_value, exc_traceback = sys.exc_info()
            self.logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
            raise

        finally:
            self.logger.info("Saving state with mode {}...".format(mode.name))
            self.save_state(mode, save_path)
            
        return self
