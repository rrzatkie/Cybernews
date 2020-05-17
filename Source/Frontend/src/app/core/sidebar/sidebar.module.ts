import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { SidebarComponent } from './sidebar.component';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  imports: [
    BrowserModule,
    CommonModule,
    RouterModule,
  ],
  exports: [
    RouterModule,
    SidebarComponent
  ],
  declarations: [SidebarComponent]
})
export class SidebarModule { }
