import { Component, OnInit } from '@angular/core';
import { ArticleRepositoryService } from 'src/app/core/services/repository/article-repository.service';
import { ArticleViewService } from 'src/app/core/services/view/article-view.service';
import { Category, Slide, Keyword } from 'src/app/shared/article';
import { ActivatedRoute } from '@angular/router';
import { KeyValue } from '@angular/common';

@Component({
  selector: 'news-keywords',
  templateUrl: './news-keywords.component.html',
  styleUrls: ['./news-keywords.component.scss']
})

export class NewsKeywordsComponent implements OnInit {
  public slides: { [category: string]: Slide[]} = {};

  public keywords: Keyword[];

  private categoriesSubscription;

  constructor(
    private readonly artcileRepositoryService: ArticleRepositoryService,
    private readonly articleViewService: ArticleViewService,
    private readonly route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.articleViewService.setMenuItemActiveState('keywords');
    if(history.state.keywords) {
      this.keywords = history.state.keywords;
    } else {
      this.artcileRepositoryService.getKeywords().subscribe((response) => {
        this.keywords = response.data as Keyword[];
      });
    }
  }

  getCategoryName(keywordId: string){
    const result = this.keywords.find(x => x.keywordId === parseInt(keywordId));
    return result.keywordNameToDisplay;
  }

}
