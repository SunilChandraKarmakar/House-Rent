import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Property } from 'src/app/models/property';
import { PropertyService } from 'src/app/services/property.service';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.scss']
})

export class PropertyListComponent implements OnInit {

  // Data source
  propertyDataSource: Property[];

  // Property type
  private _sellRent: number = 1;

  constructor(private _propertyService: PropertyService, private _activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.checkUrlIsChanged();
    this.getProperties(this._sellRent);
  }

  private getProperties(sellRentType: number): void {
    this._propertyService.getAll().subscribe((res: Property[]) => {
      this.propertyDataSource = res.filter(x => x.sellRent == sellRentType);
    },
    (error) => {
      console.log(error);
    });
  }

  private checkUrlIsChanged(): void {
    if(this._activatedRoute.snapshot.url.toString()) {
      this._sellRent = 2;
    }
  }
}