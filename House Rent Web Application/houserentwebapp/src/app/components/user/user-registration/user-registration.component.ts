import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/user';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})

export class UserRegistrationComponent implements OnInit {

  // Registration form
  registrationFormGroup: FormGroup;

  // User model
  private _userModel: User = new User();

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private tosterService: ToastrService) { }

  ngOnInit() {
    this.prepiredRegistrationForm();
  }

  // Prepired registration form
  private prepiredRegistrationForm(): void {
    this.registrationFormGroup = this.formBuilder.group({
      userName: [null, Validators.required],
      email: [null, [Validators.required, Validators.email, Validators.minLength(10)]],
      mobile: [null, [Validators.required, Validators.min(1000000000), Validators.max(999999999999)]],
      password: [null, [Validators.required, 
        Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')]],
      confirmPassword: [null, [Validators.required, 
        Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')]]
    }, 
    
    {validators: this.confirmPasswordMatchingValidatior});
  }

  // Check password and confirm password are same or not
  confirmPasswordMatchingValidatior(formGroup: FormGroup): Validators {
    if(formGroup != undefined) {
      return formGroup.get('password')!.value == formGroup.get('confirmPassword')!.value ? false : { notMatch: true };
    }

    return false;
  }

  // Gatter methods for all form controls
  get userName() {
    return this.registrationFormGroup.get("userName") as FormControl;
  }

  get email() {
    return this.registrationFormGroup.get("email") as FormControl;
  }

  get mobile() {
    return this.registrationFormGroup.get("mobile") as FormControl;
  }

  get password() {
    return this.registrationFormGroup.get("password") as FormControl;
  }

  get confirmPassword() {
    return this.registrationFormGroup.get("confirmPassword") as FormControl;
  }

  // Register a new user
  onSubmit(): void {
    // console.log(this.reactiveFormGroup);

    this._userModel.userName = this.registrationFormGroup.get("userName")?.value;
    this._userModel.email = this.registrationFormGroup.get("email")?.value;
    this._userModel.mobile = this.registrationFormGroup.get("mobile")?.value;
    this._userModel.password = this.registrationFormGroup.get("password")?.value;
    
    this.authService.registerUser(this._userModel);
    this.tosterService.success("User registration successfull.", "Success");
    this.registrationFormGroup.reset();
  }
}