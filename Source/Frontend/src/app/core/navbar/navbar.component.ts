import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Category } from 'src/app/shared/article';
import { ArticleRepositoryService } from '../services/repository/article-repository.service';
import { ArticleViewService } from '../services/view/article-view.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  @Input() categories: Category[];
  @Output() burgerMenuEvent: EventEmitter<any> = new EventEmitter();

  currentActive: HTMLElement;
  public styleClassActive = "colorlib-active";

  constructor(
    private readonly articleViewService: ArticleViewService
  ) { }

  ngOnInit() {
    this.articleViewService.getMenuItemActiveState().subscribe( x => {
      if (this.currentActive) {
        this.currentActive.className = '';
      }
      this.currentActive = document.getElementById(x);
      this.currentActive.className = this.styleClassActive;
    });
  }

  toogle(){
    this.burgerMenuEvent.emit(null);
  }

}
