import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserModel } from 'src/app/models/api.model';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})

export class NavBarComponent implements OnInit {

  // Login user name
  loginUserName: string | undefined;

  constructor(private router: Router, private toastrService: ToastrService) { }

  ngOnInit() {
  }

  getToken(): boolean {
    let loginUSerInfo: UserModel = JSON.parse(localStorage.getItem("_loginUserInfo")!);

    if(loginUSerInfo != null || loginUSerInfo != undefined) {
      this.loginUserName = loginUSerInfo.fullName;
      return true;
    }

    return false;
  }

  onLogout(): void {
    localStorage.removeItem("_loginUserInfo");
    this.toastrService.info("You are logout.");
    this.router.navigate(["/user/login"]);
  }
}