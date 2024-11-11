import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { LoginInput, LoginResult, RegistrierUserInput } from 'app/core/auth/auth.model';
import { AuthApiService, AuthCommonService } from 'app/core/auth/services';
import { MaterialModule } from 'app/shared/modules/Material.module';
import { FeatureApiService } from '../services/api.service';
import { catchError, EMPTY, map, take } from 'rxjs';
import { UpdateFirma } from '../feature.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
  standalone: true,
  imports: [MaterialModule, ReactiveFormsModule],
})
export class DashboardComponent implements OnInit {
  userInformation: LoginResult;
  form: any;
  formNewUser: any;
  firmaInfo : UpdateFirma | undefined;
  constructor(
    private authCommonService: AuthCommonService,
    private featureApiService: FeatureApiService,
    private authApiService: AuthApiService,
    private activatedRoute: ActivatedRoute
  ) {
    this.userInformation =
      this.authCommonService.getLoginResult() as LoginResult;
  }
  
  ngOnInit(): void {
    this.activatedRoute.data.subscribe((response: any) => {
      this.firmaInfo = response.firmaInfo as UpdateFirma;
    });

    this.form = new FormGroup({
      name: new FormControl({
        value: this.firmaInfo?.name,
        disabled: !this.userInformation.isHauptUser,
      }),
      address: new FormControl({
        value: this.firmaInfo?.address,
        disabled: !this.userInformation.isHauptUser,
      }),
      phoneNumber: new FormControl({
        value: this.firmaInfo?.phoneNumber,
        disabled: !this.userInformation.isHauptUser,
      }),
    });

    this.formNewUser = new FormGroup({
      newUserName: new FormControl(''),
      newUserEmail: new FormControl('')
    });
  }

  submit() {
    if (this.formNewUser.valid) {
      const updateFirmaInfo = new UpdateFirma();
      updateFirmaInfo.name = this.form.value.name as string;
      updateFirmaInfo.address = this.form.value.address as string;
      updateFirmaInfo.phoneNumber = this.form.value.phoneNumber as string;

      this.featureApiService
        .updateFirmaInfo(updateFirmaInfo)
        .pipe(
          take(1),
          map((res) => {
            alert('updated success');
          }),
          catchError((error) => {
            alert(error.error);
            return EMPTY;
          })
        )
        .subscribe();
    }
  }

  
  submitNewUser() {
    if (this.formNewUser.valid) {
      debugger
      const registrierUserInput = new RegistrierUserInput();
      registrierUserInput.name = this.formNewUser.value.newUserName as string;
      registrierUserInput.email = this.formNewUser.value.newUserEmail as string;

      this.authApiService
        .registrierUser(registrierUserInput)
        .pipe(
          take(1),
          map((res) => {
            alert('Set New User successfully');
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
