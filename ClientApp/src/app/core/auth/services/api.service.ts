import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlUtility } from '../../../shared/utils';
import { LoginInput, LoginResult } from '../auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {
  constructor(private http: HttpClient) {}

  login(loginInput: LoginInput) {
    return this.http.post<LoginResult>(
      `${UrlUtility.serverUrl}/LoginUser`,
      loginInput
    );
  }
  logout() {
    return this.http.post<unknown>(`${UrlUtility.serverUrl}/logout`, null);
  }
}
