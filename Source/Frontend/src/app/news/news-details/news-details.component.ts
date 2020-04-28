import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { ArticleDetails, ArticleCardType } from 'src/app/shared/article';
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

  constructor(
    private readonly articleRepositoryService: ArticleRepositoryService,
    private readonly articleViewService: ArticleViewService,
    private readonly route: ActivatedRoute,
    private readonly router: Router
  ) { }

  ngOnInit() {
    this.routeSubscription = this.route.params.subscribe(params => {
    this.articleRepositoryService.getArticleDetails(params['articleId']).subscribe((response) => {
      this.articleDetails = response.data as ArticleDetails;
      this.articleViewService.setArticleDetailsVisibleState(true);
    });
  });
  }

  handleCloseButton() {
    this.articleViewService.setArticleDetailsVisibleState(false);
    const url = `${this.route.parent.snapshot.url[0].toString()}/${this.route.parent.snapshot.url[1].toString()}`;
    this.router.navigateByUrl(url);
  }

  handleRouteLink() {
    this.articleViewService.setArticleDetailsVisibleState(false);
  }

  ngOnDestroy() {
    this.routeSubscription.unsubscribe();
  }
}
