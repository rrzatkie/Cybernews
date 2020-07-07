import sys
from os.path import abspath, basename, dirname, splitext
import time

from pipeline.models.crawler import crawler
from pipeline.helpers.logger import logger_init
from pipeline.helpers.file_helper import file_helper

__ROOT_DIR__ = dirname(dirname(dirname(abspath(__file__))))
    
if __name__ == '__main__':
    logger = logger_init(__ROOT_DIR__, splitext(basename(__file__))[0])
    helper = file_helper(
        logger,
        pickles_path="{}/data/pickles".format(__ROOT_DIR__),
        data_path="{}/data/df".format(__ROOT_DIR__)
    )
    
    try:
        logger.info("Starting crawling for urls")
        start = time.time()
        crawler = crawler(logger, helper).build()
        logger.info("Finished crawling for urls. Elapsed time: {:.2f} seconds".format(time.time()-start))
    except:
        exc_type, exc_value, exc_traceback = sys.exc_info()
        logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))