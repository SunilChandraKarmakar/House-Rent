import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { LoginModel, UserModel } from 'src/app/models/api.model';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss'],
  providers: []
})

export class UserLoginComponent implements OnInit {

  // Login form
  loginForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private accountService: AccountService, 
    private toastrService: ToastrService, private router: Router, private spinner: NgxSpinnerService) {

  }

  ngOnInit(): void {
    this.spinner.hide();
    this.loginForm = this.formBuilder.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
      rememberMe: [false]
    });
  }

  submitForm(): void {
    if (this.loginForm.valid) {
      this.spinner.show();
      let loginUser: LoginModel = this.loginForm.value;
      this.accountService.login(loginUser).subscribe((result: UserModel) => {
        localStorage.setItem("_loginUserInfo", JSON.stringify(result));
        this.spinner.hide();
        this.toastrService.success("Login successfull.", "Successfull.");
        this.router.navigate(["/"]);
      });
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