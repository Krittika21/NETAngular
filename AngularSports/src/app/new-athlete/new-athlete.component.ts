import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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


  constructor(private userDetailsService: UserDetailsService, private _router: Router) 
  {
    this.isAvailable = false;
  }
  
  ngOnInit() {
    this.athletes =
    {
      AName:null,
      CTDistance: 0,
      STTime: 0,
      fitnessRating: null
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
      result=> {
        console.log(result);
        this._router.navigate(["/athlete-details/:id"]);
      },
      err => {
        console.log(err);
      }
    );
  }

}
