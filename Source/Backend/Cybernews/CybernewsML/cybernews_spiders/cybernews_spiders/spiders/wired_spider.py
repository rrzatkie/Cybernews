import dateparser
from scrapy.spiders import XMLFeedSpider


class WiredSpider(XMLFeedSpider):
    name = 'wired'
    start_urls = ['https://www.wired.com/feed/category/security/latest/rss']
    namespaces = [('dc', 'http://purl.org/dc/elements/1.1/')]
    itertag = 'item'

    def parse_node(self, response, node):
        url = node.xpath('link/text()').extract_first()
        pub_date = dateparser.parse(node.xpath('pubDate/text()').extract_first())
        author = node.xpath('dc:creator/text()').extract_first()
        if self.seen_url_db.check_url(url):
            item = {'source': 'wired.com', 'url': url, 'pub_date': pub_date, 'author': author}
            yield item
