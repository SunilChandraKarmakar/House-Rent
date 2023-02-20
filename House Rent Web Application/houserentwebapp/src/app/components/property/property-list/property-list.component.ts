import { Component, OnInit } from '@angular/core';
import { Property } from 'src/app/models/property';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.scss']
})

export class PropertyListComponent implements OnInit {

  // Data source
  propertyDataSource: Property[] = [
    { id: "1", name: "Birla House", type: "House", price: 12000 },
    { id: "2", name: "Erose Villa", type: "Villa", price: 10000 },
    { id: "3", name: "Bob Duplex House", type: "Duplex House", price: 15000 },
    { id: "1", name: "Macro House", type: "House", price: 11000 },
    { id: "1", name: "Pearl White House", type: "House", price: 16000 }
  ];

  constructor() { }

  ngOnInit() {
  }

}
