import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CountryGridModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';

@Injectable({
  providedIn: 'root'
})

export class CountryService {

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  // Get all country
  getAll(): Observable<CountryGridModel[]> {
    let getAllCountries: Observable<CountryGridModel[]> = 
      this.httpClient.get<CountryGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/Country/GetAll");

    return getAllCountries;
  }
}