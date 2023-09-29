import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FurnishingTypeGridModel, FurnishingTypeModel, FurnishingTypeViewModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class FurnishingTypeService {
  
  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  // Get all furnishing type
  getAll(): Observable<FurnishingTypeGridModel[]> {
    let getAllFurnishingTypes: Observable<FurnishingTypeGridModel[]> = 
      this.httpClient.get<FurnishingTypeGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/FurnishingType/GetAll");

    return getAllFurnishingTypes;
  }

  // Get furnishing type by id
  get(id: number): Observable<FurnishingTypeViewModel> {
    let getFurnishingType: Observable<FurnishingTypeViewModel> = 
      this.httpClient.get<FurnishingTypeViewModel>(ApplicationBaseUrl.baseUrl + `/api/FurnishingType/Get/${id}`);
    
    return getFurnishingType;
  }

  // Upsert furnishing type
  upsert(model: FurnishingTypeModel): Observable<number> {
    let upsertFurnishingType: Observable<number> = 
      this.httpClient.post<number>(ApplicationBaseUrl.baseUrl + "/api/FurnishingType/Upsert", model, this.httpOptions);

    return upsertFurnishingType;
  }

  // Delete furnishing type by id
  delete(id: number): Observable<number> {
    let deletedFurnishingType: Observable<number> = 
      this.httpClient.delete<number>(ApplicationBaseUrl.baseUrl  + `/api/FurnishingType/Delete/${id}`);

    return deletedFurnishingType;
  }
}