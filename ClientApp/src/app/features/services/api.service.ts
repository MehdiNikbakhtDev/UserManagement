import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UpdateFirma } from '../feature.model';
import { UrlUtility } from 'app/shared/utils';

@Injectable({
  providedIn: 'root',
})
export class FeatureApiService {
  constructor(private http: HttpClient) {}

  updateFirmaInfo(updateFirmaInput: UpdateFirma) {
    return this.http.post<UpdateFirma>(
      `${UrlUtility.serverUrl}/InsertOrUpdateFirmaInfo`,
      updateFirmaInput
    );
  }

  getFirmaInfo() {
    return this.http.get<UpdateFirma>(`${UrlUtility.serverUrl}/GetFirmaInfo`);
  }

}
