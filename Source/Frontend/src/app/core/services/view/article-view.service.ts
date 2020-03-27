import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { Category } from 'src/app/shared/article';

@Injectable({
  providedIn: 'root'
})
export class ArticleViewService {
  private categories = new Subject<Category[]>();
  private articleDetailsVisibleState = new Subject<boolean>();


  constructor() { }

  getCategories(): Observable<Category[]>{
    return this.categories;
  }

  setCategories(categories: Category[]): void {
    this.categories.next(categories);
  }

  getArticleDetailsVisibleState(): Observable<boolean> {
    return this.articleDetailsVisibleState;
  }

  setArticleDetailsVisibleState(state: boolean): void {
    this.articleDetailsVisibleState.next(state);
  }
}
