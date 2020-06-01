import string
import nltk
from nltk.corpus import wordnet, stopwords
from nltk.stem.wordnet import WordNetLemmatizer

from sklearn.base import BaseEstimator, TransformerMixin


class NLTKPreprocessor(BaseEstimator, TransformerMixin):
    def __init__(self, stop_words=set(), lower=True, strip=True):
        self.lower = lower
        self.strip = strip
        self.stop_words = stop_words
        self.punct = set(string.punctuation)
        self.lemmatizer = WordNetLemmatizer()

    def fit(self, X, y=None):
        return self

    def inverse_transform(self, X):
        return [" ".join(doc) for doc in X]

    def transform(self, X):
        return [list(self.tokenize(doc)) for doc in X]

    def tokenize(self, document):
        # break into sentences
        for sent in nltk.sent_tokenize(document):
            # break sentence into pos tags
            for token, tag in nltk.pos_tag(nltk.word_tokenize(sent)):
                token = token.lower() if self.lower else token
                token = token.strip() if self.strip else token
                token = token.strip('_') if self.strip else token
                token = token.strip('*') if self.strip else token

                if token in self.stop_words:
                    continue

                if all(char in self.punct for char in token):
                    continue

                lemma = self.lemmatize(token, tag)
                yield lemma

    def lemmatize(self, token, tag):
        tag = {
            'N': wordnet.NOUN,
            'V': wordnet.VERB,
            'J': wordnet.ADJ,
            'R': wordnet.ADV,
        }.get(tag[0], wordnet.NOUN)

        return self.lemmatizer.lemmatize(token, tag)

