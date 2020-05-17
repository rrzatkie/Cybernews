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
      this.articleApiUrl = configuration.environmentConfiguration.CybernewsApi.Url;
   }

   objectsToQueryString(objs: Array<any>): HttpParams {
    let httpParams = new HttpParams();

    objs.forEach(obj => {
      obj = this.pipe.transform(obj);
      obj.forEach(item => {
        if(item.value){
          httpParams = httpParams.set(item.key, item.value);
        }
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

  getArticleCards(paginationOptions?: PaginationOptions, searchOptions?: Query): Observable<CybernewsApiResponse> {
    const url = `${this.articleApiUrl}/articleCards`;
    const objParams = [];

    if (paginationOptions) {
      objParams.push(paginationOptions);
    }

    if (searchOptions) {
      objParams.push(searchOptions);
    }
    const httpParams = this.objectsToQueryString(objParams);

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

  getTopArticles(searchOptions?: Query): Observable<CybernewsApiResponse> {
    const url = `${this.articleApiUrl}/articles/top`;

    const objParams = [];

    if (searchOptions) {
      objParams.push(searchOptions);
    }

    const httpParams = this.objectsToQueryString(objParams);

    return this.http.get<CybernewsApiResponse>(url, {
      observe: 'response',
      params: httpParams
    }).pipe(
        map(response => {
          return response.body;
        })
    );
  }


  getArticlesArchive(searchOptions?: Query): Observable<CybernewsApiResponse> {
    const url = `${this.articleApiUrl}/articles/archive`;

    const objParams = [];

    if (searchOptions) {
      objParams.push(searchOptions);
    }

    const httpParams = this.objectsToQueryString(objParams);

    return this.http.get<CybernewsApiResponse>(url, {
      observe: 'response',
      params: httpParams
    }).pipe(
        map(response => {
          return response.body;
        })
    );
  }

  getCategories(): Observable<CybernewsApiResponse> {
    const url = `${this.articleApiUrl}/categories/all`;

    return this.http.get<CybernewsApiResponse>(url, {observe: 'response' })
      .pipe(
        map(response => {
          return response.body;
        })
    );
  }

  getTopCategories(query: Query): Observable<CybernewsApiResponse> {
    const url = `${this.articleApiUrl}/categories/top`;

    const objParams = [];
    if (query) {
      objParams.push(query);
    }
    const httpParams = this.objectsToQueryString(objParams);

    return this.http.get<CybernewsApiResponse>(url, {
      observe: 'response',
      params: httpParams
    }).pipe(
        map(response => {
          return response.body;
        })
    );
  }

  getTopKeywords(query?: Query): Observable<CybernewsApiResponse> {
    const url = `${this.articleApiUrl}/keywords/top`;

    const objParams = [];
    if (query) {
      objParams.push(query);
    }
    const httpParams = this.objectsToQueryString(objParams);

    return this.http.get<CybernewsApiResponse>(url, {
      observe: 'response',
      params: httpParams
    }).pipe(
        map(response => {
          return response.body;
        })
    );
  }

  getKeywords(): Observable<CybernewsApiResponse> {
    const url = `${this.articleApiUrl}/keywords/all`;

    return this.http.get<CybernewsApiResponse>(url, {observe: 'response' })
      .pipe(
        map(response => {
          return response.body;
        })
    );
  }



}
