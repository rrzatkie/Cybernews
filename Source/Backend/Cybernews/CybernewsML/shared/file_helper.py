import os
import re
from datetime import datetime

import pickle
import pandas as pd
from enum import Enum
import keras
from keras import backend as K

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

class file_helper:
    class VarType(Enum):
        DATAFRAME = 1,
        OBJECT = 2,
        KERAS_MODEL = 3

    def __init__(self, logger, pickles_path='pickles/'):
        self.logger = logger
        self.pickles_path = pickles_path

    def get_newest_file(self, path):
        fn_list = os.listdir(path)
        if(len(fn_list) > 0):
            dates = []
            for f in fn_list:
                match = re.search("([0-9]{2}-[0-9]{2}-[0-9]{4}-[0-9]{2}-[0-9]{2}-[0-9]{2})", f)
                if(match is not None):
                    dates.append({'fileName': f, 'date': match.group()})

            dates = list(map(lambda x: {'fileName': x['fileName'], 'date': datetime.strptime(x['date'], "%m-%d-%Y-%H-%M-%S")}, dates))
            dates.sort(key=lambda x: x['date'], reverse=True)

            return path + "/" + dates[0]['fileName']
        else:
            self.logger.debug("'{}' does not exist".format(path))
            return None

    def exists(self, path):
        return os.path.exists(path)

    def save_df_to_pickle(self, df, path):
        if(df is not None):
            self.logger.info("Saving df at: {}".format(path))
            df.to_pickle(path)
        else:
            raise TypeError

    def save_df_to_csv(self, df, path):
        if(df is not None):
            self.logger.info("Saving df at: {}".format(path))
            with open(path, 'w', encoding="utf-8") as f:
                df.to_csv(path_or_buf=f)
        else:
            raise TypeError

    def load_df_from_pickle(self, path):
        if(self.exists(path)):
            self.logger.debug("Loading from {}".format(path))
            return pd.read_pickle(path)
        else:
            self.logger.debug("'{}' does not exist".format(path))
            return None

    def load_df_from_csv(self, path):
        if(self.exists(path)):
            self.logger.debug("Loading newest file from {}".format(path))
            with open(self.get_newest_file(path), 'r', encoding="utf-8") as f:
                return pd.read_csv(f, index_col = 0)
        else:
            self.logger.debug("'{}' does not exist".format(path))
            return None

    def save_pickle(self, obj, path):
        if(obj is not None):
            self.logger.info("Saving obj at: {}".format(path))
            with open(path, 'wb') as f:
                pickle.dump(obj, f)
        else:
            raise TypeError

    def load_pickle(self, path):

        if(self.exists(path)):
            self.logger.debug("Loading from {}".format(path))
            with open(path, 'rb') as f:
                return pickle.load(f)
        else:
            self.logger.debug("'{}' does not exist".format(path))
            return None

    def save_keras_model(self, model, path):
        if(model is not None):
            self.logger.info("Saving keras model at: {}".format(path))
            model.save(path)
        else:
            raise TypeError

    def load_keras_model(self, path):

        if(self.exists(path)):
            self.logger.debug("Loading keras model from {}".format(path))
            m = metrics()
            dependecies = {
                "f1_m": m.f1_m,
                "recall_m": m.recall_m,
                "precision_m": m.precision_m
            }

            return keras.models.load_model(path, custom_objects=dependecies)
        else:
            self.logger.debug("'{}' does not exist".format(path))
            return None

    def save_state(self, class_name, var_name, obj, type, path=None):
        try:
            tmp = os.path.join(self.pickles_path, class_name)
            os.mkdir(tmp)
            self.logger.info('Created pickles directory for class {} -> {}'.format(class_name, tmp))
        except:
            pass
        
        if path is None: path = os.path.join(self.pickles_path, class_name, var_name)
        if(type == self.VarType.DATAFRAME):
            self.save_df_to_pickle(obj, path)
        elif(type == self.VarType.OBJECT):
            self.save_pickle(obj, path)
        elif(type == self.VarType.KERAS_MODEL):
            self.save_keras_model(obj, path)

    def load_state(self, class_name, var_name, type, path=None):
        if path is None: path = os.path.join(self.pickles_path, class_name, var_name)
        if(type == self.VarType.DATAFRAME):
            return self.load_df_from_pickle(path)
        elif(type == self.VarType.OBJECT):
            return self.load_pickle(path)
        elif(type == self.VarType.KERAS_MODEL):
            return self.load_keras_model(path)


