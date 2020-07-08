import logging
import os


def logger_init(rootDir, logger_name="logs"):
    try:
        tmp = os.path.join(rootDir, 'logs')
        os.mkdir(tmp)
    except:
        pass

    logFile = '{}/logs/{}.log'.format(rootDir ,logger_name)
    formatString = '%(asctime)s - %(name)s - %(levelname)s - %(message)s'
    
    # create logger with given name
    logger = logging.getLogger(logger_name)
    logger.setLevel(logging.DEBUG)
    # create file handler which logs even debug messages
    fh = logging.FileHandler(logFile) 
    fh.setLevel(logging.DEBUG)
    # create console handler with a higher log level
    ch = logging.StreamHandler()
    ch.setLevel(logging.ERROR)
    # create formatter and add it to the handlers
    formatter = logging.Formatter(formatString)
    fh.setFormatter(formatter)
    ch.setFormatter(formatter)
    # add the handlers to the logger
    logger.addHandler(fh)
    logger.addHandler(ch)

    return logger

def basicConfig(handlers):
    logging.basicConfig(
        level=logging.DEBUG,
        handlers=handlers
    )


def removeHandlers():
    for handler in logging.root.handlers[:]:
        logging.root.removeHandler(handler)