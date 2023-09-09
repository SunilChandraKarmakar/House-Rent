import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { PropertyTypeModel } from 'src/app/models/api.model';
import { PropertyTypeService } from 'src/app/services/property-type.service';

@Component({
  selector: 'app-property-type-details',
  templateUrl: './property-type-details.component.html',
  styleUrls: ['./property-type-details.component.scss']
})

export class PropertyTypeDetailsComponent implements OnInit {

  // Property type upsert model
  propertyTypeUpsertModel: PropertyTypeModel = new PropertyTypeModel();

  // Property type form
  propertyTypeForm: FormGroup;

  constructor(private spinnerService: NgxSpinnerService, private formBuilder: FormBuilder, 
  private propertyTypeService: PropertyTypeService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.spinnerService.show();
    this.propertyTypeForm = this.formBuilder.group({
      name: [null, [Validators.required]]
    });

    this.spinnerService.hide();
  }

  submitPropertyTypeForm(): void {
    this.spinnerService.show();
    this.propertyTypeUpsertModel = this.propertyTypeForm.value;
    this.propertyTypeService.upsert(this.propertyTypeUpsertModel).subscribe(() => {
      this.spinnerService.hide();
      this.toastrService.success("Property Type save successfull.", "Successfull");
      this.rsetPropertyTypeForm();
    })
  }

  rsetPropertyTypeForm(): void {
    this.propertyTypeForm.reset();
  }
}