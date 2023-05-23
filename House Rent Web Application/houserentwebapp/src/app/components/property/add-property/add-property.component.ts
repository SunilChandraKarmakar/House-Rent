import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})

export class AddPropertyComponent implements OnInit {

  // Selected tab index
  nzSelectedTabIndex: number = 0;

  constructor() { }

  ngOnInit() {
  }

  ngFormSubmit(form: NgForm): void {
    console.log("Form submited.");
    console.log("Form Value :- ", form);
  }

  // Go forward tab login
  onGoForwardTab(tabIndex: number): void {
    this.nzSelectedTabIndex += tabIndex;
  }

  onGoBackTab(tabIndex: number): void {
    this.nzSelectedTabIndex -= tabIndex;
  }

  indexChange(event: any): void {
    this.nzSelectedTabIndex = event;
  }

}