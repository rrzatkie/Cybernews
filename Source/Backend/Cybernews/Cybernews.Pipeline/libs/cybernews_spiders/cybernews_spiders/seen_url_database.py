import sqlite3
import logging

logger = logging.getLogger(__file__)

class SeenURLDatabase:
    """Simple sqlite3 wrapper that filters already seen urls."""
    def __init__(self):
        logging.info("init seen_urls_db")
        self.conn = sqlite3.connect('seen_urls.db')
        # self.conn.row_factory = lambda cursor, row: row[0]
        self.c = self.conn.cursor()
        self.c.execute("CREATE TABLE IF NOT EXISTS seen_urls(url)")

    def check_url(self, url):
        logger.info("check if %s is already in the db", url)
        self.c.execute("SELECT url FROM seen_urls WHERE url=?", (url,))
        seen_url = self.c.fetchone()
        if seen_url is None:
            logging.debug("%s is not in db", url)
            self.c.execute("INSERT INTO seen_urls VALUES (?)", (url,))
            return True
        else:
            logging.debug("%s is in db", url)
            return False

    def close(self):
        logging.info("close seen_urls_db")
        if self.conn:
            self.conn.commit()
            self.c.close()
            self.conn.close()
