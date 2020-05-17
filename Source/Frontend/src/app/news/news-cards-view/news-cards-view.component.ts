import { Component, OnInit, ChangeDetectorRef, Input } from '@angular/core';
import { ArticleCard, ArticleCardType, ArticleDetails, ArticleCardsList, PaginationOptions } from 'src/app/shared/article';
import { ArticleRepositoryService } from 'src/app/core/services/repository/article-repository.service';
import { ActivatedRoute } from '@angular/router';
import { ArticleViewService } from 'src/app/core/services/view/article-view.service';
import { KeyValuePipe } from '@angular/common';

@Component({
  selector: 'app-news-cards',
  templateUrl: './news-cards-view.component.html',
  styleUrls: ['./news-cards-view.component.scss']
})

export class NewsCardsViewComponent implements OnInit {
  @Input() articleCardsList: ArticleCardsList;
  public articlesGroups: any;
  public ArticleCardType = ArticleCardType;
  public cardType: ArticleCardType = this.ArticleCardType.Category;
  public queryItemId = 1;
  public title = '';

  public selectedArticleDetails: ArticleDetails;
  public isAnySelected: boolean = false;
  public limit = 10;
  public page = 1;

  constructor(
    private readonly artcileRepositoryService: ArticleRepositoryService,
    private readonly route: ActivatedRoute,
    private readonly pipe: KeyValuePipe,
    private readonly articleViewService: ArticleViewService,
  ) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.articleViewService.setMenuItemActiveState(data.menuActiveLabel);
      if (data['response']) {
        this.articleCardsList = data.response.data as ArticleCardsList;
        this.articlesGroups = this.groupArtcilesByDate(this.articleCardsList.articleCards);
      }
      this.title = data.title;
      this.cardType = data.cardType;
    });
  }

  groupArtcilesByDate(articles: ArticleCard[]) {
    let result: Array<any>;
    result = this.pipe.transform (
      articles.reduce( (g: any, article: ArticleCard) => {
        g[article.articleDateCreated] = g[article.articleDateCreated] || [];
        g[article.articleDateCreated].push(article);
        return g;
      }, {})
    );

    result = result.sort((a, b) => new Date(b.key).valueOf()- new Date(a.key).valueOf());
    return result;
  }

  pageChanged(page) {
    const paginationOtions: PaginationOptions = {
      limit: this.limit,
      pageNumber: page
    };
    this.artcileRepositoryService.getArticleCards(paginationOtions).subscribe((response) => {
      this.articleCardsList = response.data as ArticleCardsList;
      this.articlesGroups = this.groupArtcilesByDate(this.articleCardsList.articleCards);
    });

    const scrollOptions: ScrollToOptions = {
      top: 0,
      left: 0,
      behavior: 'smooth'
    };
    window.scroll(scrollOptions);
  }
}
