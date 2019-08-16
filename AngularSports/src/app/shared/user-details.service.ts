import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from './user.model';
import { UserTypeMap } from './user-type-map.model';
import { UserDetails } from './user-details.model';
import { TestTypeMap } from './test-type-map.model';
import { config } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserDetailsService {
  URL : string="http://localhost:53629/api";
  currentUserId: number;
  
  constructor( private _http:HttpClient) { }



//ATHLETES
getAthletes()
{
  return this._http.get(this.URL + "/Users/GetAthletes")
}
postAthletes(body: UserTypeMap)
{
  return this._http.post(this.URL + "/Users/postAthletes/:TestId",body)
}

//USERS
GetUsers()
{
  return this._http.get(this.URL + "/Users/GetUsers")
}
postUsers(body:UserDetails)
{
  return this._http.post(this.URL + "/Users/postUsers", body)
}

} 
