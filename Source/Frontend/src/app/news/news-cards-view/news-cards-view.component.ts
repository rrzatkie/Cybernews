import { Component, OnInit } from '@angular/core';
import { ArticleCard, ArticleCardType, ArticleDetails } from 'src/app/shared/article';
import { ArticleRepositoryService } from 'src/app/core/services/repository/article-repository.service';
import { ActivatedRoute } from '@angular/router';
import { ArticleViewService } from 'src/app/core/services/view/article-view.service';

@Component({
  selector: 'app-news-cards',
  templateUrl: './news-cards-view.component.html',
  styleUrls: ['./news-cards-view.component.css']
})

export class NewsCardsViewComponent implements OnInit {
  public articles: ArticleCard[];
  public cardType: ArticleCardType = ArticleCardType.Category;
  public queryItemId = 1;

  public selectedArticleDetails: ArticleDetails;
  public isAnySelected: boolean = false;

  public blurOnSelectionStyle = {'filter': 'blur(0px)'};

  constructor(
    private readonly articleRepositoryService: ArticleRepositoryService,
    private readonly route: ActivatedRoute,
    private readonly articleViewService: ArticleViewService
  ) { }

  ngOnInit() {
      this.route.data.subscribe( (data) => {
        this.cardType = data.cardType;
      });

      this.articleViewService.getArticleDetailsVisibleState().subscribe((state) => {
        this.isAnySelected = state;
        this.blurOnSelectionStyle = state ? {'filter': 'blur(8px)'} : {'filter': 'blur(0px)'}
        });

      this.articleRepositoryService.getArticleCards(12, 1, this.cardType, this.queryItemId).subscribe( (response) => {
        this.articles = response.data as ArticleCard[];
      });
   }
}
