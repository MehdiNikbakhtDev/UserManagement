import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';


@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.component.html',
  styleUrl: './page-not-found.component.scss',
  standalone:true,
  imports:[RouterLink]
})
export class PageNotFoundComponent {
  navigateToHome(){
    console.log("test")
  }
}
