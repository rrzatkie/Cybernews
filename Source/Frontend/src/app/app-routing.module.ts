import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { CategoryViewComponent } from './category-view/category-view.component';
import { ArticleCardType } from './shared/article';


const routes: Routes = [
  {
    path: 'home',
    component: HomePageComponent,
  },
  {
    path: 'category/:categoryId',
    component: CategoryViewComponent,
    data: {type: ArticleCardType.Category}
  },
  {
    path: 'keyword/:keywordId',
    component: CategoryViewComponent,
    data: {type: ArticleCardType.Keyword}
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
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
