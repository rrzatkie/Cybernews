import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category, CategorySummary, ArticleCard, KeywordSummary, ArticlesArchive, Query } from './shared/article';
import { ArticleRepositoryService } from './core/services/repository/article-repository.service';
import { ArticleViewService } from './core/services/view/article-view.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'cybernews';

  public categories: Category[];
  public categoriesSummary: CategorySummary[];
  public topArticles: ArticleCard[];
  public topKeywords: KeywordSummary[];
  public articlesArchives: ArticlesArchive[];

  constructor(
    private readonly route: ActivatedRoute,
    private readonly artcicleService: ArticleRepositoryService,
    private readonly articleViewService: ArticleViewService
    ) {
  }
  ngOnInit(): void {
    const dateTo = new Date();
    let dateFrom = new Date();
    dateFrom.setDate(dateFrom.getDate() - 60);

    const query: Query = {
      dateCreatedFrom: dateFrom.toUTCString(),
      dateCreatedTo: dateTo.toUTCString()
    };

    this.artcicleService.getCategories().subscribe((data) => {
      this.categories = data.data as Category[];
    });

    this.artcicleService.getTopCategories(query).subscribe((data) => {
      this.categoriesSummary = data.data as CategorySummary[];
    });

    this.artcicleService.getTopArticles(query).subscribe((data) => {
      this.topArticles = data.data as ArticleCard[];
    });
    this.artcicleService.getTopKeywords(query).subscribe((data) => {
      this.topKeywords = data.data as KeywordSummary[];
      this.topKeywords = this.topKeywords.sort((a, b) => b.count - a.count);
    });

    this.artcicleService.getArticlesArchive(query).subscribe((data) => {
      this.articlesArchives = data.data as ArticlesArchive[];
    });

  }

  burgermenu() {
    if(document.body.classList.contains('offcanvas')) {
      document.getElementById('burgermenu').classList.remove('active');
      document.body.classList.remove('offcanvas');
    }
    else {
      document.getElementById('burgermenu').classList.add('active');
      document.body.classList.add('offcanvas')
    }
  }
}
