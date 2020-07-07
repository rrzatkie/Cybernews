import dateparser
from scrapy.spiders import XMLFeedSpider


class ZdnetSpider(XMLFeedSpider):
    name = 'zdnet'
    start_urls = ['https://www.zdnet.com/topic/security/rss.xml']
    namespaces = [('media', 'http://search.yahoo.com/mrss/')]
    itertag = 'item'

    def parse_node(self, response, node):
        url = node.xpath('link/text()').extract_first()
        pub_date = dateparser.parse(node.xpath('pubDate/text()').extract_first())
        author = node.xpath('media:credit/text()').extract_first()
        if self.seen_url_db.check_url(url):
            item = {'source': 'zdnet.com', 'url': url, 'pub_date': pub_date, 'author': author}
            yield item
