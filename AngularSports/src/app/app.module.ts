import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }    from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestDetailsListComponent } from './test-details-list/test-details-list.component';
import { NewTestComponent } from './new-test/new-test.component';
import { AthleteDetailsComponent } from './athlete-details/athlete-details.component';
import { NewAthleteComponent } from './new-athlete/new-athlete.component';
import { RouterModule } from '@angular/router';
import { TestDetailsService } from './shared/test-details.service';
import { FormsModule } from '@angular/forms';
import { UsersListComponent } from './users/users-list/users-list.component';
import { UsersModule } from './users/users.module';


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
    HttpClientModule,
    FormsModule,
    UsersModule,
  
    RouterModule.forRoot([
      { path: '', component: TestDetailsListComponent},
      { path: 'test/:testId', component: NewTestComponent},
      { path: 'testType/:testTypeId', component: NewAthleteComponent},
    ])
  ],
  providers: [TestDetailsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
