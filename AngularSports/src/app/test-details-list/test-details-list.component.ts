import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TestDetailsService } from '../shared/test-details.service';
import { TestDetails } from '../shared/test-details.model';


@Component({
  selector: 'app-test-details-list',
  templateUrl: './test-details-list.component.html',
  styleUrls: ['./test-details-list.component.css']
})
export class TestDetailsListComponent implements OnInit {
  Id: number;
  Date: Date;
  tests: Array<TestDetails>;
  constructor(private testDetailsService: TestDetailsService, 
    private _router: Router) { }

  forNewTest(): void {
    this._router.navigate(["/create-test"])
  }
  forTestDetails(): void {
    this._router.navigate(["/athlete-details"])
  }

  ngOnInit() {
    this.testDetailsService.getTests().subscribe(
      result => {
        console.log("result");
        this.tests = result as Array<TestDetails>;
        console.log(this.tests);
      },
      err => {
        console.log(err);
      });
  }
  
}


