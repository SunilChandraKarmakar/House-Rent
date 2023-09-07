import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { PropertyTypeGridModel } from 'src/app/models/api.model';
import { PropertyTypeService } from 'src/app/services/property-type.service';

@Component({
  selector: 'app-property-type-list',
  templateUrl: './property-type-list.component.html',
  styleUrls: ['./property-type-list.component.scss']
})

export class PropertyTypeListComponent implements OnInit {

  constructor(private propertyTypeService: PropertyTypeService, private spinner: NgxSpinnerService) { }

  propertyTypes: PropertyTypeGridModel[] = [];

  ngOnInit() {
    this.spinner.show();
    this.propertyTypeService.getAll().subscribe((result: PropertyTypeGridModel[]) => {
      this.propertyTypes = result;
      this.spinner.hide();
    });
  }
}