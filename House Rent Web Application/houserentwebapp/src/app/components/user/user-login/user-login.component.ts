import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginViewModel } from 'src/app/models/login-view-model';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})

export class UserLoginComponent implements OnInit {

  validateForm!: FormGroup;

  // Login form
  loginFormGroup: FormGroup;

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private toastrService: ToastrService,
    private router: Router, private fb: FormBuilder) { }

  ngOnInit() {
    this.prepiredRegistrationForm();

    this.validateForm = this.fb.group({
      userName: [null, [Validators.required]],
      password: [null, [Validators.required]],
      remember: [null, [Validators.required]]
    });
  }

  // Prepired login form
  private prepiredRegistrationForm(): void {
    this.loginFormGroup = this.formBuilder.group({
      email: [null, [Validators.required, Validators.email, Validators.minLength(10)]],
      password: [null, [Validators.required, 
        Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')]]
    });
  }

  get email() {
    return this.loginFormGroup.get("email") as FormControl;
  }

  get password() {
    return this.loginFormGroup.get("password") as FormControl;
  }

  onSubmit(): void {
    let loginViewModel: LoginViewModel = new LoginViewModel();
    loginViewModel.email = this.email.value;
    loginViewModel.password = this.password.value;

    let loginUserInfo: User | undefined = this.authService.loginUser(loginViewModel);

    if(loginUserInfo != undefined) {
      localStorage.setItem("_token", loginUserInfo.email!);
      this.toastrService.success("Login successful.");
      this.router.navigate(["/"]);
    }
    else {
      this.toastrService.error("Login failed! Please try again.");
    }
  }

  submitForm(): void {
    if (this.validateForm.valid) {
      console.log('submit', this.validateForm.value);
    } else {
      Object.values(this.validateForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }
}