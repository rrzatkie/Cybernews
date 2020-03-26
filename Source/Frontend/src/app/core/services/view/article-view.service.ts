import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { Category } from 'src/app/shared/article';

@Injectable({
  providedIn: 'root'
})
export class ArticleViewService {
  observableCategories = new Subject<Category[]>();


  constructor() { }

  getCategories(): Observable<Category[]>{
    return this.observableCategories;
  }

  setCategories(categories: Category[]): void {
    this.observableCategories.next(categories);
  }
}
