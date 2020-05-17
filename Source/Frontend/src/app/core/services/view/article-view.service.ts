import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { Category } from 'src/app/shared/article';

@Injectable({
  providedIn: 'root'
})
export class ArticleViewService {
  private articleDetailsVisibleState = new Subject<string>();


  constructor() { }

  getMenuItemActiveState(): Observable<string> {
    return this.articleDetailsVisibleState;
  }

  setMenuItemActiveState(id: string): void {
    this.articleDetailsVisibleState.next(id);
  }
}
