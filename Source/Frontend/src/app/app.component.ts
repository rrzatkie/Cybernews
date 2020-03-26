import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from './shared/article';
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

  constructor(
    private readonly route: ActivatedRoute,
    private readonly artcicleService: ArticleRepositoryService,
    private readonly articleViewService: ArticleViewService
    ) {
  }
  ngOnInit(): void {
    this.artcicleService.getCategories().subscribe((data) => {
      this.categories = data.data as Category[];
      this.articleViewService.setCategories(this.categories);
    });
  }
}
