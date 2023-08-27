import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel, RegisterModel, UserModel } from '../models/api.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AccountService {

  // application base user
  private _applicationBaseUrl: string = "https://localhost:44378";

  constructor(private httpClient: HttpClient) { }

  // login method
  login(loginModel: LoginModel): Observable<UserModel> {

    let loginUserInfo: Observable<UserModel> = 
      this.httpClient.post<UserModel>(this._applicationBaseUrl + "/api/Account/Login", loginModel);
    
    return loginUserInfo;
  }

  // registration method
  registration(registrationModel: RegisterModel): Observable<UserModel> {
    let registrationUserInfo: Observable<UserModel> = 
      this.httpClient.post<UserModel>(this._applicationBaseUrl + "/api/Account/Registration", registrationModel);
    
    return registrationUserInfo;
  }
}