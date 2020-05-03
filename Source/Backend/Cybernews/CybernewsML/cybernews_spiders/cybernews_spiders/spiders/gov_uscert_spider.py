from scrapy.spiders import XMLFeedSpider
import dateparser


class USCertSpider(XMLFeedSpider):
    name = 'uscert'
    start_urls = [
        'https://www.us-cert.gov/ncas/alerts.xml',
        'https://www.us-cert.gov/ncas/analysis-reports.xml',
        'https://www.us-cert.gov/ncas/bulletins.xml',
        'https://www.us-cert.gov/ncas/tips.xml',
        'https://www.us-cert.gov/ncas/current-activity.xml',
    ]
    itertag = 'item'

    def parse_node(self, response, node):
        url = node.xpath('link/text()').extract_first()
        pub_date = dateparser.parse(node.xpath('pubDate/text()').extract_first())
        if self.seen_url_db.check_url(url):
            item = {'source': 'us-cert.gov', 'url': url, 'pub_date': pub_date, 'author': 'US-CERT'}
            yield item
