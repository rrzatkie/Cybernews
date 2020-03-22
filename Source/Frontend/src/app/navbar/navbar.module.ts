import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar.component';
import { RouterModule } from '@angular/router';
import { ArticleRepositoryService } from '../services/repository/article-repository.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [NavbarComponent],
  exports : [NavbarComponent],
  providers: [ArticleRepositoryService]
})
export class NavbarModule { }
