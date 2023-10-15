import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CityGridModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';

@Injectable({
    providedIn: 'root'
  })
  
export class CityService {
    constructor(private httpClient: HttpClient) { }

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    // Get all city
    getAll(): Observable<CityGridModel[]> {
        let getAllCities: Observable<CityGridModel[]> = 
            this.httpClient.get<CityGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/City/GetAll");

        return getAllCities;
    }
}