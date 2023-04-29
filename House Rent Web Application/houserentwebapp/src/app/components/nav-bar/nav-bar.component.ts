import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})

export class NavBarComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  getToken(): boolean {
    let token: string = localStorage.getItem("_token")!;

    if(token != null || token != undefined) {
      return true;
    }

    return false;
  }

  onLogout(): void {
    localStorage.removeItem("_token");
    this.router.navigate(["user/login"]);
  }
}