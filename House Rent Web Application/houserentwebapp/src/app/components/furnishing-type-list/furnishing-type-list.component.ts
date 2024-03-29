import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { FurnishingTypeGridModel, UserModel } from 'src/app/models/api.model';
import { FurnishingTypeService } from 'src/app/services/furnishing-type.service';

@Component({
  selector: 'app-furnishing-type-list',
  templateUrl: './furnishing-type-list.component.html',
  styleUrls: ['./furnishing-type-list.component.scss']
})

export class FurnishingTypeListComponent implements OnInit {

  constructor(private furnishingTypeService: FurnishingTypeService, private spinner: NgxSpinnerService, 
  private toastrService: ToastrService, private router: Router) { }

  furnishingTypes: FurnishingTypeGridModel[] = [];

  ngOnInit(): void {
    let isUserLogin: boolean = this.checkUserLoginOrNot()!;

    if(isUserLogin) {
      this.spinner.show();
      this.furnishingTypeService.getAll().subscribe((result: FurnishingTypeGridModel[]) => {
        this.furnishingTypes = result;
        this.spinner.hide();
      },
      (error: any) => {
        console.log("error :- ", error);
      });
    }
    else {
      this.toastrService.warning("Please, login first.", "Warning");
      this.router.navigate(["/user/login"]);
    }
  }

  deleteFurnishingType(id: number): void {
    this.spinner.show();
    this.furnishingTypeService.delete(id).subscribe(() => {
      this.spinner.hide();
      this.toastrService.success("Furnishing Type Deleted.", "Successfull");
      this.ngOnInit();
    })
  }

  cancel(): void {
  }

  updateFurnishingType(id: number): void {
    this.spinner.show();
    this.router.navigate([`/furnishing-type/details/${id}`]);
  }

  // Check user login or not
  private checkUserLoginOrNot(): boolean | undefined {
    let loginUserInfo: UserModel = JSON.parse(localStorage.getItem("_loginUserInfo")!);

    if (loginUserInfo == null || loginUserInfo == undefined) {
      return false;
    }
    else {
      return true;
    }
  }
}