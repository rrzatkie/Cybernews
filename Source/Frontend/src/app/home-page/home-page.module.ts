import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './home-page.component';
import { NewsSliderComponent } from "./news-slider/news-slider.component";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports: [
    CommonModule,
    NgbModule
  ],
  declarations: [HomePageComponent, NewsSliderComponent]
})
export class HomePageModule { }
