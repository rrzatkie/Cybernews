import dateparser
from scrapy.spiders import XMLFeedSpider


class TheRegisterSpider(XMLFeedSpider):
    name = 'theregister'
    start_urls = ['https://www.theregister.co.uk/security/headlines.atom']
    namespaces = [('atom', 'http://www.w3.org/2005/Atom')]
    itertag = 'atom:entry'
    iterator = 'xml'

    def parse_node(self, response, node):
        url = node.xpath('atom:link/@href').extract_first()
        pub_date = dateparser.parse(node.xpath('atom:updated/text()').extract_first())
        author = node.xpath('atom:author/atom:name/text()').extract_first()
        if self.seen_url_db.check_url(url):
            item = {'source': 'theregister.co.uk', 'url': url, 'pub_date': pub_date, 'author': author}
            yield item
