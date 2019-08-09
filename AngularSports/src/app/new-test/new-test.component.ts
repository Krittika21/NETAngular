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
  testType: TestType;
  test: TestDetails;

  constructor(private testDetailsService:TestDetailsService,
    private _router:Router) { }    
  
  ngOnInit() 
  {
    this.test = 
    {
      Id:0,
      Date: null,
      TestType:null
    }
    this.testDetailsService.getTestType().subscribe(
      result => 
      {
        this.testType = result as TestType;
        console.log(this.testType);
      },
      err => {
        console.log(err);
      }
    );
  }
  onSubmit(){
    
    this.testDetailsService.postTests(this.test).subscribe(
      result => {
        console.log(result);
      },
      err => {
        console.log(err);
      });
      this._router.navigate(["/test-details"])

  }
}