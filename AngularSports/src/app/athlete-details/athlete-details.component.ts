import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TestDetailsService } from '../shared/test-details.service';

@Component({
  selector: 'app-athlete-details',
  templateUrl: './athlete-details.component.html',
  styleUrls: ['./athlete-details.component.css']
})
export class AthleteDetailsComponent implements OnInit {
  currentTestId: number;
  constructor(private service:TestDetailsService, private _router:Router) { }
  
  forNewAthlete(): void{
    this._router.navigate(["/add-athlete"])
  }

  ngOnInit() {
    this.currentTestId = this.service.getCurrentTestId();
    
  }

}
