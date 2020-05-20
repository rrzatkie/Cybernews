import sys, time
from os.path import basename, splitext

from shared.classification import classification
from shared.logger import logger_init


if __name__=='__main__':
    logger = logger_init(splitext(basename(__file__))[0])
    
    try:
        logger.info("Starting classificatiopn pipeline")
        start = time.time()
        c = classification(logger).build()
        logger.info("Finished classification pipeline. Elapsed time: {:.2f} seconds".format(time.time()-start))
    except:
        exc_type, exc_value, exc_traceback = sys.exc_info()
        logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))