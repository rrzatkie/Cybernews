import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { CybernewsApiResponse, ArticleCardType, PaginationOptions, Query } from '../../../shared/article';
import { Observable } from 'rxjs';
import { ArticleRepositoryService } from '../repository/article-repository.service';

@Injectable({
  providedIn: 'root'
})
export class CardsResolver implements Resolve<CybernewsApiResponse> {


  constructor(
    private readonly articleRepositoryService: ArticleRepositoryService
  ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<CybernewsApiResponse> {
    let queryItemId = 0;
    let cardType: ArticleCardType;
    const id = parseInt(route.paramMap.get('id'), 10);
    const dateFrom = route.queryParamMap.get('dateFrom');
    const dateTo = route.queryParamMap.get('dateTo');

    queryItemId = id ? id : queryItemId;

    cardType = route.data.cardType as ArticleCardType;

    const paginationOptions: PaginationOptions = {
      limit: 10,
      pageNumber: 1
    };

    const query: Query = {
      itemId: queryItemId,
      type: cardType,
      dateCreatedTo: dateTo,
      dateCreatedFrom: dateFrom
    };

    return this.articleRepositoryService.getArticleCards(paginationOptions, query);
  }
}
