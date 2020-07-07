from scrapy.spiders import XMLFeedSpider
import dateparser


class ArcyberSpider(XMLFeedSpider):
    name = 'arcyber'
    start_urls = ['https://www.army.mil/rss/static/384.xml']
    itertag = 'item'

    def parse_node(self, response, node):
        url = node.xpath('link/text()').extract_first()
        pub_date = dateparser.parse(node.xpath('pubDate/text()').extract_first())
        if self.seen_url_db.check_url(url):
            item = {'source': 'army.mil', 'url': url, 'pub_date': pub_date, 'author': 'US Army'}
            yield item
