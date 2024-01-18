import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { PropertyTypeGridModel, UserModel } from 'src/app/models/api.model';
import { PropertyTypeService } from 'src/app/services/property-type.service';

@Component({
  selector: 'app-property-type-list',
  templateUrl: './property-type-list.component.html',
  styleUrls: ['./property-type-list.component.scss']
})

export class PropertyTypeListComponent implements OnInit {

  constructor(private propertyTypeService: PropertyTypeService, private spinner: NgxSpinnerService, 
  private toastrService: ToastrService, private router: Router) { }

  propertyTypes: PropertyTypeGridModel[] = [];

  // Login user model
  private _loginUserInfo: UserModel = new UserModel();

  ngOnInit() {
    // Check user login or not
    this._loginUserInfo = JSON.parse(localStorage.getItem("_loginUserInfo")!);

    console.log("Login USer Info = ", this._loginUserInfo);

    // if(this._loginUserInfo.token == null) {
    //   this.toastrService.warning("You can not login user! Please, login first.", "Warning");
    //   this.router.navigate(["/user/login"]);
    // }
    
    // this.spinner.show();
    // this.propertyTypeService.getAll().subscribe((result: PropertyTypeGridModel[]) => {
    //   this.propertyTypes = result;
    //   this.spinner.hide();
    // });
  }

  deletePropertyType(id: number): void {
    this.spinner.show();
    this.propertyTypeService.delete(id).subscribe(() => {
      this.spinner.hide();
      this.toastrService.success("Property Type Deleted.", "Successfull");
      this.ngOnInit();
    })
  }

  cancel(): void {
  }

  updatePropertyType(id: number): void {
    this.spinner.show();
    this.router.navigate([`/property-types/details/${id}`]);
  }

  // // Check user login or not 
  // private checkUserLoginOrNot(): void {
  //   this._loginUserInfo = JSON.parse(localStorage.getItem("_loginUserInfo")!);

  //   console.log("Login USer Info = ", this._loginUserInfo);

  //   if(this._loginUserInfo.token == null) {
  //     this.toastrService.warning("You can not login user! Please, login first.", "Warning");
  //     this.router.navigate(["/user/login"]);
  //   }
  // }
}