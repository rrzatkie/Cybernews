import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavbarModule } from './navbar/navbar.module';
import { HomePageModule } from './home-page/home-page.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ConfigurationService } from './core/services/configuration/configuration/configuration.service';

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
      NavbarModule,
      HomePageModule,
      FontAwesomeModule
   ],
   providers: [
      ConfigurationService,
      {
         provide: APP_INITIALIZER,
         useFactory: configServiceFactory,
         deps: [ConfigurationService],
         multi: true
      },
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
