import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ConfigurationService } from 'src/app/core/services/configuration//configuration.service';
import { CybernewsApiResponse, PaginationOptions, Query, ArticleCardType } from 'src/app/shared/article';
import { KeyValuePipe } from '@angular/common';


@Injectable({
  providedIn: 'root'
})
export class ArticleRepositoryService {
  private readonly articleApiUrl;

  constructor(
    private readonly http: HttpClient,
    private readonly pipe: KeyValuePipe,
    private readonly configuration: ConfigurationService) {
      this.articleApiUrl = configuration.environmentConfiguration.CybernewsApi.Url + 'ArticlesUI';
   }

   objectsToQueryString(objs: Array<any>): HttpParams {
    let httpParams = new HttpParams();

    objs.forEach(obj => {
      obj = this.pipe.transform(obj);
      obj.forEach(item => {
        httpParams = httpParams.set(item.key, item.value);
      });
    });

    return httpParams;
  }

  getSlides(categoryId: number): Observable<CybernewsApiResponse> {
    const url = `${this.articleApiUrl}/slides/${categoryId}`;
    return this.http.get<CybernewsApiResponse>(url, {observe: 'response' })
      .pipe(
        map(response => {
          return response.body;
        })
    );
  }

  getArticleCards(limit: number, pageNumber: number, type: ArticleCardType, id: number): Observable<CybernewsApiResponse> {
    const paginationOptions: PaginationOptions = {
      limit,
      pageNumber
    };
    const searchOptions: Query = {
      type,
      itemId: id
    };
    const httpParams = this.objectsToQueryString([paginationOptions, searchOptions]);

    const url = `${this.articleApiUrl}/articleCards`;

    return this.http.get<CybernewsApiResponse>(url, {
        observe: 'response',
        params: httpParams
      }).pipe(
          map(response => {
            return response.body;
          })
      );
  }

  getArticleDetails(id: number): Observable<CybernewsApiResponse> {
    const url = `${this.articleApiUrl}/articleDetails/${id}`;

    return this.http.get<CybernewsApiResponse>(url, {observe: 'response' })
      .pipe(
        map(response => {
          return response.body;
        })
    );
  }

  getCategories(): Observable<CybernewsApiResponse> {
    const url = `${this.articleApiUrl}/categories`;

    return this.http.get<CybernewsApiResponse>(url, {observe: 'response' })
      .pipe(
        map(response => {
          return response.body;
        })
    );
  }



}
