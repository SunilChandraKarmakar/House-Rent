import { Component, OnInit } from '@angular/core';
import { Property } from 'src/app/models/property';

@Component({
  selector: 'app-property-card',
  templateUrl: './property-card.component.html',
  styleUrls: ['./property-card.component.scss']
})

export class PropertyCardComponent implements OnInit {

  // Property model
  property: Property = { 
    id: "1", 
    name: "Birla House", 
    type: "House", 
    price: 12000 
  };

  constructor() { }

  ngOnInit() {
  }
}