import { Component, OnInit } from '@angular/core';
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

  constructor(private _propertyService: PropertyService) { }

  ngOnInit() {
    this._propertyService.getAll().subscribe((res: Property[]) => {
      this.propertyDataSource = res;
    },
    (error) => {
      console.log(error);
    })
    
  }

}
