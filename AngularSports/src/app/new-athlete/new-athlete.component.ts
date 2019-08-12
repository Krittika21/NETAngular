import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { stringify } from 'querystring';
import { User } from '../shared/user.model';
import { UserDetailsService } from '../shared/user-details.service';

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
testList: User;
users: Array<User>;

  constructor(private userDetailsService: UserDetailsService, private _router: Router) { }
  
  ngOnInit() {
    this.testList =
    {
      id:0,
      name: null,
      CTDistance: 0,
      STTime: 0,
      fitnessRating: null,
      userType:null
    }
    this.userDetailsService.getAthletes().subscribe(
      (result: Array<User>) => {
        console.log("result");
        debugger;
        this.users = result;
        console.log(this.users);
        debugger;
      },
      err => {
        console.log(err);
      }
    );

  }
  Submit()
  {
    this.userDetailsService.postAthletes(this.testList).subscribe(
      result=> {
        console.log(result);
        debugger;
        this._router.navigate(["/althletes-details"]);
      },
      err => {
        console.log(err);
      }
    ); 
  }

}
