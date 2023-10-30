import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NzImageService } from 'ng-zorro-antd/image';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { PropertyGridModel, PropertyViewModel } from 'src/app/models/api.model';
import { PropertyService } from 'src/app/services/property.service';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.scss']
})

export class PropertyDetailComponent implements OnInit {

  // Property id
  private _propertyId: number | undefined;

  // Property model
  propertyModel: PropertyGridModel = new PropertyGridModel();

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private nzImageService: NzImageService,
  private toastrService: ToastrService, private spinnerService: NgxSpinnerService, private propertyService: PropertyService) { }

  ngOnInit() {
    this.getSelectedPropertyId();
    this.getPropertyDetails();
  }

  // Get property id based on selected property
  private getSelectedPropertyId(): void {
    this._propertyId = +this.activatedRoute.snapshot.params["id"];
  }

  onBack(): void {
    this.router.navigate(["/"]);
  }

  previewAllImages(): void {
    const images = [
      {
        src: 'https://img.alicdn.com/tfs/TB1g.mWZAL0gK0jSZFtXXXQCXXa-200-200.svg',
        width: '200px',
        height: '200px',
        alt: 'ng-zorro'
      },
      {
        src: 'https://img.alicdn.com/tfs/TB1Z0PywTtYBeNjy1XdXXXXyVXa-186-200.svg',
        width: '200px',
        height: '200px',
        alt: 'angular'
      }
    ];
    
    this.nzImageService.preview(images, { nzZoom: 1.5, nzRotate: 0 });
  }

  // Get property details based on selected property id
  private getPropertyDetails(): void {
    this.spinnerService.show();
    this.propertyService.get(this._propertyId!).subscribe((result: PropertyViewModel) => {
      this.propertyModel = result.gridModel;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("Selected property details cannot find!", "Error");
    })
  }
}