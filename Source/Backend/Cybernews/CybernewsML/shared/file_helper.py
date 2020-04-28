import os
import re
from datetime import datetime

import pickle
import pandas as pd
from enum import Enum

class file_helper:
    class VarType(Enum):
        DATAFRAME = 1,
        OBJECT = 2

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

            return self.path + "/" + dates[0]['fileName']
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

    def load_df_from_csv(self, df, path):
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

    def save_state(self, class_name, var_name, obj, type):
        path = os.path.join(self.pickles_path, class_name, var_name)
        if(type == self.VarType.DATAFRAME):
            self.save_df_to_pickle(obj, path)
        elif(type == self.VarType.OBJECT):
            self.save_pickle(obj, path)

    def load_state(self, class_name, var_name, type):
        path = os.path.join(self.pickles_path, class_name, var_name)
        if(type == self.VarType.DATAFRAME):
            return self.load_df_from_pickle(path)
        elif(type == self.VarType.OBJECT):
            return self.load_pickle(path)


