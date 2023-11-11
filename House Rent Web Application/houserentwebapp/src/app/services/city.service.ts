import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CityGridModel, UserModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';

@Injectable({
    providedIn: 'root'
  })
  
export class CityService {
    constructor(private httpClient: HttpClient) { }

    // Get current user token
    private _loginUSerInfo: UserModel = JSON.parse(localStorage.getItem("_loginUserInfo")!);
    
    httpOptions = {
        headers: new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${ this._loginUSerInfo.token }`
        })
    };

    // Get all city
    getAll(): Observable<CityGridModel[]> {
        let getAllCities: Observable<CityGridModel[]> = 
            this.httpClient.get<CityGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/City/GetAll", this.httpOptions);

        return getAllCities;
    }
}