import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TestDetailsService } from '../shared/test-details.service';
import { TestDetails } from '../shared/test-details.model';
import { TestType } from '../shared/test-type.model';


@Component({
  selector: 'app-test-details-list',
  templateUrl: './test-details-list.component.html',
  styleUrls: ['./test-details-list.component.css']
})
export class TestDetailsListComponent implements OnInit {
  Id: number;
  Date: Date;
  tests: Array<TestDetails>;
  teststype: any;
  
  constructor(private testDetailsService: TestDetailsService, 
    private _router : Router) { }

  forNewTest(): void {
    this._router.navigate(["/create-test"])
  }
  forTestDetails(test: TestDetails): void {
    this.testDetailsService.setCurrentTestId(test.id);
  }

  ngOnInit() {
    this.testDetailsService.getTests().subscribe(
      (result: Array<TestDetails>) => {
        console.log("result");
        this.tests = result;
        console.log(this.tests);
      },
      err => {
        console.log(err);
      });
       this.testDetailsService.getTestType().subscribe(
        result => {
          console.log("result");
          this.teststype = result as Array<TestDetails>;
          console.log(this.tests);
      },
      err => {
        console.log(err);
      }); 
      
  }
  
}


