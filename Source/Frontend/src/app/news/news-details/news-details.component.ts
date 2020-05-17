import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { ArticleDetails, ArticleCardType, Keyword, SimilarArticle } from 'src/app/shared/article';
import { ArticleRepositoryService } from 'src/app/core/services/repository/article-repository.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ArticleViewService } from 'src/app/core/services/view/article-view.service';

@Component({
  selector: 'news-details',
  templateUrl: './news-details.component.html',
  styleUrls: ['./news-details.component.css']
})

export class NewsDetailsComponent implements OnInit, OnDestroy {
   articleDetails: ArticleDetails;
   routeSubscription: Subscription;
   public keywords: Keyword[];
   public similarArticles: SimilarArticle[];

  constructor(
    private readonly articleRepositoryService: ArticleRepositoryService,
    private readonly articleViewService: ArticleViewService,
    private readonly route: ActivatedRoute,
    private readonly router: Router
  ) { }

  ngOnInit() {
    this.routeSubscription = this.route.params.subscribe(params => {
    this.articleRepositoryService.getArticleDetails(params['id']).subscribe((response) => {
      this.articleDetails = response.data as ArticleDetails;
      this.keywords = this.articleDetails.article.articleKeywords.sort((a, b) => b.keywordValue - a.keywordValue);
      this.similarArticles = this.articleDetails.similarArticles.sort((a, b) => b.similarity - a.similarity);
    });
  });
  }

  ngOnDestroy() {
    this.routeSubscription.unsubscribe();
  }
}
