import { Component, OnInit, Input } from '@angular/core';
import { Category, CategorySummary, ArticleCard, KeywordSummary, ArticlesArchive } from 'src/app/shared/article';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  @Input() categoriesSummary: CategorySummary[];
  @Input() topArticles: ArticleCard[];
  @Input() topKeywords: KeywordSummary[];
  @Input() articlesArchives: ArticlesArchive[];

  constructor() { }

  ngOnInit() {
  }

}
