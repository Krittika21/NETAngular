import { Injectable } from '@angular/core';
import { TestDetails } from './test-details.model';
import { TestType } from './test-type.model';
import { TestTypeMap } from './test-type-map.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TestDetailsService {
  testData: TestDetails;
  testData1: TestType;
  testData2:TestTypeMap;
  URL:string = "http://localhost:53629/";

  constructor( private _http:HttpClient ) { }

  getTests()
  {
     return this._http.get(this.URL + "api/Main/GetTest");
  }
}
