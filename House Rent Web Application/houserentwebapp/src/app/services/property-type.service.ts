import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyTypeGridModel, PropertyTypeViewModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';

@Injectable({
  providedIn: 'root'
})

export class PropertyTypeService {

  constructor(private httpClient: HttpClient) { }


  // Get all property type
  getAll(): Observable<PropertyTypeGridModel[]> {
    let getAllPropertyTypes: Observable<PropertyTypeGridModel[]> = 
      this.httpClient.get<PropertyTypeGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/Account/Login");

    return getAllPropertyTypes;
  }

  // Get PropertyType
  get(id: number): Observable<PropertyTypeViewModel> {

  }
}
