import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

import { NgbModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';

import { NewsCardComponent } from './news-card/news-card.component';
import { NewsCardsViewComponent } from './news-cards-view/news-cards-view.component';
import { NewsFeaturedComponent } from './news-featured/news-featured.component';
import { NewsCategoriesComponent } from './news-categories/news-categories.component';
import { NewsKeywordsComponent } from './news-keywords/news-keywords.component';
import { NewsArchiveComponent } from './news-archive/news-archive.component';
import { NewsSearchComponent } from './news-search/news-search.component';
import { RouterModule } from '@angular/router';
import { NewsDetailsComponent } from './news-details/news-details.component';
import { MatchHeightDirective } from './news-cards-view/matchHeight.directive';
import { FormsModule } from '@angular/forms';
import { SearchService } from '../core/services/search/search.service';


@NgModule({
  imports: [
    BrowserModule,
    NgbModule,
    CommonModule,
    FormsModule,
    RouterModule,
    NgbDropdownModule
  ],
  exports: [
    NewsCardComponent,
    NewsCardsViewComponent,
    RouterModule,
    NewsFeaturedComponent,
    NewsCategoriesComponent,
    NewsKeywordsComponent,
    NewsDetailsComponent,
    NewsArchiveComponent,
    NewsSearchComponent
  ],
  declarations: [
    NewsCardComponent,
    NewsCardsViewComponent,
    NewsFeaturedComponent,
    NewsCategoriesComponent,
    NewsKeywordsComponent,
    MatchHeightDirective,
    NewsDetailsComponent,
    NewsArchiveComponent,
    NewsSearchComponent
  ],
  providers: [
    SearchService
  ],
})
export class NewsModule { }
