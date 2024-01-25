import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CityGridModel, UserModel } from '../models/api.model';
import { ApplicationBaseUrl } from '../utility/application-base-url';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
  
export class CityService {
    
    // Login user info property
    private _loginUserInfo: UserModel = new UserModel();
    private _headers: HttpHeaders = new HttpHeaders();

    constructor(private httpClient: HttpClient, private toastrService: ToastrService, private router: Router) { 
        
    }  

    // Get all city
    getAll(): Observable<CityGridModel[]> {

        // Set http headers
        this.setHttpHeaders();

        let getAllCities: Observable<CityGridModel[]> = 
            this.httpClient.get<CityGridModel[]>(ApplicationBaseUrl.baseUrl + "/api/City/GetAll", { headers: this._headers });

        return getAllCities;
    }

    private isGetLoginUser(): boolean {
        // Get current user token
        this._loginUserInfo = JSON.parse(localStorage.getItem("_loginUserInfo")!);
    
        if(this._loginUserInfo == null) {
          return false;
        }
        else {
          return true;
        }
    }
    
    private setHttpHeaders(): void {
        let isLoginUser: boolean = this.isGetLoginUser();
    
        if(isLoginUser) {
            this._headers = new HttpHeaders({ 
                'Content-Type': 'application/json',
                'Authorization' : `Bearer ${this._loginUserInfo.token}`
            }) 
        }
        else {
            this.toastrService.warning("You are not a login user! Please, login first.", "Warning");
            this.router.navigate(["/user/login"]);
            return;
        } 
    }
}