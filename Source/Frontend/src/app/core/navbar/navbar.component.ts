import { Component, OnInit, Input } from '@angular/core';
import { Category } from 'src/app/shared/article';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  @Input() categories: Category[];

  constructor() { }

  ngOnInit() {
  }

}
