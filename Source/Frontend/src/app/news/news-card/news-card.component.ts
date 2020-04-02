import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ArticleCard } from 'src/app/shared/article';
import { ArticleViewService } from 'src/app/core/services/view/article-view.service';

@Component({
  selector: 'news-card',
  templateUrl: './news-card.component.html',
  styleUrls: ['./news-card.component.css']
})

export class NewsCardComponent implements OnInit {
  @Input() article: ArticleCard;
  @Output() imgLoadingStatus = new EventEmitter();

  constructor(
    private readonly articleViewService: ArticleViewService
  ) { }

  ngOnInit() {
  }

  imgLoaded(){
    this.imgLoadingStatus.emit(true);
  }

  seeDetails(){
    this.articleViewService.setArticleDetailsVisibleState(true);
  }
}
