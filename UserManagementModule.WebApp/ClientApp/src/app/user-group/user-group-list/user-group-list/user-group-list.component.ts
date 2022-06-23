import { AfterViewInit, Component, ViewChild, OnInit, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserManagementService } from '../../../core/service/user-management-service';
import { UserGroup } from '../../../core/model/user-group';
import { Subscription } from 'rxjs';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UserGroupEditComponent } from '../../user-group-edit/user-group-edit/user-group-edit.component';
import { ConfirmDialogModel } from '../../../core/model/confirmation-dialog-model';
import { ConfirmationDialogComponent } from '../../../core/lib/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-user-group-list',
  templateUrl: './user-group-list.component.html',
  styleUrls: ['./user-group-list.component.css']
})


export class UserGroupListComponent implements OnInit, OnDestroy {

  userGroupSearchSubscription: Subscription = new Subscription();
  userGroupDeleteSubscription: Subscription = new Subscription();

  displayedColumns: string[] = ['userGroupId', 'groupName', 'createdDate', 'createdBy', 'modifiedDate', 'modifiedBy', 'action'];
  dataSource: MatTableDataSource<UserGroup> = new MatTableDataSource();

  @ViewChild(MatSort) sort: MatSort;

  constructor(private userManagementService: UserManagementService,
    public dialog: MatDialog) { }

  ngOnInit(): void {

    this.getUserGroupList();
  }

  ngAfterViewInit() {
  }

  getUserGroupList() {

    this.userGroupSearchSubscription = this.userManagementService.getUserGroups()
      .subscribe(
        (response) => {                           //next() callback
          console.log('response received' + response);

          this.dataSource = new MatTableDataSource(response);

        },
        (error) => {                              //error() callback
          console.error('Request failed with error' + error)
        },
        () => {                                   //complete() callback
          console.error('Request completed');
        });
  }

  onEdit(userGroup: UserGroup) {

    this.dialog.open(UserGroupEditComponent, {
      data: {
        data: userGroup,
      },
    });
  }

  onDelete(userGroup: UserGroup) {

    const message = `Are you sure you want remove?`;

    const dialogData = new ConfirmDialogModel("Confirm", message);

    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      maxWidth: "400px",
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {

      // when click on ok button
      if (dialogResult) { 

        this.userGroupSearchSubscription = this.userManagementService.deleteUserGroup(userGroup)
          .subscribe(
            (response) => {                           //next() callback
              console.log('response received' + response);

              this.getUserGroupList();

            },
            (error) => {                              //error() callback
              console.error('Request failed with error' + error)
            },
            () => {                                   //complete() callback
              console.error('Request completed');
            });
      }
    });

  }

  ngOnDestroy(): void {
    this.userGroupSearchSubscription.unsubscribe();
  }


}
