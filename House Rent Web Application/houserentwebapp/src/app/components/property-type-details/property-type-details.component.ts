import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { PropertyTypeModel, PropertyTypeViewModel, UserModel } from 'src/app/models/api.model';
import { PropertyTypeService } from 'src/app/services/property-type.service';

@Component({
  selector: 'app-property-type-details',
  templateUrl: './property-type-details.component.html',
  styleUrls: ['./property-type-details.component.scss']
})

export class PropertyTypeDetailsComponent implements OnInit {

  // Login user info property
  private _loginUserInfo: UserModel = new UserModel();

  // Property type upsert model
  propertyTypeUpsertModel: PropertyTypeModel = new PropertyTypeModel();

  // Upsert button name
  upsertButtonName: string = "Save";

  constructor(private spinnerService: NgxSpinnerService, 
    private propertyTypeService: PropertyTypeService, private toastrService: ToastrService, 
    private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.spinnerService.show();

    // Check user login or not
    if(!this.isGetLoginUser()) {
      this.spinnerService.hide();
      this.toastrService.warning("You are not a login user! Please, login first.", "Warning");
      this.router.navigate(["/user/login"]);
      return;
    }

    // Get property type id
    let propertyTypeId: number | undefined = this.getExistPropertyTypeId();

    // Check property type id is null or not
    if(propertyTypeId != null || propertyTypeId != undefined) {
      this.getExistPropertyTypeById(propertyTypeId);
    }   

    this.spinnerService.hide();
  }

  submitPropertyTypeForm(): void {
    if(!this.fromValidation()) {
      this.spinnerService.show();
      this.propertyTypeService.upsert(this.propertyTypeUpsertModel).subscribe(() => {
        this.spinnerService.hide();
        this.toastrService.success(`Property Type ${this.upsertButtonName} successfull.`, "Successfull");
      });
    }
  }

  private getExistPropertyTypeId(): number | undefined {
    let propertyTypeId: number | undefined;
    this.activatedRoute.params.subscribe((res: any) => {
      propertyTypeId = res['recordId']; 
    });

    return propertyTypeId;
  }

  private getExistPropertyTypeById(propertyTypeId: number): void {
    this.spinnerService.show();    
    this.upsertButtonName = "Update";

    this.propertyTypeService.get(propertyTypeId).subscribe((result: PropertyTypeViewModel) => {
      this.propertyTypeUpsertModel = result.model!;
      this.spinnerService.hide();
    });
  }

  // Ckeck from valiadition
  private fromValidation(): boolean {
    if(this.propertyTypeUpsertModel.name == undefined || this.propertyTypeUpsertModel.name == null) {
      this,this.toastrService.error("Please, provied name.");
      return true;
    }

    return false;
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
}