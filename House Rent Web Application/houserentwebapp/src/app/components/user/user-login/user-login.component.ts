import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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
    private toastrService: ToastrService, private router: Router) {

  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
      rememberMe: [false]
    });
  }

  submitForm(): void {
    if (this.loginForm.valid) {
      let loginUser: LoginModel = this.loginForm.value;
      this.accountService.login(loginUser).subscribe((result: UserModel) => {
        localStorage.setItem("_loginUserInfo", JSON.stringify(result));
        this.toastrService.success("User login successfull.", "Successfull.");
        this.router.navigate(["/"]);
      },(error: any) => {
        console.log(error);
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