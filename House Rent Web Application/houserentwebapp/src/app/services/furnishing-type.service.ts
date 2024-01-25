import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FurnishingTypeGridModel, FurnishingTypeModel, FurnishingTypeViewModel, UserModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class FurnishingTypeService {

  // Login user info property
  private _loginUserInfo: UserModel = new UserModel();
  private _headers: HttpHeaders = new HttpHeaders();

  constructor(private httpClient: HttpClient, private toastrService: ToastrService, private router: Router) { }  

  // Get all furnishing type
  getAll(): Observable<FurnishingTypeGridModel[]> {

    // Set http headers
    this.setHttpHeaders();

    let getAllFurnishingTypes: Observable<FurnishingTypeGridModel[]> = 
      this.httpClient.get<FurnishingTypeGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/FurnishingType/GetAll", { headers: this._headers });

    return getAllFurnishingTypes;
  }

  // Get furnishing type by id
  get(id: number): Observable<FurnishingTypeViewModel> {

    // Set http headers
    this.setHttpHeaders();

    let getFurnishingType: Observable<FurnishingTypeViewModel> = 
      this.httpClient.get<FurnishingTypeViewModel>(ApplicationBaseUrl.baseUrl + `/api/FurnishingType/Get/${id}`, { headers: this._headers });
    
    return getFurnishingType;
  }

  // Upsert furnishing type
  upsert(model: FurnishingTypeModel): Observable<number> {

    // Set http headers
    this.setHttpHeaders();

    let upsertFurnishingType: Observable<number> = 
      this.httpClient.post<number>(ApplicationBaseUrl.baseUrl + "/api/FurnishingType/Upsert", model, { headers: this._headers });

    return upsertFurnishingType;
  }

  // Delete furnishing type by id
  delete(id: number): Observable<number> {

    // Set http headers
    this.setHttpHeaders();

    let deletedFurnishingType: Observable<number> = 
      this.httpClient.delete<number>(ApplicationBaseUrl.baseUrl  + `/api/FurnishingType/Delete/${id}`, { headers: this._headers });

    return deletedFurnishingType;
  }

  private isGetLoginUser(): boolean {
    // Get current user token
    this._loginUserInfo = JSON.parse(localStorage.getItem("_loginUserInfo")!);

    if(this._loginUserInfo == null) {
      return false;
    }
    else {
      return true;
    }
  }

  // Set http headers
  private setHttpHeaders(): void {
    let isLoginUser: boolean = this.isGetLoginUser();
    
    if(isLoginUser) {
      this._headers = new HttpHeaders({ 
        'Content-Type': 'application/json',
        'Authorization' : `Bearer ${this._loginUserInfo.token}`
      }) 
    }
    else {
      this.toastrService.warning("You are not a login user! Please, login first.", "Warning");
      this.router.navigate(["/user/login"]);
      return;
    } 
  }
}