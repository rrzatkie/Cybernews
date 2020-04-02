import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ArticleCard, ArticleCardType, ArticleDetails, ArticleCardsList } from 'src/app/shared/article';
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
  public title = "Category";

  public selectedArticleDetails: ArticleDetails;
  public isAnySelected: boolean = false;

  public blurOnSelectionStyle = {'filter': 'blur(0px)'};

  constructor(
    private readonly articleRepositoryService: ArticleRepositoryService,
    private readonly route: ActivatedRoute,
    private readonly articleViewService: ArticleViewService,
    private readonly ref: ChangeDetectorRef
  ) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      const response = data.response.data as ArticleCardsList;
      this.articles = response.articleCards;
      this.title = this.articles[0].articleCategories.find( x => x.categoryId === response.queryItemId).categoryNameToDisplay;
    });

    this.articleViewService.getArticleDetailsVisibleState().subscribe((state) => {
      this.isAnySelected = state;
      this.blurOnSelectionStyle = state ? {'filter': 'blur(8px)'} : {'filter': 'blur(0px)'};
      });
  }

  detectChanges() {
    this.ref.detectChanges();
  }

}
