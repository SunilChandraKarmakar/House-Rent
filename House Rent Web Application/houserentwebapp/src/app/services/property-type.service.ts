import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyTypeGridModel, PropertyTypeModel, PropertyTypeViewModel, UserModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class PropertyTypeService {

  // Login user info property
  private _loginUserInfo: UserModel = new UserModel();
  private _headers: HttpHeaders = new HttpHeaders();

  constructor(private httpClient: HttpClient, private toastrService: ToastrService, private router: Router) { } 

  // Get all property type
  getAll(): Observable<PropertyTypeGridModel[]> {

    // Set http headers
    this.setHttpHeaders();

    let getAllPropertyTypes: Observable<PropertyTypeGridModel[]> = 
      this.httpClient.get<PropertyTypeGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/PropertyType/GetAll", { headers: this._headers });

    return getAllPropertyTypes;
  }

  // Get property type by id
  get(id: number): Observable<PropertyTypeViewModel> {

    // Set http headers
    this.setHttpHeaders();

    let getPropertyType: Observable<PropertyTypeViewModel> = 
      this.httpClient.get<PropertyTypeViewModel>(ApplicationBaseUrl.baseUrl + `/api/PropertyType/Get/${id}`, { headers: this._headers });
    
    return getPropertyType;
  }

  // Upsert property type
  upsert(model: PropertyTypeModel): Observable<number> {

    // Set http headers
    this.setHttpHeaders();

    let upsertPropertyType: Observable<number> = 
      this.httpClient.post<number>(ApplicationBaseUrl.baseUrl + "/api/PropertyType/Upsert", model, { headers: this._headers });

    return upsertPropertyType;
  }

  // Delete property type by id
  delete(id: number): Observable<number> {

    // Set http headers
    this.setHttpHeaders();

    let deletedPropertyType: Observable<number> = 
      this.httpClient.delete<number>(ApplicationBaseUrl.baseUrl  + `/api/PropertyType/Delete/${id}`, { headers: this._headers });

    return deletedPropertyType;
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