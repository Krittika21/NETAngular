import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TestDetailsService } from '../shared/test-details.service';
import { TestDetails } from '../shared/test-details.model';
import { User } from '../shared/user.model';

@Component({
  selector: 'app-athlete-details',
  templateUrl: './athlete-details.component.html',
  styleUrls: ['./athlete-details.component.css']
})
export class AthleteDetailsComponent implements OnInit {
  test: TestDetails | undefined;
  currentTestId: number;
  details: Array<User>;
  athletes: Array<AthleteDetailsComponent>;

  constructor(private testDetailsService:TestDetailsService, private _router:Router, private router: ActivatedRoute) { }
  
  forNewAthlete(): void{
    this._router.navigate(["/add-athlete"])
  }
  toDeleteTest()
  {
    this._router.navigate(["/test-details"])
  }
  GetAthletes(): void{
    //this.test
  }

  ngOnInit() {
    this.currentTestId = +this.router.snapshot.paramMap.get('id');
    console.log(this.currentTestId);   
  }
}