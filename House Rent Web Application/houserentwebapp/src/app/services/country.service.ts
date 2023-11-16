import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CountryGridModel, UserModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';

@Injectable({
  providedIn: 'root'
})

export class CountryService {

  // Login user info property
  private _loginUserInfo: UserModel = new UserModel();

  constructor(private httpClient: HttpClient) { 
    // Get current user token
    this._loginUserInfo = JSON.parse(localStorage.getItem("_loginUserInfo")!);
  }  

  httpOptions = {
    headers: new HttpHeaders({ 
      'Content-Type': 'application/json',
      ...(this._loginUserInfo.token != null ? { 'Authorization': `Bearer ${this._loginUserInfo.token}` } : { })
    })
  };  

  // Get all country
  getAll(): Observable<CountryGridModel[]> {
    let getAllCountries: Observable<CountryGridModel[]> = 
      this.httpClient.get<CountryGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/Country/GetAll", this.httpOptions);

    return getAllCountries;
  }
}