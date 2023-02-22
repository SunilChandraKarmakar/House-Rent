import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Property } from '../models/property';

@Injectable({
  providedIn: 'root'
})

export class PropertyService {

  constructor(private _httpClient: HttpClient) { }

  getAll(): Observable<Property[]> {
    return this._httpClient.get<Property[]>("data/property.json");
  }
}
