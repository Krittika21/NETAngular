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
  test: TestDetails | undefined;
  currentTestId: number;
  details: Array<User>;
  athleteMap: Array<UserTypeMap>;
  //athletes: Array<AthleteDetailsComponent>;
  Id: number;
  Name: null;
  CTDistance: 0;
  STTime: 0;
  fitnessRating: null;

  constructor(private userDetailsService:UserDetailsService, private testDetailsService:TestDetailsService, private _router:Router, private router: ActivatedRoute) { }
  
  forNewAthlete(): void{
    this._router.navigate(["/add-athlete"])
  }
  toDeleteTest()
  {
    this._router.navigate(["/test-details"])
  }

  ngOnInit() {
    this.currentTestId = +this.router.snapshot.paramMap.get('id');
    this.testDetailsService.getCurrentTest(this.currentTestId).subscribe(
      (result:TestDetails) =>{
        this.test = result
      }
    );
    console.log(this.currentTestId);   
    this.userDetailsService.getAthletes().subscribe(
      (result: Array<User>) => {
        console.log("result");
        this.details = result;
      
        console.log(this.details);
      },
      err => {
        console.log(err);
      });
      this.userDetailsService.getAthletes().subscribe(
        (result: Array<UserTypeMap>) => {
          console.log("result");
          this.athleteMap = result;
          console.log(this.athleteMap);
        },
        err => {
          console.log(err);
        });
  }
}