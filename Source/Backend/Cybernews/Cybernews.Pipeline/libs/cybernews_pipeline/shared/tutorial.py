# To add a new cell, type '# %%'
# To add a new markdown cell, type '# %% [markdown]'
# %%
from IPython import get_ipython

# %% [markdown]
# # Finding similar documents with Word2Vec and Soft Cosine Measure 
# 
# Soft Cosine Measure (SCM) [1, 3] is a promising new tool in machine learning that allows us to submit a query and return the most relevant documents. In **part 1**, we will show how you can compute SCM between two documents using the `inner_product` method. In **part 2**, we will use `SoftCosineSimilarity` to retrieve documents most similar to a query and compare the performance against other similarity measures.
# 
# First, however, we go through the basics of what Soft Cosine Measure is.
# 
# ## Soft Cosine Measure basics
# 
# Soft Cosine Measure (SCM) is a method that allows us to assess the similarity between two documents in a meaningful way, even when they have no words in common. It uses a measure of similarity between words, which can be derived [2] using [word2vec][] [4] vector embeddings of words. It has been shown to outperform many of the state-of-the-art methods in the semantic text similarity task in the context of community question answering [2].
# 
# [word2vec]: https://radimrehurek.com/gensim/models/word2vec.html
# 
# SCM is illustrated below for two very similar sentences. The sentences have no words in common, but by modeling synonymy, SCM is able to accurately measure the similarity between the two sentences. The method also uses the bag-of-words vector representation of the documents (simply put, the word's frequencies in the documents). The intution behind the method is that we compute standard cosine similarity assuming that the document vectors are expressed in a non-orthogonal basis, where the angle between two basis vectors is derived from the angle between the word2vec embeddings of the corresponding words.
# 
# ![Soft Cosine Measure](soft_cosine_tutorial.png)
# 
# This method was perhaps first introduced in the article “Soft Measure and Soft Cosine Measure: Measure of Features in Vector Space Model” by Grigori Sidorov, Alexander Gelbukh, Helena Gomez-Adorno, and David Pinto ([link to PDF](http://www.scielo.org.mx/pdf/cys/v18n3/v18n3a7.pdf)).
# 
# In this tutorial, we will learn how to use Gensim's SCM functionality, which consists of the `inner_product` method for one-off computation, and the `SoftCosineSimilarity` class for corpus-based similarity queries.
# 
# > **Note**:
# >
# > If you use this software, please consider citing [1], [2], and [3].
# >
# 
# ## Running this notebook
# You can download this [Jupyter notebook](http://jupyter.org/), and run it on your own computer, provided you have installed the `gensim`, `jupyter`, `sklearn`, `pyemd`, and `wmd` Python packages.
# 
# The notebook was run on an Ubuntu machine with an Intel core i7-6700HQ CPU 3.10GHz (4 cores) and 16 GB memory. Assuming all resources required by the notebook have already been downloaded, running the entire notebook on this machine takes about 30 minutes.

# %%
# Initialize logging.
import logging

logging.basicConfig(format='%(asctime)s : %(levelname)s : %(message)s', level=logging.INFO)

# %% [markdown]
# ## Part 1: Computing the Soft Cosine Measure
# 
# To use SCM, we need some word embeddings first of all. You could train a [word2vec][] (see tutorial [here](http://rare-technologies.com/word2vec-tutorial/)) model on some corpus, but we will use pre-trained word2vec embeddings.
# 
# [word2vec]: https://radimrehurek.com/gensim/models/word2vec.html
# 
# Let's create some sentences to compare.

# %%
sentence_obama = 'Obama speaks to the media in Illinois'.lower().split()
sentence_president = 'The president greets the press in Chicago'.lower().split()
sentence_orange = 'Having a tough time finding an orange juice press machine?'.lower().split()

# %% [markdown]
# The first two sentences have very similar content, and as such the SCM should be large. Before we compute the SCM, we want to remove stopwords ("the", "to", etc.), as these do not contribute a lot to the information in the sentences.

# %%
get_ipython().system('pip install nltk')


# %%
# Import and download stopwords from NLTK.
from nltk.corpus import stopwords
from nltk import download

download('stopwords')  # Download stopwords list.

# Remove stopwords.
stop_words = stopwords.words('english')
sentence_obama = [w for w in sentence_obama if w not in stop_words]
sentence_president = [w for w in sentence_president if w not in stop_words]
sentence_orange = [w for w in sentence_orange if w not in stop_words]

# Prepare a dictionary and a corpus.
from gensim import corpora
documents = [sentence_obama, sentence_president, sentence_orange]
dictionary = corpora.Dictionary(documents)

# Convert the sentences into bag-of-words vectors.
sentence_obama = dictionary.doc2bow(sentence_obama)
sentence_president = dictionary.doc2bow(sentence_president)
sentence_orange = dictionary.doc2bow(sentence_orange)

# %% [markdown]
# Now, as we mentioned earlier, we will be using some downloaded pre-trained embeddings. Note that the embeddings we have chosen here require a lot of memory. We will use the embeddings to construct a term similarity matrix that will be used by the `inner_product` method.

# %%
get_ipython().run_cell_magic('time', '', 'import gensim.downloader as api\n\nfrom gensim.models import WordEmbeddingSimilarityIndex\nfrom gensim.similarities import SparseTermSimilarityMatrix\n\nw2v_model = api.load("glove-wiki-gigaword-50")\nsimilarity_index = WordEmbeddingSimilarityIndex(w2v_model)\nsimilarity_matrix = SparseTermSimilarityMatrix(similarity_index, dictionary)')

# %% [markdown]
# Let's compute SCM using the `inner_product` method.

# %%
similarity = similarity_matrix.inner_product(sentence_obama, sentence_president, normalized=True)
print('similarity = %.4f' % similarity)

# %% [markdown]
# Let's try the same thing with two completely unrelated sentences. Notice that the similarity is smaller.

# %%
similarity = similarity_matrix.inner_product(sentence_obama, sentence_orange, normalized=True)
print('similarity = %.4f' % similarity)

# %% [markdown]
# ## Part 2: Similarity queries using `SoftCosineSimilarity`
# You can use SCM to get the most similar documents to a query, using the `SoftCosineSimilarity` class. Its interface is similar to what is described in the [Similarity Queries](https://radimrehurek.com/gensim/tut3.html) Gensim tutorial.
# 
# ### Qatar Living unannotated dataset
# Contestants solving the community question answering task in the [SemEval 2016][semeval16] and [2017][semeval17] competitions had an unannotated dataset of 189,941 questions and 1,894,456 comments from the [Qatar Living][ql] discussion forums. As our first step, we will use the same dataset to build a corpus.
# 
# [semeval16]: http://alt.qcri.org/semeval2016/task3/
# [semeval17]: http://alt.qcri.org/semeval2017/task3/
# [ql]: http://www.qatarliving.com/forum

# %%
get_ipython().run_cell_magic('time', '', 'from itertools import chain\nimport json\nfrom re import sub\nfrom os.path import isfile\n\nimport gensim.downloader as api\nfrom gensim.utils import simple_preprocess\nfrom nltk.corpus import stopwords\nfrom nltk import download\n\ndownload("stopwords")  # Download stopwords list.\nstopwords = set(stopwords.words("english"))\n\ndef preprocess(doc):\n    doc = sub(r\'<img[^<>]+(>|$)\', " image_token ", doc)\n    doc = sub(r\'<[^<>]+(>|$)\', " ", doc)\n    doc = sub(r\'\\[img_assist[^]]*?\\]\', " ", doc)\n    doc = sub(r\'http[s]?://(?:[a-zA-Z]|[0-9]|[$-_@.&+]|[!*\\(\\),]|(?:%[0-9a-fA-F][0-9a-fA-F]))+\', " url_token ", doc)\n    return [token for token in simple_preprocess(doc, min_len=0, max_len=float("inf")) if token not in stopwords]\n\ncorpus = list(chain(*[\n    chain(\n        [preprocess(thread["RelQuestion"]["RelQSubject"]), preprocess(thread["RelQuestion"]["RelQBody"])],\n        [preprocess(relcomment["RelCText"]) for relcomment in thread["RelComments"]])\n    for thread in api.load("semeval-2016-2017-task3-subtaskA-unannotated")]))\n\nprint("Number of documents: %d" % len(documents))')

# %% [markdown]
# Using the corpus we have just build, we will now construct a [dictionary][], a [TF-IDF model][tfidf], a [word2vec model][word2vec], and a term similarity matrix.
# 
# [dictionary]: https://radimrehurek.com/gensim/corpora/dictionary.html
# [tfidf]: https://radimrehurek.com/gensim/models/tfidfmodel.html
# [word2vec]: https://radimrehurek.com/gensim/models/word2vec.html

# %%
get_ipython().run_cell_magic('time', '', 'from multiprocessing import cpu_count\n\nfrom gensim.corpora import Dictionary\nfrom gensim.models import TfidfModel\nfrom gensim.models import Word2Vec\nfrom gensim.models import WordEmbeddingSimilarityIndex\nfrom gensim.similarities import SparseTermSimilarityMatrix\n\ndictionary = Dictionary(corpus)\ntfidf = TfidfModel(dictionary=dictionary)\nw2v_model = Word2Vec(corpus, workers=cpu_count(), min_count=5, size=300, seed=12345)\nsimilarity_index = WordEmbeddingSimilarityIndex(w2v_model.wv)\nsimilarity_matrix = SparseTermSimilarityMatrix(similarity_index, dictionary, tfidf, nonzero_limit=100)')

# %% [markdown]
# ### Evaluation
# Next, we will load the validation and test datasets that were used by the SemEval 2016 and 2017 contestants. The datasets contain 208 original questions posted by the forum members. For each question, there is a list of 10 threads with a human annotation denoting whether or not the thread is relevant to the original question. Our task will be to order the threads so that relevant threads rank above irrelevant threads.

# %%
datasets = api.load("semeval-2016-2017-task3-subtaskBC")

# %% [markdown]
# Finally, we will perform an evaluation to compare three unsupervised similarity measures – the Soft Cosine Measure, two different implementations of the [Word Mover's Distance][wmd], and standard cosine similarity. We will use the [Mean Average Precision (MAP)][map] as an evaluation measure and 10-fold cross-validation to get an estimate of the variance of MAP for each similarity measure.
# 
# [wmd]: http://vene.ro/blog/word-movers-distance-in-python.html
# [map]: https://medium.com/@pds.bangalore/mean-average-precision-abd77d0b9a7e

# %%
get_ipython().system('pip install wmd')


# %%
get_ipython().system('pip install sklearn')


# %%
get_ipython().system('pip install pyemd')


# %%
from math import isnan
from time import time

from gensim.similarities import MatrixSimilarity, WmdSimilarity, SoftCosineSimilarity
import numpy as np
from sklearn.model_selection import KFold
from wmd import WMD

def produce_test_data(dataset):
    for orgquestion in datasets[dataset]:
        query = preprocess(orgquestion["OrgQSubject"]) + preprocess(orgquestion["OrgQBody"])
        documents = [
            preprocess(thread["RelQuestion"]["RelQSubject"]) + preprocess(thread["RelQuestion"]["RelQBody"])
            for thread in orgquestion["Threads"]]
        relevance = [
            thread["RelQuestion"]["RELQ_RELEVANCE2ORGQ"] in ("PerfectMatch", "Relevant")
            for thread in orgquestion["Threads"]]
        yield query, documents, relevance

def cossim(query, documents):
    # Compute cosine similarity between the query and the documents.
    query = tfidf[dictionary.doc2bow(query)]
    index = MatrixSimilarity(
        tfidf[[dictionary.doc2bow(document) for document in documents]],
        num_features=len(dictionary))
    similarities = index[query]
    return similarities

def softcossim(query, documents):
    # Compute Soft Cosine Measure between the query and the documents.
    query = tfidf[dictionary.doc2bow(query)]
    index = SoftCosineSimilarity(
        tfidf[[dictionary.doc2bow(document) for document in documents]],
        similarity_matrix)
    similarities = index[query]
    return similarities

def wmd_gensim(query, documents):
    # Compute Word Mover's Distance as implemented in PyEMD by William Mayner
    # between the query and the documents.
    index = WmdSimilarity(documents, w2v_model)
    similarities = index[query]
    return similarities

def wmd_relax(query, documents):
    # Compute Word Mover's Distance as implemented in WMD by Source{d}
    # between the query and the documents.
    words = [word for word in set(chain(query, *documents)) if word in w2v_model.wv]
    indices, words = zip(*sorted((
        (index, word) for (index, _), word in zip(dictionary.doc2bow(words), words))))
    query = dict(tfidf[dictionary.doc2bow(query)])
    query = [
        (new_index, query[dict_index])
        for new_index, dict_index in enumerate(indices)
        if dict_index in query]
    documents = [dict(tfidf[dictionary.doc2bow(document)]) for document in documents]
    documents = [[
        (new_index, document[dict_index])
        for new_index, dict_index in enumerate(indices)
        if dict_index in document] for document in documents]
    embeddings = np.array([w2v_model.wv[word] for word in words], dtype=np.float32)
    nbow = dict(((index, list(chain([None], zip(*document)))) for index, document in enumerate(documents)))
    nbow["query"] = tuple([None] + list(zip(*query)))
    distances = WMD(embeddings, nbow, vocabulary_min=1).nearest_neighbors("query")
    similarities = [-distance for _, distance in sorted(distances)]
    return similarities

strategies = {
    "cossim" : cossim,
    "softcossim": softcossim,
    "wmd-gensim": wmd_gensim,
    "wmd-relax": wmd_relax}

def evaluate(split, strategy):
    # Perform a single round of evaluation.
    results = []
    start_time = time()
    for query, documents, relevance in split:
        similarities = strategies[strategy](query, documents)
        assert len(similarities) == len(documents)
        precision = [
            (num_correct + 1) / (num_total + 1) for num_correct, num_total in enumerate(
                num_total for num_total, (_, relevant) in enumerate(
                    sorted(zip(similarities, relevance), reverse=True)) if relevant)]
        average_precision = np.mean(precision) if precision else 0.0
        results.append(average_precision)
    return (np.mean(results) * 100, time() - start_time)

def crossvalidate(args):
    # Perform a cross-validation.
    dataset, strategy = args
    test_data = np.array(list(produce_test_data(dataset)))
    kf = KFold(n_splits=10)
    samples = []
    for _, test_index in kf.split(test_data):
        samples.append(evaluate(test_data[test_index], strategy))
    return (np.mean(samples, axis=0), np.std(samples, axis=0))


# %%
get_ipython().run_cell_magic('time', '', 'from multiprocessing import Pool\n\nargs_list = [\n    (dataset, technique)\n    for dataset in ("2016-test", "2017-test")\n    for technique in ("softcossim", "wmd-gensim", "wmd-relax", "cossim")]\nwith Pool() as pool:\n    results = pool.map(crossvalidate, args_list)')

# %% [markdown]
# The table below shows the pointwise estimates of means and standard variances for MAP scores and elapsed times. Baselines and winners for each year are displayed in bold. We can see that the Soft Cosine Measure gives a strong performance on both the 2016 and the 2017 dataset.

# %%
from IPython.display import display, Markdown

output = []
baselines = [
    (("2016-test", "**Winner (UH-PRHLT-primary)**"), ((76.70, 0), (0, 0))),
    (("2016-test", "**Baseline 1 (IR)**"), ((74.75, 0), (0, 0))),
    (("2016-test", "**Baseline 2 (random)**"), ((46.98, 0), (0, 0))),
    (("2017-test", "**Winner (SimBow-primary)**"), ((47.22, 0), (0, 0))),
    (("2017-test", "**Baseline 1 (IR)**"), ((41.85, 0), (0, 0))),
    (("2017-test", "**Baseline 2 (random)**"), ((29.81, 0), (0, 0)))]
table_header = ["Dataset | Strategy | MAP score | Elapsed time (sec)", ":---|:---|:---|---:"]
for row, ((dataset, technique), ((mean_map_score, mean_duration), (std_map_score, std_duration)))         in enumerate(sorted(chain(zip(args_list, results), baselines), key=lambda x: (x[0][0], -x[1][0][0]))):
    if row % (len(strategies) + 3) == 0:
        output.extend(chain(["\n"], table_header))
    map_score = "%.02f ±%.02f" % (mean_map_score, std_map_score)
    duration = "%.02f ±%.02f" % (mean_duration, std_duration) if mean_duration else ""
    output.append("%s|%s|%s|%s" % (dataset, technique, map_score, duration))

display(Markdown('\n'.join(output)))

# %% [markdown]
# Dataset | Strategy | MAP score | Elapsed time (sec)
# :---|:---|:---|---:
# 2016-test|softcossim|78.52 ±11.18|6.00 ±0.79
# 2016-test|**Winner (UH-PRHLT-primary)**|76.70 ±0.00|
# 2016-test|cossim|76.45 ±10.40|0.64 ±0.08
# 2016-test|wmd-gensim|76.23 ±11.42|5.37 ±0.64
# 2016-test|**Baseline 1 (IR)**|74.75 ±0.00|
# 2016-test|wmd-relax|71.05 ±11.06|1.11 ±0.09
# 2016-test|**Baseline 2 (random)**|46.98 ±0.00|
# 
# 
# Dataset | Strategy | MAP score | Elapsed time (sec)
# :---|:---|:---|---:
# 2017-test|**Winner (SimBow-primary)**|47.22 ±0.00|
# 2017-test|softcossim|45.88 ±16.22|7.08 ±1.49
# 2017-test|cossim|44.38 ±14.71|0.74 ±0.10
# 2017-test|wmd-gensim|44.06 ±15.92|6.20 ±0.87
# 2017-test|wmd-relax|43.52 ±16.30|1.30 ±0.18
# 2017-test|**Baseline 1 (IR)**|41.85 ±0.00|
# 2017-test|**Baseline 2 (random)**|29.81 ±0.00|
# %% [markdown]
# ## References
# 
# 1. Grigori Sidorov et al. *Soft Similarity and Soft Cosine Measure: Similarity of Features in Vector Space Model*, 2014. ([link to PDF](http://www.scielo.org.mx/pdf/cys/v18n3/v18n3a7.pdf))
# 2. Delphine Charlet and Geraldine Damnati, SimBow at SemEval-2017 Task 3: Soft-Cosine Semantic Similarity between Questions for Community Question Answering, 2017. ([link to PDF](http://www.aclweb.org/anthology/S17-2051))
# 3. Vít Novotný. *Implementation Notes for the Soft Cosine Measure*, 2018. ([link to PDF](https://arxiv.org/pdf/1808.09407))
# 4. Thomas Mikolov et al. Efficient Estimation of Word Representations in Vector Space, 2013. ([link to PDF](https://arxiv.org/pdf/1301.3781.pdf))
