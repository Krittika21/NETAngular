import { Component, OnInit } from '@angular/core';
import { UserDetails, TypeOfUsers } from 'src/app/shared/user-details.model';
import { UserDetailsService } from 'src/app/shared/user-details.service';
import { Router } from '@angular/router';
import { User } from 'src/app/shared/user.model';

@Component({
  selector: 'app-new-users',
  templateUrl: './new-users.component.html',
  styleUrls: ['./new-users.component.css']
})
export class NewUsersComponent implements OnInit {
  id: number;
  Name: string;
  userType: Array<UserDetails>;
  users: any;
  newUser:UserDetails = new UserDetails();
  isAvailable: boolean;
  
  UserTypeE: any[] = [
    {
      key: TypeOfUsers.Coach, value: 'Coach'
    },
    {
      key: TypeOfUsers.Athlete, value: 'Athlete'
    },
    
  ];

  constructor(private userDetailsService: UserDetailsService, private _router : Router) 
  {
    this.isAvailable = false;
  }

  ngOnInit() {
    this.users=
    {
      id:0,
      Name:null,
      userType: null,
    }

    this.userDetailsService.GetUsers().subscribe(
      result =>
      {
        this.users =result as TypeOfUsers[];
        this.users.forEach((user: { userType: any; }) => {
          user.userType = this.UserTypeE.filter(t => t.key == user.userType)[0].value;
        });
        console.log("result");
        this.userType = result as Array<UserDetails>;
        console.log(this.userType);
        this.isAvailable = true;
      },
      err =>
      {
        console.log("err");
      }
    );
  }

  onSubmit()
  {
    debugger;
    this.userDetailsService.postUsers(this.newUser).subscribe(
      result => {
        this.users =result as TypeOfUsers[];
        this.users.forEach(user => {
          user.userType = this.UserTypeE.filter(t => t.key == user.userType)[0].value;
        });
        this.userType = this.users.filter(t => t.id = this.id);
        console.log(result);
        this._router.navigate(["/users-list"]);
      },
      err => {
        console.log(err);
        debugger;
      }
    );
    debugger;
  }

}
