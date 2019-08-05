import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestDetailsListComponent } from './test-details-list/test-details-list.component';
import { NewTestComponent } from './new-test/new-test.component';


const routes: Routes = [
  { path: 'test-details' , component: TestDetailsListComponent},
  { path: 'create test', component: NewTestComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
