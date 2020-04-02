import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { CybernewsApiResponse, ArticleCardType } from '../../../shared/article';
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
    queryItemId = id ? id : 1;

    cardType = route.data.cardType as ArticleCardType;

    return this.articleRepositoryService.getArticleCards(12, 1, cardType, queryItemId);
  }
}
