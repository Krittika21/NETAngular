import { Injectable } from '@angular/core';
import { TestDetails } from './test-details.model';
import { TestType } from './test-type.model';
import { TestTypeMap } from './test-type-map.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TestDetailsService {
  URL:string = "http://localhost:53629/api";

  constructor( private _http:HttpClient ) { }

   postTests(body: TestDetails){
     debugger
    return this._http.post(this.URL + '/Main/PostTest', body);
  } 
  getTestType(){
    return this._http.get(this.URL + "/Main/GetTestType")
  }
  getTests()
  {
     return this._http.get(this.URL + "/Main/GetTest");
  }
}
