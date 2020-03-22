import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { ArticleCard, ArticleCardType } from '../shared/article';
import { ArticleRepositoryService } from '../services/repository/article-repository.service';

@Component({
  selector: 'app-category-view',
  templateUrl: './category-view.component.html',
  styleUrls: ['./category-view.component.css']
})
export class CategoryViewComponent implements OnInit {
  categoryId = 0;
  type: ArticleCardType;

  articles : ArticleCard[] = [];

  limit = 12;
  pageNumber = 1;

  constructor(
    private readonly route: ActivatedRoute,
    private readonly articleService: ArticleRepositoryService
  ) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.type = data.type;
    });

    this.categoryId = history.state.categoryId;

    this.articleService.getArticleCards(this.limit, this.pageNumber, this.type, this.categoryId).subscribe( (response) => {
      this.articles = response.data as ArticleCard[];
    });
  }

}
