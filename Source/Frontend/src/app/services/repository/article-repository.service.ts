import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ConfigurationService } from 'src/app/core/services/configuration/configuration/configuration.service';

export interface SlidesList{
  slides: Slide[];
  count: number;
}

export interface Slide{
  articleId: string;
  articleImgUrl: string;
  articleTitle: string;
  articleUrl: string;
}

export interface Category{
  categoryId: string;
  categoryNameToDisplay: string;
  categorySlug: string;
}

export interface Keyword{
  keywordId: string;
  keywordNameToDisplay: string;
  keywordSlug: string;
}

export interface ArticleCard{
  articleId: string;
  articleImgUrl: string;
  articleTitle: string;
  articleUrl: string;
  articleDate: string;
  articleCategory: Category;
}

export interface ArticleDetails{
  articleId: string;
  articleImgUrl: string;
  articleTitle: string;
  articleUrl: string;
  articleKeywords: Keyword[];
}

@Injectable({
  providedIn: 'root'
})
export class ArticleRepositoryService {
  private readonly articleApiUrl;

  constructor(
    private readonly http: HttpClient,
    private readonly configuration: ConfigurationService) {
      this.articleApiUrl = configuration.environmentConfiguration.CybernewsApi.Url + 'ArticlesUI';
   }

  getSlides(category: string): Observable<SlidesList>{
    const url = `${this.articleApiUrl}/slides/${category}`;
    return this.http.get<SlidesList>(url, {observe: 'response' })
      .pipe(
        map(response => {
          return response.body;
        })
    );
  }

  getArticleCard(id: number): Observable<ArticleCard>{
    const url = `${this.articleApiUrl}/articleCard/${id}`;

    return this.http.get<ArticleCard>(url, {observe: 'response' })
      .pipe(
        map(response => {
          return response.body;
        })
    );
  }

  getArticleDetails(id: number): Observable<ArticleDetails>{
    const url = `${this.articleApiUrl}/articleDetails/${id}`;

    return this.http.get<ArticleDetails>(url, {observe: 'response' })
      .pipe(
        map(response => {
          return response.body;
        })
    );
  }

  getCategories(): Observable<Category[]>{
    const url = `${this.articleApiUrl}/categories`;

    return this.http.get<Category[]>(url, {observe: 'response' })
      .pipe(
        map(response => {
          return response.body;
        })
    );
  }

  

}
