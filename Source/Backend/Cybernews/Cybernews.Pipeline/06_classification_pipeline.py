import sys, time
from os.path import abspath, basename, dirname, splitext

from libs.cybernews_pipeline.shared.classification import classification
from libs.cybernews_pipeline.shared.logger import logger_init
from libs.cybernews_pipeline.shared.file_helper import file_helper

__ROOT_DIR__ = dirname(abspath(__file__))

if __name__=='__main__':
    logger = logger_init(__ROOT_DIR__, splitext(basename(__file__))[0])
    helper = file_helper(
        logger,
        pickles_path="{}/libs/cybernews_pipeline/pickles".format(__ROOT_DIR__),
        data_path="{}/libs/cybernews_pipeline/data".format(__ROOT_DIR__)
    )
    
    try:
        logger.info("Starting classificatiopn pipeline")
        start = time.time()
        c = classification(logger, helper).build()
        logger.info("Finished classification pipeline. Elapsed time: {:.2f} seconds".format(time.time()-start))
    except:
        exc_type, exc_value, exc_traceback = sys.exc_info()
        logger.error("Caught exception", exc_info=(exc_type, exc_value, exc_traceback))