import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { KeyValuePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavbarModule } from './core/navbar/navbar.module';
import { NewsModule } from "./news/news.module";
import { AppRoutingModule } from './app-routing.module';
import { ConfigurationService } from './core/services/configuration//configuration.service';
import { CategoriesResolver } from './core/services/resolvers/categories.resolver'
import { ArticleViewService } from './core/services/view/article-view.service';
import { ArticleRepositoryService } from './core/services/repository/article-repository.service';

export function configServiceFactory(config: ConfigurationService) {
   return () => config.load();
 }

@NgModule({
   declarations: [
      AppComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      NgbModule,
      FontAwesomeModule,
      HttpClientModule,
      BrowserAnimationsModule,
      NavbarModule,
      NewsModule
   ],
   providers: [
      ConfigurationService,
      {
         provide: APP_INITIALIZER,
         useFactory: configServiceFactory,
         deps: [ConfigurationService],
         multi: true
      },
      KeyValuePipe,
      CategoriesResolver,
      ArticleRepositoryService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
