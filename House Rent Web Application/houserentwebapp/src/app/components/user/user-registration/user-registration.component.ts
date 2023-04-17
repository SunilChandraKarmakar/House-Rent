import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})

export class UserRegistrationComponent implements OnInit {

  reactiveFormGroup: FormGroup;

  constructor() { }

  ngOnInit() {
    this.reactiveFormGroup = new FormGroup({
      userName: new FormControl(null, Validators.required),
      email: new FormControl(null, [Validators.required, Validators.email, Validators.minLength(10)]),
      mobile: new FormControl(null, [Validators.required, Validators.min(1000000000), Validators.max(999999999999)]),
      password: new FormControl(null, [Validators.required, 
        Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')]),
      confirmPassword: new FormControl(null, [Validators.required, 
        Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')])
    },

    this.confirmPasswordMatchingValidatior(this.reactiveFormGroup));
  }

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

  onSubmit(): void {
    console.log(this.reactiveFormGroup);
  }
}