import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { FurnishingTypeModel, FurnishingTypeViewModel, UserModel } from 'src/app/models/api.model';
import { FurnishingTypeService } from 'src/app/services/furnishing-type.service';

@Component({
  selector: 'app-furnishing-type-details',
  templateUrl: './furnishing-type-details.component.html',
  styleUrls: ['./furnishing-type-details.component.scss']
})

export class FurnishingTypeDetailsComponent implements OnInit {

  // Login user info property
  private _loginUserInfo: UserModel = new UserModel();

  // Furnishing type upsert model
  furnishingTypeUpsertModel: FurnishingTypeModel = new FurnishingTypeModel();

  // Upsert button name
  upsertButtonName: string = "Save";

  constructor(private spinnerService: NgxSpinnerService, 
    private furnishingTypeService: FurnishingTypeService, private toastrService: ToastrService, 
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

    // Get furnishing type id
    let furnishingTypeId: number | undefined = this.getExistFurnishingTypeId();

    // Check furnishing type id is null or not
    if(furnishingTypeId != null || furnishingTypeId != undefined) {
      this.getExistFurnishingTypeById(furnishingTypeId);
    }   

    this.spinnerService.hide();
  }

  submitFurnishingTypeForm(): void {
    if(!this.fromValidation()) {
      this.spinnerService.show();
      this.furnishingTypeService.upsert(this.furnishingTypeUpsertModel).subscribe(() => {
        this.spinnerService.hide();
        this.toastrService.success(`Furnishing Type ${this.upsertButtonName} successfull.`, "Successfull");
      });
    }
  }

  private getExistFurnishingTypeId(): number | undefined {
    let furnishingTypeId: number | undefined;
    this.activatedRoute.params.subscribe((res: any) => {
      furnishingTypeId = res['recordId']; 
    });

    return furnishingTypeId;
  }

  private getExistFurnishingTypeById(propertyTypeId: number): void {
    this.spinnerService.show();    
    this.upsertButtonName = "Update";

    this.furnishingTypeService.get(propertyTypeId).subscribe((result: FurnishingTypeViewModel) => {
      this.furnishingTypeUpsertModel = result.model!;
      this.spinnerService.hide();
    });
  }

  // Ckeck from valiadition
  private fromValidation(): boolean {
    if(this.furnishingTypeUpsertModel.name == undefined || this.furnishingTypeUpsertModel.name == null) {
      this.toastrService.error("Please, provied name.");
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