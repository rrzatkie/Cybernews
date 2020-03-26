import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticleCardType } from './shared/article';
import { CategoriesResolver } from './core/services/resolvers/categories.resolver';
import { NewsCardsViewComponent } from './news/news-cards-view/news-cards-view.component';
import { NewsFeaturedComponent } from './news/news-featured/news-featured.component';


const routes: Routes = [
  {
    path: 'home',
    component: NewsFeaturedComponent
  },
  {
    path: 'category/:id',
    component: NewsCardsViewComponent,
    data: {cardType: ArticleCardType.Category}
  },
  {
    path: 'keyword/:id',
    component: NewsCardsViewComponent,
    data: {cardType: ArticleCardType.Keyword}
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
