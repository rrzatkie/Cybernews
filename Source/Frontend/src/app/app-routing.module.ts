import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticleCardType } from './shared/article';
import { NewsCardsViewComponent } from './news/news-cards-view/news-cards-view.component';
import { NewsFeaturedComponent } from './news/news-featured/news-featured.component';
import { NewsDetailsComponent } from './news/news-details/news-details.component';
import { CardsResolver } from './core/services/resolvers/cards.resolver';
import { NewsCategoriesComponent } from './news/news-categories/news-categories.component';
import { NewsKeywordsComponent } from './news/news-keywords/news-keywords.component';
import { NewsArchiveComponent } from './news/news-archive/news-archive.component';


const routes: Routes = [
  {
    path: 'home',
    component: NewsCardsViewComponent,
    resolve: {response: CardsResolver},
    data: {cardType: ArticleCardType.All, title: 'Latest news', menuActiveLabel: 'home'}
  },
  {
    path: 'category/:id',
    component: NewsCardsViewComponent,
    resolve: {response: CardsResolver},
    data: {cardType: ArticleCardType.Category, title: 'Category', menuActiveLabel: 'categories'}
  },
  {
    path: 'keyword/:id',
    component: NewsCardsViewComponent,
    resolve: {response: CardsResolver},
    data: {cardType: ArticleCardType.Keyword, title: 'Keyword', menuActiveLabel: 'keywords'}
  },
  {
    path: 'details/:id',
    component: NewsDetailsComponent
  },
  {
    path: 'categories',
    component: NewsCategoriesComponent
  },
  {
    path: 'keywords',
    component: NewsKeywordsComponent
  },
  {
    path: 'archive',
    component: NewsArchiveComponent,
    children: [
      {
          path: 'show',
          component: NewsCardsViewComponent,
          resolve: {response: CardsResolver},
          runGuardsAndResolvers: 'always',
          data: {cardType: ArticleCardType.All, menuActiveLabel: 'archive'}
      }
    ]
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: '/home'
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      anchorScrolling: 'enabled',
      scrollPositionRestoration: 'enabled'
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
