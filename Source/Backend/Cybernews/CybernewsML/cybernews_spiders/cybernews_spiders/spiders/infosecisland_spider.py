import scrapy
import dateparser


class InfosecIslandSpider(scrapy.Spider):
    name = 'infosecisland'
    start_urls = ['http://www.infosecisland.com']

    def parse(self, response):
        article_urls = response.xpath(
            '//div[@class="listing clearfix"]//div[@class="listingcontent"]/h2/a/@href').extract()
        pub_dates = response.xpath('//div[@class="listing clearfix"]//div[@class="listingcontent"]/h3/text()').extract()
        authors = response.xpath(
            '//div[@class="listing clearfix"]//div[@class="listingcontent"]/h3/span/a/text()').extract()
        for i, url in enumerate(article_urls):
            if self.seen_url_db.check_url('http://www.infosecisland.com' + url):
                pub_date = dateparser.parse(pub_dates[i])
                author = authors[i]
                item = {'source': 'infosecisland.com', 'url': 'http://www.infosecisland.com' + url, 'pub_date':
                        pub_date, 'author': author}
                yield item
