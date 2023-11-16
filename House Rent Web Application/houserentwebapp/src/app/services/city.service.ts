import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CityGridModel, UserModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';

@Injectable({
    providedIn: 'root'
  })
  
export class CityService {
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

    // Get all city
    getAll(): Observable<CityGridModel[]> {
        let getAllCities: Observable<CityGridModel[]> = 
            this.httpClient.get<CityGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/City/GetAll", this.httpOptions);

        return getAllCities;
    }
}