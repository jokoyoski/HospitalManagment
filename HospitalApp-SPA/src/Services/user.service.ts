import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../Model/User';
import { PaginatedResult } from '../Model/pagination';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient:HttpClient) { }



  

getUsers(page?, itemsPerPage?, userParams? ): Observable<PaginatedResult<User[]>> {

  const paginatedResult: PaginatedResult<User[]> = new PaginatedResult();
  let params = new HttpParams();
  if (page != null && itemsPerPage != null) {
params = params.append('PageNumber', page);
params = params.append('PageSize', itemsPerPage);
  }
 
  console.log(params);

  

  return this.httpClient.get<User[]>('http://localhost:5000/api/users/GetuserList', {observe: 'response', params}).pipe(map(

  response => {
  
    paginatedResult.result = response.body;
    console.log(paginatedResult.result);
    if (response.headers.get('Pagination') != null) {
console.log( JSON.parse(response.headers.get('Pagination')));
paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
    }
    return paginatedResult;
  }

  ));
}
}
