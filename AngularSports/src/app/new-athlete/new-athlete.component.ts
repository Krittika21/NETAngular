import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { stringify } from 'querystring';
import { User } from '../shared/user.model';
import { UserDetailsService } from '../shared/user-details.service';
import { UserTypeMap } from '../shared/user-type-map.model';

@Component({
  selector: 'app-new-athlete',
  templateUrl: './new-athlete.component.html',
  styleUrls: ['./new-athlete.component.css']
})
export class NewAthleteComponent implements OnInit {
ID: number;
Name: string;
CTDistance: number;
STTime: number;
FitnessRating: string;
athletes: UserTypeMap;
users: Array<User>;
isAvailable : boolean;


  constructor(private userDetailsService: UserDetailsService, private _router: Router, private _route: ActivatedRoute) 
  {
    this.isAvailable = false;
  }
  
  ngOnInit() {
    this.athletes =
    {
      Name:null,
      CTDistance: 0,
      STTime: 0,
      fitnessRating: null,
      testId: +this._route.snapshot.paramMap.get("testId"),
      //userId: 0
      //userId: +this._route.snapshot.paramMap.get("user.userId")
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
    debugger;
    this.userDetailsService.postAthletes(this.athletes).subscribe(
      result=> {
        console.log(result);
        this._router.navigate(["/athlete-details/:id"]);
      },
      err => {
        console.log(err);
      }
    );
    debugger;
  }

}
