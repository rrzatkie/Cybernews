import sys, os

from shared.classification import classification
from shared.logger import logger_init


if __name__=='__main__':
    try:
        logger = logger_init(os.path.basename(__file__))
        c = classification(logger).build()
    except:
        exc_type, exc_value, exc_traceback = sys.exc_info()
        logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))