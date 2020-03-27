import { Component, OnInit, Input } from '@angular/core';
import { ArticleCard } from 'src/app/shared/article';
import { ArticleViewService } from 'src/app/core/services/view/article-view.service';

@Component({
  selector: 'news-card',
  templateUrl: './news-card.component.html',
  styleUrls: ['./news-card.component.css']
})

export class NewsCardComponent implements OnInit {
  @Input() article: ArticleCard;

  constructor(
    private readonly articleViewService: ArticleViewService
  ) { }

  ngOnInit() {
  }

  seeDetails(){
    this.articleViewService.setArticleDetailsVisibleState(true);
  }
}
