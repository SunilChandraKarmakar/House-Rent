import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NzImageService } from 'ng-zorro-antd/image';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.scss']
})

export class PropertyDetailComponent implements OnInit {

  // Property id
  private _propertyId: number | undefined;

  testData: string = "This is test data";

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private nzImageService: NzImageService) { }

  ngOnInit() {
    this.getSelectedPropertyId();

    console.log("Property Id :- ", this._propertyId)
  }

  // Get property id based on selected property
  private getSelectedPropertyId(): void {
    this._propertyId = +this.activatedRoute.snapshot.params["id"];
  }

  onBack(): void {
    this.router.navigate(["/"]);
  }

  onNextPage(): void {
    this._propertyId = this._propertyId! + 1;
    this.router.navigate([`property-detail/${this._propertyId}`])
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
}