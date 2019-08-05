import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestDetailsListComponent } from './test-details-list/test-details-list.component';
import { NewTestComponent } from './new-test/new-test.component';
import { AthleteDetailsComponent } from './athlete-details/athlete-details.component';
import { NewAthleteComponent } from './new-athlete/new-athlete.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    TestDetailsListComponent,
    NewTestComponent,
    AthleteDetailsComponent,
    NewAthleteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: TestDetailsListComponent},
      { path: 'test/:testId', component: NewTestComponent},
      { path: 'testType/:testTypeId', component: NewAthleteComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
