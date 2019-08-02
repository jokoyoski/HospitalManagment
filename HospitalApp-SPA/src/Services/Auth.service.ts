import { Injectable } from '@angular/core';

import { User } from '../Model/User';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';


import { UserInfo } from '../Model/UserInfo';
import {JwtHelperService} from '@auth0/angular-jwt';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(private httpClient:HttpClient) { }
  jwtHelper = new JwtHelperService();
  
mainUrl=environment.URl;
  url:string="http://localhost:5000/api/"

  registerUser(model: User) {
  return this.httpClient.post( 'http://localhost:5000/api/Auth/RegisterUser', model);
  }
  
  login(model: any)
  {
      return this.httpClient.post('http://localhost:5000/api/Auth/Login', model).pipe(
         map((response: UserInfo) => {

     localStorage.setItem('token', response.token);
       const decodedToken = this.jwtHelper.decodeToken(response.token);

       localStorage.setItem('userId', decodedToken.nameid);
       localStorage.setItem('userName', decodedToken.unique_name);


         })
      );
  }
  
  
  loggedIn(): boolean {
      const token=localStorage.getItem('token');
    
      const result=this.jwtHelper.isTokenExpired(token);
      console.log(result);
      return result;
  }
  
}
