import dateparser
from scrapy.spiders import XMLFeedSpider


class ITNewsSpider(XMLFeedSpider):
    name = 'itnews'
    start_urls = ['https://www.itnews.com.au/RSS/rss.ashx?type=Category&ID=32']
    itertag = 'item'

    def parse_node(self, response, node):
        url = node.xpath('link/text()').extract_first()
        pub_date = dateparser.parse(node.xpath('pubDate/text()').extract_first())
        if self.seen_url_db.check_url(url):
            item = {'source': 'itnews.com.au', 'url': url, 'pub_date': pub_date,
                    'author': ''}
            yield item
