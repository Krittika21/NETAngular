import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TestDetailsService } from '../shared/test-details.service';
import { TestDetails } from '../shared/test-details.model';
import { User } from '../shared/user.model';
import { UserDetailsService } from '../shared/user-details.service';
import { UserTypeMap } from '../shared/user-type-map.model';

@Component({
  selector: 'app-athlete-details',
  templateUrl: './athlete-details.component.html',
  styleUrls: ['./athlete-details.component.css']
})
export class AthleteDetailsComponent implements OnInit {
  test: TestDetails;
  currentTestId: number;
  athleteMap: any;

  constructor(private userDetailsService:UserDetailsService, private testDetailsService:TestDetailsService, private _router:Router, private router: ActivatedRoute) { }
  
  forNewAthlete(): void
  {

    this._router.navigate(["test/" + this.currentTestId+ "/add-athlete"])
  }
  
  toDeleteTest()
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

  ngOnInit() {
    this.currentTestId = +this.router.snapshot.paramMap.get('id');
    this.testDetailsService.getCurrentTest(this.currentTestId).subscribe(
      (result:TestDetails) =>{
        this.test = result
        console.log(this.test);
      }
    );      

    this.userDetailsService.getAthleteById(this.currentTestId).subscribe(
      result => {
        this.athleteMap = result as any;
        console.log(this.athleteMap);
      },
      error => {
        console.log(error)
      }
    );
    
  }
}