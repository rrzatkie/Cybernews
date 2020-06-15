import { Component, OnInit, Input } from '@angular/core';
import { SearchResultDto } from 'src/app/shared/search';
import { SearchService } from 'src/app/core/services/search/search.service';
import { Observable, Subject, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap, map, catchError } from 'rxjs/operators';
import { Router, ActivatedRouteSnapshot } from '@angular/router';

export enum SearchType {
  Articles = 0,
  Keywords = 1,
  Categories = 2
}

@Component({
  selector: 'app-news-search',
  templateUrl: './news-search.component.html',
  styleUrls: ['./news-search.component.scss']
})
export class NewsSearchComponent implements OnInit {
  public keyword = '';
  public results = new Subject<string>();
  public SearchType = SearchType;
  @Input() type: SearchType = SearchType.Articles;

  searchTypeNames: { [index: number]: string } = {};

  formatter(x) {
    switch (this.type) {
      case SearchType.Articles:
        return x.articleTitle.toLocaleUpperCase();
      case SearchType.Keywords:
          return x.keywordName.toLocaleUpperCase();
      case SearchType.Categories:
        return x.categoryName.toLocaleUpperCase();
      default:
        return '';
    }
  }

  constructor(
    private readonly service: SearchService,
    private readonly router: Router
  ) { }

  ngOnInit() {
    this.searchTypeNames[SearchType.Articles] = 'Articles';
    this.searchTypeNames[SearchType.Keywords] = 'Keywords';
    this.searchTypeNames[SearchType.Categories] = 'Categories';
  }

  changeType(value: SearchType) {
    this.type = value;
  }

  select(event) {
    switch (this.type) {
      case SearchType.Articles:
        this.router.navigate(['/details/', event.item.articleId]);
        break;

      case SearchType.Keywords:
        this.router.navigate(['/keyword/', event.item.keywordId]);
        break;

      case SearchType.Categories:
        this.router.navigate(['/category/', event.item.categoryId]);
        break;

      default:
        break;
    }
  }

  search = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap(term => {
        if (term !== '') {
          return this.service.search(this.type, term).pipe(
            map((x: SearchResultDto) => {
              switch (this.type) {
                case SearchType.Articles:
                  return x.articles;

                case SearchType.Keywords:
                  return x.keywords;

                case SearchType.Categories:
                  return x.categories;

                default:
                  break;
              }
            }),
            catchError(() => {
              return of([]);
            }));
          } else {
            return of([]);
          }
        }
      )
    )
}
