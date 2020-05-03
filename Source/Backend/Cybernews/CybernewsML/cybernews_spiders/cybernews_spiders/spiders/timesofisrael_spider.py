import scrapy
import dateparser


class TimesOfIsraelSpider(scrapy.Spider):
    name = 'timesofisrael'
    start_urls = ['https://www.timesofisrael.com/topic/cybersecurity']

    def parse(self, response):
        article_urls = response.xpath('//div[@class="item template1 news"]//div[@class="headline"]/a/@href').extract()
        pub_dates = response.xpath('//div[@class="item template1 news"]//div[@class="date"]/text()').extract()
        authors = [", ".join(author.xpath('a/text()').extract()) for author in
                   response.xpath('//div[@class="item template1 news"]//div[@class="byline"]')]
        for i, url in enumerate(article_urls):
            if self.seen_url_db.check_url(url):
                pub_date = dateparser.parse(pub_dates[i])
                author = authors[i]
                item = {'source': 'timesofisrael.com', 'url': url, 'pub_date': pub_date, 'author': author}
                yield item
