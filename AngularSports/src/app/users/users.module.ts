import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersListComponent } from './users-list/users-list.component';
import { FormsModule } from '@angular/forms';
import { NewUsersComponent } from './new-users/new-users.component';



@NgModule({
  declarations: [
    UsersListComponent,
     NewUsersComponent
    ],
  imports: [
    CommonModule,
    FormsModule,
  ],
  exports: [ UsersListComponent ]
})
export class UsersModule { }
