import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from "@angular/common";

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatGridListModule } from "@angular/material/grid-list";
import { MatDividerModule } from "@angular/material/divider";
import { MatButtonModule } from "@angular/material/button";
import { MatTabsModule } from "@angular/material/tabs";

import { NewsCardComponent } from './news-card/news-card.component';
import { NewsCardsViewComponent } from './news-cards-view/news-cards-view.component';
import { NewsSliderComponent } from './news-slider/news-slider.component';
import { NewsFeaturedComponent } from './news-featured/news-featured.component';
import { DefaultImageDirective } from "./news-slider/default-image.directive";
import { MatCardModule } from "@angular/material/card";
import { RouterModule } from '@angular/router';
import { MatChipsModule } from "@angular/material/chips";


@NgModule({
  imports: [
    BrowserModule,
    NgbModule,
    CommonModule,
    MatGridListModule,
    MatDividerModule,
    RouterModule,
    MatButtonModule,
    MatTabsModule,
    MatCardModule,
    MatChipsModule
  ],
  exports: [
    NewsCardComponent,
    NewsCardsViewComponent,
    NewsSliderComponent,
    RouterModule,
    NewsFeaturedComponent
  ],
  declarations: [
    NewsCardComponent,
    NewsCardsViewComponent,
    NewsSliderComponent,
    NewsFeaturedComponent,
    DefaultImageDirective],
  providers: [],
})
export class NewsModule { }
