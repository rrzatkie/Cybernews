import { Component, OnInit, Input } from '@angular/core';
import { ArticlesArchive, Query, PaginationOptions, ArticleCardsList } from 'src/app/shared/article';
import { ArticleRepositoryService } from 'src/app/core/services/repository/article-repository.service';
import { ArticleViewService } from 'src/app/core/services/view/article-view.service';
import { ActivatedRoute, Router } from '@angular/router';
import { KeyValuePipe } from '@angular/common';

@Component({
  selector: 'app-news-archive',
  templateUrl: './news-archive.component.html',
  styleUrls: ['./news-archive.component.scss']
})
export class NewsArchiveComponent implements OnInit {
  public articlesArchives: ArticlesArchive[];
  public articleArchiveGroups: Array<any>;
  public months = [
    'Jan', 'Feb', 'Mar',
    'Apr', 'May', 'Jun', 'Jul', 'Aug',
    'Sep', 'Oct', 'Nov', 'Dec'
  ];

  public selectedYear;
  public availableArchives;
  public selectedMonth;
  public articleCardsList: ArticleCardsList;

  constructor(
    private readonly artcileRepositoryService: ArticleRepositoryService,
    private readonly articleViewService: ArticleViewService,
    private readonly route: ActivatedRoute,
    private readonly pipe: KeyValuePipe,
    private readonly router: Router
  ) { }

  ngOnInit() {
    this.articleViewService.setMenuItemActiveState('archive');
    this.artcileRepositoryService.getArticlesArchive().subscribe((response) => {
      this.articlesArchives = response.data as ArticlesArchive[];
      this.articleArchiveGroups = this.groupArtcilesArchivesByYear(this.articlesArchives);
      this.articleArchiveGroups = this.articleArchiveGroups.sort((a, b) => parseInt(b.key) - parseInt(a.key));
      this.articleArchiveGroups.forEach(group => {
        group = group.value.sort((a, b) => this.months.indexOf(b.month) - this.months.indexOf(a.month));
      });
    });
  }

  groupArtcilesArchivesByYear(articles: ArticlesArchive[]) {
    return this.pipe.transform (
      articles.reduce( (g: any, articleArchive: ArticlesArchive) => {
        g[articleArchive.year] = g[articleArchive.year] || [];
        g[articleArchive.year].push(articleArchive);
        return g;
      }, {})
    );
  }

  selectYear(year) {
    this.selectedYear = year;
    this.availableArchives = this.articleArchiveGroups.find(x => x.key === year).value;
  }

  selectMonth(month) {
    this.selectedMonth = month;
  }

  openArchive(month, year) {
    const y = parseInt(year, 10);
    const m = this.months.indexOf(month);

    let dateFrom = new Date(y, m, 1).toISOString();
    let dateTo = new Date(new Date(y, (m + 1), 1).setDate((new Date(y, (m + 1), 1).getDate()) - 1)).toISOString();

    const query: Query = {
      dateCreatedFrom: dateFrom,
      dateCreatedTo: dateTo
    };

    const paginationOptions: PaginationOptions = {
      limit: 10,
      pageNumber: 1
    };

    this.router.navigate(['/archive/show'], { queryParams: { 'dateFrom': dateFrom, 'dateTo': dateTo} });
  }
}
