import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserGroupListComponent } from './user-group-list/user-group-list/user-group-list.component';
import { UserGroupRoutingModule } from './user-group-routing.module';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { UserGroupEditComponent } from './user-group-edit/user-group-edit/user-group-edit.component';
import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';

@NgModule({
  imports: [
    CommonModule,
    UserGroupRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    MatIconModule,
    MatButtonModule,   
    FormsModule,
    MatInputModule
  ],
  declarations: [UserGroupListComponent, UserGroupEditComponent],
  providers : [
  ]
})
export class UserGroupModule { }
