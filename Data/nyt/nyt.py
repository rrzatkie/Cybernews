#%%
class Article():
    def __init__(self, id, title):
        self.id = id
        self.title = title
        self.annotations = list()

    def __str__(self):
        result = ""
        result += ("{}\t{}".format(self.id, self.title))
        for a in self.annotations:
            result += ("{}\t{}\t{}\t{}\t{}\t{}\t{}".format(a.EntityIndex, a.AutoInferredSalience, a.MentionCount, a.FirstMentionText, a.ByteOffsetStart, a.ByteOFfsetEnd, a.MID))
        return result

    def to_dict(self):

        annotation = {
            'EntityIndex' : self.EntityIndex,
            'AutoInferredSalience' : self.AutoInferredSalience,
            'MentionCount' : self.MentionCount,
            'FirstMentionText' : self.FirstMentionText,
            'ByteOffsetStart' : self.ByteOffsetStart,
            'ByteOFfsetEnd' : self.ByteOFfsetEnd,
            'MID' : self.MID
        }

class Annotation():
    def __init__(self, EntityIndex, AutoInferredSalience, MentionCount, FirstMentionText, ByteOffsetStart, ByteOFfsetEnd, MID):
        self.EntityIndex = EntityIndex
        self.AutoInferredSalience = AutoInferredSalience
        self.MentionCount = MentionCount
        self.FirstMentionText = FirstMentionText
        self.ByteOffsetStart = ByteOffsetStart
        self.ByteOFfsetEnd = ByteOFfsetEnd
        self.MID = MID


f = open('/home/rrzatkie/Work/Cybernews/Data/nyt/nyt-eval', "r")

line = f.readline()
corpus = list()


while line != '':
    line = line.split("\t", 1)
    article = Article(line[0], line[1])

    line = f.readline()
    while line != "\n":
        line = line.split('\t')
        annotation = Annotation(line[0], line[1], line[2], line[3], line[4], line[5], line[6])
        article.annotations.append(annotation)
        
        line = f.readline()

    corpus.append(article)
    line = f.readline()

#%%
import pandas as pd
df = pd.DataFrame(corpus.to_)

# %%
