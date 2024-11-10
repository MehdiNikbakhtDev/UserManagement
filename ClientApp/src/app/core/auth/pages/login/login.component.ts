import { Component, NgModule, OnInit, ViewChild } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { LoginInput } from '../../auth.model';
import { AuthApiService, AuthCommonService } from '../../services';

import { catchError, EMPTY, map, take } from 'rxjs';

@Component({
  selector: 'app-loign',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  standalone:true,
  imports:[RouterLink]
})
export class LoginComponent {
  constructor(
    private authApiService: AuthApiService,
    private authCommonService: AuthCommonService,
    private router: Router
  ) {}


  onLoginFormSubmit(e: any) {
    e.preventDefault();
    // if (this.form.instance.validate().isValid) {
    //   const loginInput = new LoginInput();
    //   loginInput.username = this.form.instance
    //     .getEditor('username')
    //     ?.option('value') as string;
    //   loginInput.password = this.form.instance
    //     .getEditor('password')
    //     ?.option('value') as string;

    //   this.authApiService
    //     .login(loginInput)
    //     .pipe(
    //       take(1),
    //       map((res) => {
    //         this.authCommonService.setLoginResult(res);
    //         this.router.navigate(['/']);
    //       }),
    //       catchError((error) => {
    //         this.messageService.toastErrorMessage(error.error, 'error');
    //         return EMPTY;
    //       })
    //     )
    //     .subscribe();
    // }
  }

}

