import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoginResult } from '../auth.model';
import { AuthCommonService } from '../services';
import { UrlUtility } from '../../../shared/utils';

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {
  const localStorageService = inject(AuthCommonService);
  const loginResult = localStorageService.getLoginResult() as LoginResult;
  const nonAuthUrls = [`${UrlUtility.serverUrl}/user-confirmation`, `${UrlUtility.serverUrl}/login`];

  if (!nonAuthUrls.includes(req.url)) {
    let reqWithToken = req.clone({
      setHeaders: {
        Authorization: `Bearer ${loginResult.token}`
      }
    });
    return next(reqWithToken);
  }
  return next(req);
};
