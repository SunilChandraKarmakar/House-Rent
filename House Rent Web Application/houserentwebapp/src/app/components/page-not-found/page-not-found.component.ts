import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.component.html',
  styleUrls: ['./page-not-found.component.scss']
})

export class PageNotFoundComponent implements OnInit {

  constructor(private spinnerService: NgxSpinnerService) { }

  ngOnInit() {
    this.spinnerService.show();
    this.spinnerService.hide();
  }
}