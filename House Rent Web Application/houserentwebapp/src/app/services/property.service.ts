import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyGridModel, PropertyModel, PropertyViewModel, UserModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class PropertyService {

  // Login user info property
  private _loginUserInfo: UserModel = new UserModel();
  private _headers: HttpHeaders = new HttpHeaders();

  constructor(private httpClient: HttpClient, private toastrService: ToastrService, private router: Router) { }  

  // Get all property
  getAll(): Observable<PropertyGridModel[]> {

    // Set http headers
    this.setHttpHeaders();

    let getAllProperties: Observable<PropertyGridModel[]> = 
      this.httpClient.get<PropertyGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/Property/GetAll", { headers: this._headers });

    return getAllProperties;
  }

  // Get property by id
  get(id: number): Observable<PropertyViewModel> {

    // Set http headers
    this.setHttpHeaders();

    let getProperty: Observable<PropertyViewModel> = 
      this.httpClient.get<PropertyViewModel>(ApplicationBaseUrl.baseUrl + `/api/Property/Get/${id}`, { headers: this._headers });
    
    return getProperty;
  }

  // Upsert property
  upsert(model: PropertyModel): Observable<number> {

    // Set http headers
    this.setHttpHeaders();

    let upsertProperty: Observable<number> = 
      this.httpClient.post<number>(ApplicationBaseUrl.baseUrl + "/api/Property/Upsert", model, { headers: this._headers });

    return upsertProperty;
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