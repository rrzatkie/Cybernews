import scrapy
import dateparser


class ArstechnicaSpider(scrapy.Spider):
    name = 'arstechnica'
    start_urls = ['https://arstechnica.com/tag/security/']

    def parse(self, response):
        article_urls = response.xpath('//article//a[@class="overlay"]/@href').extract()
        pub_dates = response.xpath('//article//time[@class="date"]/@datetime').extract()
        authors = response.xpath('//article//span[@itemprop="name"]/text()').extract()
        for i, url in enumerate(article_urls):
            if self.seen_url_db.check_url(url):
                pub_date = dateparser.parse(pub_dates[i])
                author = authors[i]
                item = {'source': 'arstechnica.com', 'url': url, 'pub_date': pub_date, 'author': author}
                yield item
