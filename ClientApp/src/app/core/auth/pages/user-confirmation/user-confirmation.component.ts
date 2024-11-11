import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MaterialModule } from 'app/shared/modules/Material.module';
import { ConfirmUserInput } from '../../auth.model';
import { AuthApiService } from '../../services';
import { catchError, EMPTY, map, take } from 'rxjs';

@Component({
  selector: 'app-user-confirmation',
  standalone: true,
  imports: [MaterialModule, ReactiveFormsModule, RouterLink],
  templateUrl: './user-confirmation.component.html',
  styleUrl: './user-confirmation.component.scss',
})
export class UserConfirmationComponent implements OnInit {
  guid: string | undefined;
  form: any;

  constructor(
    private route: ActivatedRoute,
    private authApiService: AuthApiService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.guid = String(this.route.snapshot.paramMap.get('guid'));
    this.form = new FormGroup({
      password: new FormControl(''),
      confirmpassword: new FormControl(''),
    });
  }

  submit() {
    const isPasswordConfirmed =
      this.form.value.password == this.form.value.confirmpassword;
    if (this.form.valid && isPasswordConfirmed) {
      const confirmUserInput = new ConfirmUserInput();
      confirmUserInput.runGuid = this.guid as string;
      confirmUserInput.password = this.form.value.password as string;

      this.authApiService
        .confirmUser(confirmUserInput)
        .pipe(
          take(1),
          map((res) => {
            alert('set password successfully');
            this.router.navigate(['/login']);
          }),
          catchError((error) => {
            alert(error.error);
            return EMPTY;
          })
        )
        .subscribe();
    }
  }
}
