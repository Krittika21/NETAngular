import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }    from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestDetailsListComponent } from './tests/test-details-list/test-details-list.component';
import { NewTestComponent } from './tests/new-test/new-test.component';
import { NewAthleteComponent } from './tests/new-athlete/new-athlete.component';
import { RouterModule } from '@angular/router';
import { TestDetailsService } from './shared/test-details.service';
import { FormsModule } from '@angular/forms';
import { UsersModule } from './users/users.module';
import { TestsModule } from './tests/tests.module';


@NgModule({
  declarations: [ AppComponent ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    UsersModule,
    TestsModule,
  
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
