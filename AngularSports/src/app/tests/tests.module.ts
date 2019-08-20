import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestDetailsListComponent } from './test-details-list/test-details-list.component';
import { NewTestComponent } from './new-test/new-test.component';
import { NewAthleteComponent } from './new-athlete/new-athlete.component';
import { EditAthleteComponent } from './edit-athlete/edit-athlete.component';
import { AthleteDetailsComponent } from './athlete-details/athlete-details.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../app-routing.module';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    TestDetailsListComponent, 
    NewTestComponent, 
    NewAthleteComponent, 
    EditAthleteComponent, 
    AthleteDetailsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  exports: [ TestDetailsListComponent ]
})
export class TestsModule { }
