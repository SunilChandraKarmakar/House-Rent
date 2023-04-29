import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { LoginViewModel } from '../models/login-view-model';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor() { }

  registerUser(user: User): void {
    localStorage.setItem("_user", JSON.stringify(user));
  }

  loginUser(loginViewModel: LoginViewModel): User |undefined {
    let user: User = new User();

    if(localStorage.getItem("_user")) {
      let userInfo = JSON.parse(localStorage.getItem("_user")!);
      user.email = userInfo.email;
      user.password = userInfo.password;
    }

    if(user.email == loginViewModel.email && user.password == loginViewModel.password) {
      return user;
    }
    else {
      return undefined;
    }
  }
}