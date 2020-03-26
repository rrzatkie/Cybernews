import { Component, OnInit, Input, Directive } from '@angular/core';
import { Slide } from 'src/app/shared/article';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'news-slider',
  templateUrl: './news-slider.component.html',
  styleUrls: ['./news-slider.component.css'],
  providers: [NgbCarouselConfig]
})

export class NewsSliderComponent implements OnInit {
  @Input() slides: Slide[];

  constructor(
    private readonly config: NgbCarouselConfig
  ) {
    config.showNavigationArrows = true;
    config.showNavigationIndicators = true;
  }

  ngOnInit() { }
}
