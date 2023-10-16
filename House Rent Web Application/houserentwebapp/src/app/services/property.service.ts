import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyGridModel, PropertyModel, PropertyViewModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';

@Injectable({
  providedIn: 'root'
})

export class PropertyService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private httpClient: HttpClient) { }

  // Get all property
  getAll(): Observable<PropertyGridModel[]> {
    let getAllProperties: Observable<PropertyGridModel[]> = 
      this.httpClient.get<PropertyGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/Property/GetAll");

    return getAllProperties;
  }

  // Get property by id
  get(id: number): Observable<PropertyViewModel> {
    let getProperty: Observable<PropertyViewModel> = 
      this.httpClient.get<PropertyViewModel>(ApplicationBaseUrl.baseUrl + `/api/Property/Get/${id}`);
    
    return getProperty;
  }

  // Upsert property
  upsert(model: PropertyModel): Observable<number> {
    let upsertProperty: Observable<number> = 
      this.httpClient.post<number>(ApplicationBaseUrl.baseUrl + "/api/Property/Upsert", model, this.httpOptions);

    return upsertProperty;
  }
}