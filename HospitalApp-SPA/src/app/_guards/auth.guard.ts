import { Injectable } from '@angular/core';

import { Router, ActivatedRouteSnapshot, CanActivate } from '@angular/router';
import { AuthService } from '../../Services/Auth.service';
import { AlertifyService } from '../../Services/Alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router, private alertify: AlertifyService) {}
  path: import ('@angular/router').ActivatedRouteSnapshot[];
  route: import ('@angular/router').ActivatedRouteSnapshot;

  canActivate( next: ActivatedRouteSnapshot

): boolean {
 
  if (!this.authService.loggedIn()) {
    return true;
  }
  this.alertify.warning('You shall not Pass !!!');
  this.router.navigate(['/login']);  // navigate to home
  return false;
}}


// tslint:disable-next-line: max-line-length
// this is the guard that was created when user needs to login, it was created and imported through app.module.ts and was used in the routes;
