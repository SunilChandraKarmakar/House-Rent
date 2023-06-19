import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.scss']
})

export class PropertyDetailComponent implements OnInit {

  // Property id
  propertyId: number | undefined;

  constructor(private _activatedRoute: ActivatedRoute, private _router: Router) { }

  ngOnInit() {
    this.propertyId = +this._activatedRoute.snapshot.params["id"];
    this._activatedRoute.params.subscribe((res) => {
      this.propertyId = +res["id"];
    });
  }

  onBack(): void {
    this._router.navigate(["/"]);
  }

  onNextPage(): void {
    this.propertyId = this.propertyId! + 1;
    this._router.navigate([`property-detail/${this.propertyId}`])
  }
}