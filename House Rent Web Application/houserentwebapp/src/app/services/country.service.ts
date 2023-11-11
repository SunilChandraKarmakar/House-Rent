import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CountryGridModel, UserModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';

@Injectable({
  providedIn: 'root'
})

export class CountryService {

  constructor(private httpClient: HttpClient) { }

  // Get current user token
  private _loginUSerInfo: UserModel = JSON.parse(localStorage.getItem("_loginUserInfo")!);
    
  httpOptions = {
    headers: new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${ this._loginUSerInfo.token }`
    })
  };

  // Get all country
  getAll(): Observable<CountryGridModel[]> {
    let getAllCountries: Observable<CountryGridModel[]> = 
      this.httpClient.get<CountryGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/Country/GetAll", this.httpOptions);

    return getAllCountries;
  }
}