import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryService } from 'src/app/services/country.service';

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

  constructor(private formBuilder: FormBuilder, private countryService: CountryService) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
      rememberMe: [false, Validators.requiredTrue]
    });

    this.countryService.getCountries().subscribe((res) => {
      console.log("Countries :- ", res);
    })
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