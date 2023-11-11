import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
}) 

export class HttpErrorInterceptorService implements HttpInterceptor {

  constructor(private toastrService: ToastrService, private spinner: NgxSpinnerService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.spinner.show();
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {

        console.log("Show Error Details :- ", error);

        this.spinner.hide();
        if(error.error.errors != null || error.error.errors != undefined) {
          this.toastrService.error(JSON.stringify(error.error.errors));
        }
        else {
          if(error.error.errorMessage != undefined) {
            this.toastrService.error(error.error.errorMessage);
          }
        }

        return throwError("");
      })
    )
  }
}