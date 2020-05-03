import scrapy
import dateparser


class TheConversationSpider(scrapy.Spider):
    name = 'theconversation'
    start_urls = ['https://theconversation.com/us/topics/cybersecurity-535']

    def parse(self, response):
        article_urls = response.xpath('//article//div[@class="article--header"]/h2/a/@href').extract()
        pub_dates = response.xpath('//article//time/@datetime').extract()
        authors = response.xpath('//article//p[@class="byline"]/span/a/text()').extract()
        for i, url in enumerate(article_urls):
            if self.seen_url_db.check_url('https://theconversation.com' + url):
                pub_date = dateparser.parse(pub_dates[i])
                author = authors[i]
                item = {'source': 'theconversation.com', 'url': 'https://theconversation.com' + url, 'pub_date':
                        pub_date, 'author': author}
                yield item
