import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})

export class UserRegistrationComponent implements OnInit {

  // Registration form
  reactiveFormGroup: FormGroup;

  // User model
  private _userModel: User = new User();

  constructor(private _formBuilder: FormBuilder, private _userService: UserService) { }

  ngOnInit() {
    this.prepiredRegistrationForm();
  }

  // Prepired registration form
  private prepiredRegistrationForm(): void {
    this.reactiveFormGroup = this._formBuilder.group({
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
    return this.reactiveFormGroup.get("userName") as FormControl;
  }

  get email() {
    return this.reactiveFormGroup.get("email") as FormControl;
  }

  get mobile() {
    return this.reactiveFormGroup.get("mobile") as FormControl;
  }

  get password() {
    return this.reactiveFormGroup.get("password") as FormControl;
  }

  get confirmPassword() {
    return this.reactiveFormGroup.get("confirmPassword") as FormControl;
  }

  // Register a new user
  onSubmit(): void {
    // console.log(this.reactiveFormGroup);

    this._userModel.userName = this.reactiveFormGroup.get("userName")?.value;
    this._userModel.email = this.reactiveFormGroup.get("email")?.value;
    this._userModel.mobile = this.reactiveFormGroup.get("mobile")?.value;
    this._userModel.password = this.reactiveFormGroup.get("password")?.value;
    
    this._userService.AddUser(this._userModel);
    this.reactiveFormGroup.reset();
  }
}