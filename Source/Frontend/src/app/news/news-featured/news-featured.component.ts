import { Component, OnInit } from '@angular/core';
import { ArticleRepositoryService } from 'src/app/core/services/repository/article-repository.service';
import { ArticleViewService } from 'src/app/core/services/view/article-view.service';
import { Category, Slide } from 'src/app/shared/article';
import { ActivatedRoute } from '@angular/router';
import { KeyValue } from '@angular/common';

@Component({
  selector: 'news-featured',
  templateUrl: './news-featured.component.html',
  styleUrls: ['./news-featured.component.css']
})

export class NewsFeaturedComponent implements OnInit {
  public slides: { [category: string]: Slide[]} = {};

  private categories: Category[];

  private categoriesSubscription;

  constructor(
    private readonly artcileRepositoryService: ArticleRepositoryService,
    private readonly articleViewService: ArticleViewService,
    private readonly route: ActivatedRoute
  ) { }

  ngOnInit() {
    if(history.state.categories) {
      this.categories = history.state.categories;
      this.loadSlides(this.categories);
    } else {
      this.artcileRepositoryService.getCategories().subscribe((response) => {
        this.categories = response.data as Category[];
        this.loadSlides(this.categories);
      });
    }
  }

  loadSlides(categories: Category[]): void {
    categories.forEach(category => {
      this.artcileRepositoryService.getSlides(category.categoryId).subscribe((response) => {
        this.slides[category.categoryId] = response.data as Slide[];
      });
    });
  }

  getCategoryName(categoryId: string){
    const result = this.categories.find(x => x.categoryId === parseInt(categoryId));
    return result.categoryNameToDisplay;
  }

}
