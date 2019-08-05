import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-test-details-list',
  templateUrl: './test-details-list.component.html',
  styleUrls: ['./test-details-list.component.css']
})
export class TestDetailsListComponent implements OnInit {
  Id : number;
  Date : Date;
  UserTests : string;
  TestTypes : string;

  constructor(private _router:Router) { }

  forNewTest(): void{
    this._router.navigate(["/create test"])
  }

  ngOnInit() {
  }

}
