import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';

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

  // Form goup
  formGroup: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      radioValue: [null, [Validators.required]],
      number: [null, [Validators.required]]
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
}