import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FurnishingTypeGridModel, FurnishingTypeModel, FurnishingTypeViewModel, UserModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class FurnishingTypeService {
  
  constructor(private httpClient: HttpClient) { }

  // Get current user token
  private _loginUSerInfo: UserModel = JSON.parse(localStorage.getItem("_loginUserInfo")!);

  httpOptions = {
    headers: new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${ this._loginUSerInfo.token }`
    })
  };
  

  // Get all furnishing type
  getAll(): Observable<FurnishingTypeGridModel[]> {
    let getAllFurnishingTypes: Observable<FurnishingTypeGridModel[]> = 
      this.httpClient.get<FurnishingTypeGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/FurnishingType/GetAll", 
      this.httpOptions);

    return getAllFurnishingTypes;
  }

  // Get furnishing type by id
  get(id: number): Observable<FurnishingTypeViewModel> {
    let getFurnishingType: Observable<FurnishingTypeViewModel> = 
      this.httpClient.get<FurnishingTypeViewModel>(ApplicationBaseUrl.baseUrl + `/api/FurnishingType/Get/${id}`, 
      this.httpOptions);
    
    return getFurnishingType;
  }

  // Upsert furnishing type
  upsert(model: FurnishingTypeModel): Observable<number> {
    let upsertFurnishingType: Observable<number> = 
      this.httpClient.post<number>(ApplicationBaseUrl.baseUrl + "/api/FurnishingType/Upsert", model, this.httpOptions);

    return upsertFurnishingType;
  }

  // Delete furnishing type by id
  delete(id: number): Observable<number> {
    let deletedFurnishingType: Observable<number> = 
      this.httpClient.delete<number>(ApplicationBaseUrl.baseUrl  + `/api/FurnishingType/Delete/${id}`, this.httpOptions);

    return deletedFurnishingType;
  }
}