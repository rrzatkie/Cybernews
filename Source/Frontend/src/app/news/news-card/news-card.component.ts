import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ArticleCard, Keyword } from 'src/app/shared/article';
import { ArticleViewService } from 'src/app/core/services/view/article-view.service';
import { ArticleCardType } from "../../shared/article";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'news-card',
  templateUrl: './news-card.component.html',
  styleUrls: ['./news-card.component.css']
})

export class NewsCardComponent implements OnInit {
  @Input() article: ArticleCard;
  @Output() imgLoadingStatus = new EventEmitter();

  public keywords : Keyword[];
  public ArticleCardType = ArticleCardType;

  constructor(
    private readonly articleViewService: ArticleViewService,
    public route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.keywords = this.article.articleKeywords.sort((a, b) => b.keywordValue - a.keywordValue);
  }

  imgLoaded(){
    this.imgLoadingStatus.emit(true);
  }
}
