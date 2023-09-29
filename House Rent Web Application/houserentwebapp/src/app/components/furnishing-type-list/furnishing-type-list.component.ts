import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { FurnishingTypeGridModel } from 'src/app/models/api.model';
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

  ngOnInit() {
    this.spinner.show();
    this.furnishingTypeService.getAll().subscribe((result: FurnishingTypeGridModel[]) => {
      this.furnishingTypes = result;
      this.spinner.hide();
    });
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
}