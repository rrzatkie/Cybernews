import scrapy
import dateparser


class TheHillSpider(scrapy.Spider):
    name = 'thehill'
    start_urls = ['http://thehill.com/policy/cybersecurity']

    def parse(self, response):
        article_urls = response.xpath('//article//h2[@class="node__title node-title"]/a/@href').extract()
        pub_dates = response.xpath('//article//span[@class="date"]/text()').extract()
        authors = [author.replace(u' and \u2026', '') for author in response.xpath(
            '//article//p[@class="submitted"]/span[@rel="sioc:has_creator"]//text()').extract() if author.replace(u' and \u2026', '') != '']
        for i, url in enumerate(article_urls):
            if self.seen_url_db.check_url('http://thehill.com' + url):
                pub_date = dateparser.parse(pub_dates[i])
                author = authors[i]
                item = {'source': 'thehill.com', 'url': 'http://thehill.com' + url, 'pub_date': pub_date,
                        'author': author}
                yield item
