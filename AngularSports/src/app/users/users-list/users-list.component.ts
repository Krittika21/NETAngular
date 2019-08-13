import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/user.model';
import { UserDetailsService } from 'src/app/shared/user-details.service';
import { Router } from '@angular/router';

export enum TypeOfUsers
{
    Coach,
    Athlete
}
@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {
  //modes = FormAction;
  id:number;
  name:string;
  users: Array<User>;
  userType: any;

  constructor(private userDetailsService: UserDetailsService, private _router: Router) { }

 
  ngOnInit() {
    this.userDetailsService.getAthletes().subscribe(
      (result: Array<User>) => {
        console.log("result");
        this.users = result;
        console.log(this.users);
        debugger;
      },
      err => {
        console.log(err);
      }
    );
  }
  forNewUser()
  {
    this._router.navigate(["/new-users"])
  }
}
