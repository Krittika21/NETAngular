import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestDetailsListComponent } from './test-details-list/test-details-list.component';
import { NewTestComponent } from './new-test/new-test.component';
import { AthleteDetailsComponent } from './athlete-details/athlete-details.component';
import { NewAthleteComponent } from './new-athlete/new-athlete.component';
import { User } from './shared/user.model';
import { UsersListComponent } from './users/users-list/users-list.component';
import { NewUsersComponent } from './users/new-users/new-users.component';


const routes: Routes = [
  { path: 'test-details' , component: TestDetailsListComponent},
  { path: 'create-test', component: NewTestComponent},
  { path: 'athlete-details/:id', component:AthleteDetailsComponent},
  { path: 'test/:testId/add-athlete', component:NewAthleteComponent},
  { path: 'add-test', component:TestDetailsListComponent},
  { path: 'users-list', component:UsersListComponent},
  { path: 'new-users', component:NewUsersComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
