import scrapy
import dateparser


class SafeAndSavvySpider(scrapy.Spider):
    name = 'safeandsavvy'
    start_urls = ['https://safeandsavvy.f-secure.com/category/security-privacy/']

    def parse(self, response):
        article_urls = response.xpath('//div[@class="row"]/div[@class="col-sm-12"]//a/@href').extract()
        pub_dates = response.xpath('//div[@class="row"]/div[@class="col-sm-12"]//p[@class="text--smallest '
                                   'font--dust-gray"]/text()').extract()
        for i, url in enumerate(article_urls):
            if self.seen_url_db.check_url(url):
                pub_date = dateparser.parse(pub_dates[i])
                item = {'source': 'safeandsavvy.f-secure.com', 'url': url, 'pub_date': pub_date, 'author': ''}
                yield item
