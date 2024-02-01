import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { PropertyGridModel, UserModel } from 'src/app/models/api.model';
import { PropertyService } from 'src/app/services/property.service';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.scss']
})

export class PropertyListComponent implements OnInit {

  // Login user info property
  private _loginUserInfo: UserModel = new UserModel();

  // Properity data source
  properities: PropertyGridModel[];

  // Property type
  private _sellRent: number = 1;

  constructor(private propertyService: PropertyService, private activatedRoute: ActivatedRoute, 
  private spinnerService: NgxSpinnerService, private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {

    // Check user login or not
    if(!this.isGetLoginUser()) {
      this.spinnerService.hide();
      this.toastrService.warning("You are not a login user! Please, login first.", "Warning");
      this.router.navigate(["/user/login"]);
      return;
    }

    this.checkUrlIsChanged();
    this.getProperties(this._sellRent);
  }

  private getProperties(sellRentType: number): void {
    this.spinnerService.show();
    this.propertyService.getAll().subscribe((res: PropertyGridModel[]) => {
      this.properities = res.filter(x => x.sellRent == sellRentType);
      this.spinnerService.hide();
    },
    (error) => {
      this.spinnerService.hide();
      this.toastrService.error(error, "Error");
    });
  }

  private checkUrlIsChanged(): void {
    let routingUrl: string = this.activatedRoute.snapshot.url.toString();

    if(routingUrl.match("rent-property")) {
      this._sellRent = 2;
    }
  }

  private isGetLoginUser(): boolean {
    // Get current user token
    this._loginUserInfo = JSON.parse(localStorage.getItem("_loginUserInfo")!);

    if(this._loginUserInfo == null) {
      return false;
    }
    else {
      return true;
    }
  }
}