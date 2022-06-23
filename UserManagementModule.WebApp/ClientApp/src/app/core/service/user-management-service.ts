
import { Injectable } from '@angular/core';
 
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError} from 'rxjs/operators';
import { UserGroup } from '../model/user-group';
 
@Injectable()
export class UserManagementService {
 
  constructor(private http: HttpClient) {
  }
 
  getUserGroups(): Observable<any> {
    return this.http.get('api/groups');
  }

  deleteUserGroup(userGroup : UserGroup): Observable<any> {
    return this.http.delete('api/groups/'+userGroup.userGroupId);
  }
 
}