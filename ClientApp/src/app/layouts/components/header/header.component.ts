import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';


import { Router, RouterLink } from '@angular/router';
import { LoginResult } from '../../../core/auth/auth.model';
import { AuthApiService, AuthCommonService } from '../../../core/auth/services';
@Component({
  selector: 'app-header',
  templateUrl: 'header.component.html',
  styleUrls: ['./header.component.scss'],
  standalone: true,
  imports: [RouterLink]
})

export class HeaderComponent implements OnInit {
  user: LoginResult | null = null;

  constructor(private authService: AuthCommonService, private authApiService: AuthApiService, private router: Router) { }

  ngOnInit() {
    this.user = this.authService.getLoginResult();
  }
}

