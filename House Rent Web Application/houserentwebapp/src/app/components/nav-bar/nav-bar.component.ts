import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

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
    let token: string = localStorage.getItem("_token")!;

    if(token != null || token != undefined) {
      this.loginUserName = token;
      return true;
    }

    return false;
  }

  onLogout(): void {
    localStorage.removeItem("_token");
    this.toastrService.info("You are logout.");
    this.router.navigate(["/user/login"]);
  }
}