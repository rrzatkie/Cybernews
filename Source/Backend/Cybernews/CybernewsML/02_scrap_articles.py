import sys
from os.path import basename, splitext
import time

from shared.logger import logger_init
from shared.scraper import scraper
    
if __name__ == '__main__':
    logger = logger_init(splitext(basename(__file__))[0])
    
    try:
        logger.info("Starting scraping articles")
        start = time.time()
        scraper = scraper(logger).build()
        logger.info("Finished scraping articles. Elapsed time: {:.2f} seconds".format(time.time()-start))
    except:
        exc_type, exc_value, exc_traceback = sys.exc_info()
        logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))