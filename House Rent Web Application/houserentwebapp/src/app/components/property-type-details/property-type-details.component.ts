import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { PropertyTypeModel } from 'src/app/models/api.model';

@Component({
  selector: 'app-property-type-details',
  templateUrl: './property-type-details.component.html',
  styleUrls: ['./property-type-details.component.scss']
})

export class PropertyTypeDetailsComponent implements OnInit {

  // Property type upsert model
  propertyTypeUpsertModel: PropertyTypeModel = new PropertyTypeModel();

  constructor(private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.spinner.show();
    this.spinner.hide();
  }
}