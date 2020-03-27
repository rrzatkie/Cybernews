import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticleCardType } from './shared/article';
import { CategoriesResolver } from './core/services/resolvers/categories.resolver';
import { NewsCardsViewComponent } from './news/news-cards-view/news-cards-view.component';
import { NewsFeaturedComponent } from './news/news-featured/news-featured.component';
import { NewsDetailsComponent } from './news/news-details/news-details.component';


const routes: Routes = [
  {
    path: 'home',
    component: NewsFeaturedComponent
  },
  {
    path: 'category/:id',
    component: NewsCardsViewComponent,
    data: {cardType: ArticleCardType.Category},
    children: [
      {
        path: "details/:articleId",
        component: NewsDetailsComponent
      }
    ]
  },
  {
    path: 'keyword/:id',
    component: NewsCardsViewComponent,
    data: {cardType: ArticleCardType.Keyword},
    children: [
      {
        path: "details/:articleId",
        component: NewsDetailsComponent
      }
    ]
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
