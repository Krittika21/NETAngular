import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestDetailsListComponent } from './test-details-list/test-details-list.component';
import { NewTestComponent } from './new-test/new-test.component';
import { AthleteDetailsComponent } from './athlete-details/athlete-details.component';
import { NewAthleteComponent } from './new-athlete/new-athlete.component';


const routes: Routes = [
  { path: 'test-details' , component: TestDetailsListComponent},
  { path: 'create-test', component: NewTestComponent},
  { path: 'athlete-details', component:AthleteDetailsComponent},
  { path: 'add-athlete', component:NewAthleteComponent},
  { path: 'add-test', component:TestDetailsListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
