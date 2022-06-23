import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserGroupListComponent } from './user-group-list/user-group-list/user-group-list.component';

const routes: Routes = [
  {
    path: '',
    component: UserGroupListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserGroupRoutingModule { }