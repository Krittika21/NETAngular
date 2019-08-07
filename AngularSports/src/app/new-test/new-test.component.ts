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
  testType: Array<TestType>
  test: TestDetails = new TestDetails();

  constructor(private testDetailsService:TestDetailsService,
    private _router:Router) { }
  
  ngOnInit() {
    this.testDetailsService.getTestType().subscribe(
      
    )
  }
  onSubmit(){
    this.testDetailsService.postTests(this.test);

  }
}