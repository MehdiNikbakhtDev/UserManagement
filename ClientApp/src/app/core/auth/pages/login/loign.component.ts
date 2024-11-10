import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { EMPTY, catchError, map, take } from 'rxjs';
import { MaterialModule } from '../../../../shared/modules/Material.module';
import { LoginInput } from '../../auth.model';
import { AuthApiService, AuthCommonService } from '../../services';

@Component({
  selector: 'app-loign',
  standalone: true,
  imports: [MaterialModule, ReactiveFormsModule, NgIf,RouterLink],
  templateUrl: './loign.component.html',
  styleUrl: './loign.component.scss',
})
export class LoginComponent {
  constructor(private authApiService: AuthApiService, private localStorageService: AuthCommonService,   private router: Router,
  ) {}

  form: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  submit() {
    if (this.form.valid) {
      const loginInput = new LoginInput();
      loginInput.email = this.form.value.email as string;
      loginInput.password = this.form.value.password as string;

      this.authApiService
        .login(loginInput)
        .pipe(
          take(1),
          map((res: any) => {
            this.localStorageService.setLoginResult(res);
            this.router.navigate(["/"]);
          }),
          catchError((error) => {
            alert(error.error)
            return EMPTY;
          })
        )
        .subscribe();
    }
  }

}
