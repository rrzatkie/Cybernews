import { Component, OnInit } from '@angular/core';
import { ArticleRepositoryService } from 'src/app/core/services/repository/article-repository.service';
import { ArticleViewService } from 'src/app/core/services/view/article-view.service';
import { Category, Slide, PaginationOptions, ArticleCard, ArticleCardsList } from 'src/app/shared/article';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'news-featured',
  templateUrl: './news-featured.component.html',
  styleUrls: ['./news-featured.component.scss']
})

export class NewsFeaturedComponent implements OnInit {
  public slides: { [category: string]: Slide[]} = {};
  private categories: Category[];
  private categoriesSubscription;

  public articleCardsList: ArticleCardsList;

  constructor(
    private readonly artcileRepositoryService: ArticleRepositoryService,
    private readonly articleViewService: ArticleViewService,
    private readonly route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.articleViewService.setMenuItemActiveState('home');
    if(history.state.categories) {
      this.categories = history.state.categories;
    } else {
      this.artcileRepositoryService.getCategories().subscribe((response) => {
        this.categories = response.data as Category[];
      });
    }

    const paginationOtions: PaginationOptions = {
      limit: 10,
      pageNumber: 1
    };
    this.artcileRepositoryService.getArticleCards(paginationOtions).subscribe((response) => {
      this.articleCardsList = response.data as ArticleCardsList;
    });
  }

  getCategoryName(categoryId: string){
    const result = this.categories.find(x => x.categoryId === parseInt(categoryId));
    return result.categoryNameToDisplay;
  }

}
