import scrapy
import dateparser


class HelpnetSpider(scrapy.Spider):
    name = 'helpnet'
    start_urls = ['https://www.helpnetsecurity.com/tag/cybersecurity/']

    def parse(self, response):
        article_urls = set(response.xpath('//article//h3[@class="entry-title"]/a/@href').extract())
        pub_dates = response.xpath('//article//time[@class="entry-date"]/@datetime').extract()
        for i, url in enumerate(article_urls):
            if self.seen_url_db.check_url(url):
                pub_date = dateparser.parse(pub_dates[i])
                item = {'source': 'helpnetsecurity.com', 'url': url, 'pub_date': pub_date, 'author': ''}
                yield item
