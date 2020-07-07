import scrapy
import dateparser


class TechTalkSpider(scrapy.Spider):
    name = 'techtalk'
    start_urls = ['https://techtalk.gfi.com/category/security/']

    def parse(self, response):
        article_urls = response.xpath('//div[@class="post-entry"]//div[@class="post-title"]/h3/a/@href').extract()
        pub_dates = response.xpath('//div[@class="post-entry"]//time[@class="entry-date"]/@datetime').extract()
        authors = [author.strip()[:-3] for author in response.xpath(
            '//div[@class="post-entry"]//div[@class="author-date"]/text()').extract() if author.strip()[:-3] != '']
        for i, url in enumerate(article_urls):
            if self.seen_url_db.check_url(url):
                pub_date = dateparser.parse(pub_dates[i])
                author = authors[i]
                item = {'source': 'techtalk.gfi.com', 'url': url, 'pub_date': pub_date, 'author': author}
                yield item
