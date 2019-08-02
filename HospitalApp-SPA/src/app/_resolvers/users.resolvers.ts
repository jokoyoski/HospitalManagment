import { Injectable } from '@angular/core';

import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';

import { User } from '../../Model/User';
import { PaginatedResult } from '../../Model/pagination';
import { Observable, of } from 'rxjs';
import { UserService } from '../../Services/user.service';
import { AlertifyService } from '../../Services/Alertify.service';
import { catchError } from 'rxjs/operators';

@Injectable()

export class UsersResolvers implements Resolve<PaginatedResult<User[]>> {
pageNumber = 1;
pageSize = 20;

    constructor(private userService: UserService, private router: Router, private alertify: AlertifyService) {}

resolve(route: ActivatedRouteSnapshot): Observable<PaginatedResult<User[]>> {

// tslint:disable-next-line: whitespace

return this.userService.getUsers(this.pageNumber, this.pageSize).pipe(


        catchError(error => {
            this.alertify.error('Problem retrieving data');
            this.router.navigate(['/home']);
            return of(null);
        }


        )
    );
}
}

