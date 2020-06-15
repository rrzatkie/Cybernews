import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopbarComponent } from './topbar.component';
import { NewsSearchComponent } from 'src/app/news/news-search/news-search.component';
import { NewsModule } from 'src/app/news/news.module';

@NgModule({
  imports: [
    CommonModule,
    NewsModule
  ],
  exports: [
    TopbarComponent
  ],
  declarations: [TopbarComponent]
})
export class TopbarModule { }
