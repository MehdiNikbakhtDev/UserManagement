import {
  Component,
  Input,
  Output,
  EventEmitter,
  OnInit,
  inject,
} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { Router, RouterLink } from '@angular/router';
import { LoginResult } from '../../../core/auth/auth.model';
import { AuthCommonService } from '../../../core/auth/services';
import { MaterialModule } from 'app/shared/modules/Material.module';
@Component({
  selector: 'app-header',
  templateUrl: 'header.component.html',
  styleUrls: ['./header.component.scss'],
  standalone: true,
  imports: [RouterLink, MaterialModule],
})
export class HeaderComponent {
  readonly dialog = inject(MatDialog);
  loginResult: LoginResult | null;
  constructor(
    private localStorageService: AuthCommonService,
    private router: Router
  ) {
    this.loginResult = this.localStorageService.getLoginResult() as LoginResult;
  }
  onLogOut() {
    this.localStorageService.removeLoginResult();
    this.router.navigate(['/login']);
  }
}
