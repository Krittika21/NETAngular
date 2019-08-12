import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserDetailsService {
  URL : string="http://localhost:53629/api";
  
  constructor( private _http:HttpClient) { }

getAthletes()
{
  return this._http.get(this.URL + "/Users/GetAthletes")
}
 postAthletes(body: User)
{
  return this._http.get(this.URL + "/Users/PostAthletes");
}

} 
