import sys
from os.path import basename, splitext
import time

from shared.logger import logger_init
from shared.crawler import crawler
    
if __name__ == '__main__':
    logger = logger_init(splitext(basename(__file__))[0])
    
    try:
        logger.info("Starting crawling for urls")
        start = time.time()
        crawler = crawler(logger).build()
        logger.info("Finished crawling for urls. Elapsed time: {:.2f} seconds".format(time.time()-start))
    except:
        exc_type, exc_value, exc_traceback = sys.exc_info()
        logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))