import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TestDetailsService } from '../../shared/test-details.service';
import { TestDetails } from '../../shared/test-details.model';
import { User } from '../../shared/user.model';
import { UserDetailsService } from '../../shared/user-details.service';
import { UserTypeMap } from '../../shared/user-type-map.model';

@Component({
  selector: 'app-athlete-details',
  templateUrl: './athlete-details.component.html',
  styleUrls: ['./athlete-details.component.css']
})
export class AthleteDetailsComponent implements OnInit {
  test: any;
  userTest: any;
  tests: Array<TestDetails>;
  users: Array<UserTypeMap>;
  currentTestId: number;
  
  constructor(private userDetailsService:UserDetailsService, private testDetailsService:TestDetailsService, private _router:Router, private router: ActivatedRoute) { 
    this.currentTestId= + this.router.snapshot.paramMap.get("id");
  }
  
  forNewAthlete(): void
  {
    this._router.navigate(["test/" + this.currentTestId+ "/add-athlete"])
  }
  
  toDeleteTest(){
  if(confirm("Are you sure you want to continue?"))
  {
    this.testDetailsService.deleteTestDetails(this.currentTestId).subscribe(
      (result:TestDetails) =>{
        this._router.navigate(["/test-details"]);
      },
      error => {
        console.log(error)
      }
    );
  }
  }

  ngOnInit() {
    this.testDetailsService.getCurrentTest(this.currentTestId).subscribe(
      result => {
        this.test = result as any;
        this.users = result as Array<UserTypeMap>;
         console.log(this.test);
      },
      error => {
        console.log(error)
      }
    );
    
  }
}