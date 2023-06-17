import { Component, Input, OnInit } from '@angular/core';
import { Property } from 'src/app/models/property';

@Component({
  selector: 'app-property-card',
  templateUrl: './property-card.component.html',
  styleUrls: ['./property-card.component.scss']
})

export class PropertyCardComponent implements OnInit {

  // Received data in property list component
  @Input() property: Property = new Property();

  // Show and hide edit/delete button based on condition
  @Input() showHideEditDeleteButton: boolean = false;

  // Show and hide card shadow
  @Input() showHideShadowInCard: boolean = true;

  constructor() { }

  ngOnInit() {
  }
}