import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TestDetailsService } from '../shared/test-details.service';
import { TestDetails } from '../shared/test-details.model';
import { TestType } from '../shared/test-type.model';

@Component({
  selector: 'app-new-test',
  templateUrl: './new-test.component.html',
  styleUrls: ['./new-test.component.css']
})
export class NewTestComponent implements OnInit {
  
  ID: number;
  TestName: string;
  testType: Array<TestType>;
  test: TestDetails;

  constructor(private testDetailsService:TestDetailsService,
    private _router:Router) { }    
  
  ngOnInit() 
  {
    this.test = 
    {
      id:0,
      date: null,
      testType:null,
      //testId: 0;
    }
    //get test types 
    this.testDetailsService.getTestType().subscribe(
      result => 
      {
        console.log("result");
        this.testType = result as Array<TestType>;
        console.log(this.testType);
        debugger;
      },
      err => 
      {
        console.log(err);
      });
  }
  onSubmit()
  {    
    this.testDetailsService.postTests(this.test).subscribe(
      result => {
        console.log(result);
        this._router.navigate(["/test-details"]);
      },
      err => {
        console.log(err);
      });
  }
}