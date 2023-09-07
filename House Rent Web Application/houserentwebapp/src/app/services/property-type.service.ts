import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyTypeGridModel, PropertyTypeModel, PropertyTypeViewModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';

@Injectable({
  providedIn: 'root'
})

export class PropertyTypeService {

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  // Get all property type
  getAll(): Observable<PropertyTypeGridModel[]> {
    let getAllPropertyTypes: Observable<PropertyTypeGridModel[]> = 
      this.httpClient.get<PropertyTypeGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/PropertyType/GetAll");

    return getAllPropertyTypes;
  }

  // Get property type by id
  get(id: number): Observable<PropertyTypeViewModel> {
    let getPropertyType: Observable<PropertyTypeViewModel> = 
      this.httpClient.get<PropertyTypeViewModel>(ApplicationBaseUrl.baseUrl + `/api/PropertyType/Get/${id}`);
    
    return getPropertyType;
  }

  // Upsert property type
  upsert(model: PropertyTypeModel): Observable<number> {
    let upsertPropertyType: Observable<number> = 
      this.httpClient.post<number>(ApplicationBaseUrl.baseUrl + "/api/PropertyType/Upsert", model, this.httpOptions);

    return upsertPropertyType;
  }

  // Delete property type by id
  delete(id: number): Observable<number> {
    let deletedPropertyType: Observable<number> = 
      this.httpClient.delete<number>(ApplicationBaseUrl.baseUrl  + `/api/PropertyType/Delete/${id}`);

    return deletedPropertyType;
  }
}