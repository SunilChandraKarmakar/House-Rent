import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})

export class AddPropertyComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  ngFormSubmit(form: NgForm): void {
    console.log("Form submited.");
    console.log("Form Value :- ", form);
  }

}