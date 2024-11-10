import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Router, NavigationEnd, RouterModule } from '@angular/router';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
  standalone:true,
  imports:[RouterModule , HeaderComponent]
})
export class LayoutComponent implements OnInit {

  constructor( private router: Router) {}
  ngOnInit() {
   
  }


}
