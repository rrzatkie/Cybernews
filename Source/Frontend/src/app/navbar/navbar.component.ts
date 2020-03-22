import { Component, OnInit } from '@angular/core';
import { Category, CybernewsApiResponse } from '../shared/article';
import { ArticleRepositoryService } from '../services/repository/article-repository.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  categories: Category[] = [];

  constructor(
    private readonly articleRepositoryService: ArticleRepositoryService
  ) { }

  ngOnInit() {
    this.articleRepositoryService.getCategories().subscribe((response: CybernewsApiResponse) => {
      this.categories = response.data as Category[];
    });
  }
}
