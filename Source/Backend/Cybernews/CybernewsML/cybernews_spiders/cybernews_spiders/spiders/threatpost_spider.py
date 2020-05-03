import scrapy
import dateparser


class ThreatPostSpider(scrapy.Spider):
    name = 'threatpost'
    start_urls = ['https://threatpost.com/blog/']

    def parse(self, response):
        article_urls = response.xpath('//div[@id="latest-posts"]/article//h3[@class="entry-title"]/a/@href').extract()
        pub_dates = response.xpath('//div[@id="latest-posts"]/article//time/@datetime').extract()
        authors = response.xpath('//div[@id="latest-posts"]/article//span[@itemprop="author"]/a/text()').extract()
        for i, url in enumerate(article_urls):
            if self.seen_url_db.check_url(url):
                pub_date = dateparser.parse(pub_dates[i])
                author = authors[i]
                item = {'source': 'threatpost.com', 'url': url, 'pub_date': pub_date, 'author': author}
                yield item
