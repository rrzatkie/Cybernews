import { Component, OnInit, Input } from '@angular/core';
import { ArticleCard } from 'src/app/shared/article';

@Component({
  selector: 'news-card',
  templateUrl: './news-card.component.html',
  styleUrls: ['./news-card.component.css']
})

export class NewsCardComponent implements OnInit {
  @Input() article: ArticleCard;

  constructor() { }

  ngOnInit() {
  }
}