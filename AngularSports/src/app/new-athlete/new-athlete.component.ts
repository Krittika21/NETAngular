import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../shared/user.model';
import { UserDetailsService } from '../shared/user-details.service';
import { UserTypeMap } from '../shared/user-type-map.model';
import { TestDetailsService } from '../shared/test-details.service';



@Component({
  selector: 'app-new-athlete',
  templateUrl: './new-athlete.component.html',
  styleUrls: ['./new-athlete.component.css']
})
export class NewAthleteComponent implements OnInit {
athletes: UserTypeMap;
users: Array<User>;
isAvailable : boolean;
test :any;

  constructor(private testDetailsService: TestDetailsService, private userDetailsService: UserDetailsService, private _router: Router, private _route: ActivatedRoute) 
  {
    this.isAvailable = false;
  }
  
  ngOnInit() {
    this.testDetailsService.getCurrentTest(+this._route.snapshot.paramMap.get("testId")).subscribe(
      (result) =>{
        this.test = result
        console.log(this.test);
      }
    );      

    this.athletes =
    {
      Name:null,
      CTDistance: 0,
      STTime: 0,
      fitnessRating: null,
      testId: +this._route.snapshot.paramMap.get("testId"),
      userId: 0,
    }

    this.userDetailsService.getAthletes().subscribe(
      result  => {
        console.log("result");
        this.users = result as Array<User>;
        console.log(this.users);
        this.isAvailable = true;
      },
      err => {
        console.log(err);
      });
  }
  onSubmit()
  {
    this.userDetailsService.postAthletes(this.athletes).subscribe(
      (result: Array<UserTypeMap>) => {
        this._router.navigate(['/athlete-details/'+ this.athletes.testId])
      },
      err => {
        console.log("error");
      });

  }
}
