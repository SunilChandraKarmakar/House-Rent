import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Property } from 'src/app/models/property';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})

export class AddPropertyComponent implements OnInit {

  // Selected tab index
  nzSelectedTabIndex: number = 0;

  radioValue: string = 'A';
  number: number | undefined;
  date = null;

  // Form goup
  formGroup: FormGroup;

  // Perview add property in property card component
  previewAddPropertyModel: Property = new Property();

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      radioValue: [null, [Validators.required]],
      number: [null, [Validators.required]],
      date: [null]
    });
  }

  submitForm(): void {
    
  }

  // Go forward tab login
  onGoForwardTab(tabIndex: number): void {
    this.nzSelectedTabIndex += tabIndex;
  }

  // Go back tab login
  onGoBackTab(tabIndex: number): void {
    this.nzSelectedTabIndex -= tabIndex;
  }

  // Get tab index when tab is change
  indexChange(event: any): void {
    this.nzSelectedTabIndex = event;
  }

  // Date on change function
  onChange(result: Date): void {
    console.log('onChange: ', result);
  }
}