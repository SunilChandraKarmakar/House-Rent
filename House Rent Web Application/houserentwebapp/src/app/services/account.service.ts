import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel, RegisterModel, UserModel } from '../models/api.model';
import { Observable } from 'rxjs';
import { ApplicationBaseUrl } from '../utility/application-base-url';

@Injectable({
  providedIn: 'root'
})

export class AccountService {

  constructor(private httpClient: HttpClient) { }

  // login method
  login(loginModel: LoginModel): Observable<UserModel> {

    let loginUserInfo: Observable<UserModel> = 
      this.httpClient.post<UserModel>(ApplicationBaseUrl.baseUrl + "/api/Account/Login", loginModel);
    
    return loginUserInfo;
  }

  // registration method
  registration(registrationModel: RegisterModel): Observable<UserModel> {
    let registrationUserInfo: Observable<UserModel> = 
      this.httpClient.post<UserModel>(ApplicationBaseUrl.baseUrl + "/api/Account/Registration", registrationModel);
    
    return registrationUserInfo;
  }
}