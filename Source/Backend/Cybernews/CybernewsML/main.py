import scrapy
from twisted.internet import reactor
from scrapy.crawler import CrawlerRunner
from scrapy.utils.log import configure_logging
from scrapy.utils.project import get_project_settings


from cybernews_pipeline.pipeline import pipeline
from cybernews_pipeline.shared.logger import logger_init
from cybernews_pipeline.shared.file_helper import file_helper

from cybernews_spiders.cybernews_spiders.spiders import arcyber_spider, arstechnica_spider, darkreading_spider, europol_spider, gov_ncsc_spider, gov_uscert_spider, helpnet_spider, infosecisland_spider, infosecuritymag_spider, itnews_spider, nextgov_spider, safeandsavvy_spider, techtalk_spider, theconversation_spider, thehill_spider, theregister_spider, threatpost_spider, timesofisrael_spider, wired_spider, zdnet_spider 
from cybernews_spiders.cybernews_spiders import settings
from os.path import basename, splitext, abspath, dirname

__ROOT_DIR__ = dirname(abspath(__file__))

def main():
    # spiders = [
    #     arcyber_spider.ArcyberSpider,
    #     arstechnica_spider.ArstechnicaSpider,
    #     darkreading_spider.DarkReadingSpider, 
    #     europol_spider.EuropolSpider, 
    #     gov_ncsc_spider.NCSCSpider, 
    #     gov_uscert_spider.USCertSpider, 
    #     helpnet_spider.HelpnetSpider, 
    #     infosecisland_spider.InfosecIslandSpider, 
    #     infosecuritymag_spider.InfoSecurityMagSpider, 
    #     itnews_spider.ITNewsSpider, 
    #     nextgov_spider.NextGovSpider, 
    #     safeandsavvy_spider.SafeAndSavvySpider, 
    #     techtalk_spider.TechTalkSpider, 
    #     theconversation_spider.TheConversationSpider, 
    #     thehill_spider.TheHillSpider, 
    #     theregister_spider.TheRegisterSpider, 
    #     threatpost_spider.ThreatPostSpider, 
    #     timesofisrael_spider.TimesOfIsraelSpider, 
    #     wired_spider.WiredSpider, 
    #     zdnet_spider.ZdnetSpider
    # ]
    
    # configure_logging()
    # runner = CrawlerRunner()
    # runner.settings.setmodule(settings)

    # for spider in spiders:
    #     runner.crawl(spider)
    
    # d = runner.join()
    # d.addBoth(lambda _: reactor.stop())
    # reactor.run()

    logger = logger_init(__ROOT_DIR__, splitext(basename(__file__))[0])
    helper = file_helper(
        logger,
        pickles_path="{}/pickles".format(__ROOT_DIR__),
        data_path="{}/data".format(__ROOT_DIR__)
    )
    apiUrl = 'http://localhost:4201/api'

    p = pipeline(logger, helper, apiUrl)
    p.run()

if __name__ == '__main__':
    main()