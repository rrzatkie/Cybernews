import { Component, OnInit } from '@angular/core';
import { ArticleCard, ArticleCardType } from 'src/app/shared/article';
import { ArticleRepositoryService } from 'src/app/core/services/repository/article-repository.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-news-cards',
  templateUrl: './news-cards-view.component.html',
  styleUrls: ['./news-cards-view.component.css']
})

export class NewsCardsViewComponent implements OnInit {
  public articles: ArticleCard[];
  public cardType: ArticleCardType = ArticleCardType.Category;
  public queryItemId = 1;

  constructor(
    private readonly articleRepositoryService: ArticleRepositoryService,
    private readonly route: ActivatedRoute
  ) { }

  ngOnInit() {
      this.route.data.subscribe( (data) => {
        this.cardType = data.cardType;
      });
      this.articleRepositoryService.getArticleCards(12, 1, this.cardType, this.queryItemId).subscribe( (response) => {
        this.articles = response.data as ArticleCard[];
      });
   }
}
