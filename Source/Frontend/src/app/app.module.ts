import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { NewsSliderComponent } from './home-page/news-slider/news-slider.component';
import {NavbarModule} from './navbar/navbar.module';
import { HomePageComponent } from './home-page/home-page.component';
import { CategoryViewComponent } from './category-view/category-view.component';
import { ArticleViewComponent } from './category-view/article-view/article-view.component';

@NgModule({
   declarations: [
      AppComponent,
      NewsSliderComponent,
      HomePageComponent,
      CategoryViewComponent,
      ArticleViewComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      NgbModule,
      NavbarModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
