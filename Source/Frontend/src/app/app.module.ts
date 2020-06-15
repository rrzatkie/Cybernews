import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { KeyValuePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavbarModule } from './core/navbar/navbar.module';
import { SidebarModule } from './core/sidebar/sidebar.module';
import { NewsModule } from './news/news.module';
import { AppRoutingModule } from './app-routing.module';
import { ConfigurationService } from './core/services/configuration//configuration.service';
import { ArticleRepositoryService } from './core/services/repository/article-repository.service';
import { TopbarModule } from './core/topbar/topbar.module';

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
      SidebarModule,
      NewsModule,
      TopbarModule
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
      ArticleRepositoryService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
