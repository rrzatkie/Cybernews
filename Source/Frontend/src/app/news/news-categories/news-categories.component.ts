import { Component, OnInit } from '@angular/core';
import { ArticleRepositoryService } from 'src/app/core/services/repository/article-repository.service';
import { ArticleViewService } from 'src/app/core/services/view/article-view.service';
import { Category, Slide } from 'src/app/shared/article';
import { ActivatedRoute } from '@angular/router';
import { KeyValue } from '@angular/common';

@Component({
  selector: 'news-categories',
  templateUrl: './news-categories.component.html',
  styleUrls: ['./news-categories.component.scss']
})

export class NewsCategoriesComponent implements OnInit {
  public slides: { [category: string]: Slide[]} = {};

  public categories: Category[];

  constructor(
    private readonly artcileRepositoryService: ArticleRepositoryService,
    private readonly articleViewService: ArticleViewService,
    private readonly route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.articleViewService.setMenuItemActiveState('categories');
    if(history.state.categories) {
      this.categories = history.state.categories;
    } else {
      this.artcileRepositoryService.getCategories().subscribe((response) => {
        this.categories = response.data as Category[];
      });
    }
  }

  getCategoryName(categoryId: string){
    const result = this.categories.find(x => x.categoryId === parseInt(categoryId));
    return result.categoryNameToDisplay;
  }

}
