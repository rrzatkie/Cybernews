import scrapy
import dateparser


class InfoSecurityMagSpider(scrapy.Spider):
    name = 'infosecuritymag'
    start_urls = ['https://www.infosecurity-magazine.com/news/']

    def parse(self, response):
        article_urls = response.xpath('//div[@class="webpage-item with-thumbnail"]/a/@href').extract()
        pub_dates = response.xpath('//div[@class="webpage-item with-thumbnail"]//time/@datetime').extract()
        for i, url in enumerate(article_urls):
            if self.seen_url_db.check_url(url):
                pub_date = dateparser.parse(pub_dates[i])
                item = {'source': 'infosecurity-magazine.com', 'url': url, 'pub_date': pub_date, 'author': ''}
                yield item
