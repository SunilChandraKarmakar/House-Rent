import { Component, Input, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { PhotoViewModel, PropertyGridModel } from 'src/app/models/api.model';

@Component({
  selector: 'app-property-card',
  templateUrl: './property-card.component.html',
  styleUrls: ['./property-card.component.scss']
})

export class PropertyCardComponent implements OnInit {

  // Received data in property list component
  @Input() property: PropertyGridModel = new PropertyGridModel();

  // Show and hide edit/delete button based on condition
  @Input() showHideEditDeleteButton: boolean = false;

  // Show and hide card shadow
  @Input() showHideShadowInCard: boolean = true;

  // Property featured photo
  propertyFeaturedPhoto: string | undefined = this.property.photos.find((x: PhotoViewModel) => x.isDefault)?.url;

  constructor(private spinnerService: NgxSpinnerService) { }

  ngOnInit() {
    this.spinnerService.show();
    this.spinnerService.hide();
  }
}