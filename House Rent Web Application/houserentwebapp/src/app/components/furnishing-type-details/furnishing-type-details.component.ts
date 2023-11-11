import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { FurnishingTypeModel, FurnishingTypeViewModel } from 'src/app/models/api.model';
import { FurnishingTypeService } from 'src/app/services/furnishing-type.service';
import { CheckValidLoginUser } from 'src/app/utility/check-valid-login-user';

@Component({
  selector: 'app-furnishing-type-details',
  templateUrl: './furnishing-type-details.component.html',
  styleUrls: ['./furnishing-type-details.component.scss']
})

export class FurnishingTypeDetailsComponent implements OnInit {

  // Furnishing type upsert model
  furnishingTypeUpsertModel: FurnishingTypeModel = new FurnishingTypeModel();

  // Upsert button name
  upsertButtonName: string = "Save";

  constructor(private spinnerService: NgxSpinnerService, 
  private furnishingTypeService: FurnishingTypeService, private toastrService: ToastrService, 
  private activatedRoute: ActivatedRoute) { }

  ngOnInit() {


    this.spinnerService.show();

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
      this,this.toastrService.error("Please, provied name.");
      return true;
    }

    return false;
  }

  // Checl user is login or not
  private checkUserIsLoginOrNot(): void {
    let isLogin: boolean | undefined = CheckValidLoginUser.isLoginUser();

    if(isLogin) {
      return 
    }
  }
}