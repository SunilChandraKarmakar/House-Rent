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
  propertyId: number | undefined;

  testData: string = "This is test data.";

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private nzImageService: NzImageService) { }

  ngOnInit() {
    this.propertyId = +this.activatedRoute.snapshot.params["id"];
    this.activatedRoute.params.subscribe((res) => {
      this.propertyId = +res["id"];
    });
  }

  onBack(): void {
    this.router.navigate(["/"]);
  }

  onNextPage(): void {
    this.propertyId = this.propertyId! + 1;
    this.router.navigate([`property-detail/${this.propertyId}`])
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