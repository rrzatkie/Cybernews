import sys, traceback, time
from os.path import basename, splitext

from shared.logger import logger_init
from shared.nlp import nlp, NlpMode

if __name__ == '__main__':
    logger = logger_init(splitext(basename(__file__))[0])
    try:
        logger.info("Starting NLP pipeline")
        start = time.time()
        mode = NlpMode.ALL
        nlp = nlp(logger).build(mode)
        logger.info("Finished NLP pipeline. Elapsed time: {:.2f} seconds".format(time.time()-start))
    except:
        exc_type, exc_value, exc_traceback = sys.exc_info()
        logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))
