import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestDetailsListComponent } from './test-details-list/test-details-list.component';
import { NewTestComponent } from './new-test/new-test.component';
import { AthleteDetailsComponent } from './athlete-details/athlete-details.component';

@NgModule({
  declarations: [
    AppComponent,
    TestDetailsListComponent,
    NewTestComponent,
    AthleteDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
