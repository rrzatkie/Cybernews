import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { CybernewsApiResponse } from '../../../shared/article';
import { Observable } from 'rxjs';
import { ArticleRepositoryService } from '../repository/article-repository.service';

@Injectable({
  providedIn: 'root'
})
export class CategoriesResolver implements Resolve<CybernewsApiResponse> {

  constructor(
    private readonly articleRepositoryService: ArticleRepositoryService
  ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<CybernewsApiResponse> {
    return this.articleRepositoryService.getCategories();
  }
}
