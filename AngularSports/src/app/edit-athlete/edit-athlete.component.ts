import { Component, OnInit } from '@angular/core';
import { TestDetailsService } from '../shared/test-details.service';
import { UserDetailsService } from '../shared/user-details.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserTypeMap } from '../shared/user-type-map.model';
import { User } from '../shared/user.model';

@Component({
  selector: 'app-edit-athlete',
  templateUrl: './edit-athlete.component.html',
  styleUrls: ['./edit-athlete.component.css']
})
export class EditAthleteComponent implements OnInit {
  athletes: UserTypeMap;
  users: Array<User>;
  isAvailable: boolean;
  test: UserTypeMap = new UserTypeMap();

  constructor(private testDetailsService: TestDetailsService, private userDetailsService: UserDetailsService, private _router: Router, private _route: ActivatedRoute)
  {
    this.isAvailable = false;
   }

  ngOnInit() {
    this.testDetailsService.getTestWithAthlete(+this._route.snapshot.paramMap.get("testId"), +this._route.snapshot.paramMap.get("userId")).subscribe(
      (result: UserTypeMap) =>{
        this.test = result;
        this.isAvailable = true;
        console.log(this.test);
      }
    );      

    /* this.athletes =
    {
      Name:null,
      CTDistance: 0,
      STTime: 0,
      fitnessRating: null,
      testId: +this._route.snapshot.paramMap.get("testId"),
      userId: +this._route.snapshot.paramMap.get("userId"),
    } */
  }
  onSubmit()
  {
    this.userDetailsService.putAthletes(this.test).subscribe(
      (result: Array<UserTypeMap>) => {
        this._router.navigate(['/athlete-details/'+ this.test.testId])
      },
      err => {
        console.log("error");
      });

  }
}

