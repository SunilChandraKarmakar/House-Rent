import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { PropertyGridModel } from 'src/app/models/api.model';
import { PropertyService } from 'src/app/services/property.service';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.scss']
})

export class PropertyListComponent implements OnInit {

  // Properity data source
  properities: PropertyGridModel[];

  // Property type
  private _sellRent: number = 1;

  constructor(private propertyService: PropertyService, private activatedRoute: ActivatedRoute, 
    private spinnerService: NgxSpinnerService, private toastrService: ToastrService) { }

  ngOnInit() {
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
    if(this.activatedRoute.snapshot.url.toString()) {
      this._sellRent = 2;
    }
  }
}