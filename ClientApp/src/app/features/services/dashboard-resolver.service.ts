import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
 import { FeatureApiService } from './api.service';
 
@Injectable({
  providedIn: 'root'
})
export class DashboardResolverService implements Resolve<any> {
  constructor(private featureApiService: FeatureApiService) {}
  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    console.log('Called Get Product in resolver...', route);
    return this.featureApiService.getFirmaInfo().pipe(
      map(res => res)
    );
  }
}