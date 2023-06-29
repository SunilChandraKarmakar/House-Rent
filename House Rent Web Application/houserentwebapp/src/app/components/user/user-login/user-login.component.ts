import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Country, CountryClient } from 'src/app/utility/global-api';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss'],
  providers: []
})

export class UserLoginComponent implements OnInit {

  // Test code for global api

  // Login form
  loginForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private country: CountryClient) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
      rememberMe: [false, Validators.requiredTrue]
    });

    this.country.get(1).catch(res => {
      console.log("Country Details :- ", res);
    });
    
  }

  submitForm(): void {
    if (this.loginForm.valid) {
      console.log('submit', this.loginForm.value);
    } 
    else {
      Object.values(this.loginForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }
}