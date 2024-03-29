import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzFormTooltipIcon } from 'ng-zorro-antd/form';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { RegisterModel } from 'src/app/models/api.model';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})

export class UserRegistrationComponent implements OnInit {

  validateForm!: FormGroup;

  captchaTooltipIcon: NzFormTooltipIcon = {
    type: 'info-circle',
    theme: 'twotone'
  };

  constructor(private fb: FormBuilder, private accountService: AccountService, private toastrService: ToastrService,
  private router: Router, private spinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      fullName: [null, [Validators.required]],
      userName: [null, [Validators.required]],
      phoneNumber: [null],
      email: [null, [Validators.email, Validators.required]],
      password: [null, [Validators.required]],
      confirmPassword: [null, [Validators.required, this.confirmationValidator]],
      phoneNumberPrefix: ['+88'],
      agree: [false]
    });
  }

  submitForm(): void {
    if (this.validateForm.valid) {
      this.spinnerService.show();
      let registrationUserInfo: RegisterModel = this.validateForm.value;
      this.accountService.registration(registrationUserInfo).subscribe(() => {
        this.spinnerService.hide();
        this.toastrService.success("Registration successfull.", "Successfull.");
        this.router.navigate(["/user/login"]);
      })
    } else {
      Object.values(this.validateForm.controls).forEach(control => {
        if (control.invalid) {
          this.spinnerService.hide();
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  updateConfirmValidator(): void {
    /** wait for refresh value */
    Promise.resolve().then(() => this.validateForm.controls.confirmPassword.updateValueAndValidity());
  }

  confirmationValidator = (control: FormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else if (control.value !== this.validateForm.controls.password.value) {
      return { confirm: true, error: true };
    }
    return {};
  };

  getCaptcha(e: MouseEvent): void {
    e.preventDefault();
  }
}