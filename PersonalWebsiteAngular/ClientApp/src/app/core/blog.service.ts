//import { Injectable } from '@angular/core';
//import { HttpClient } from '@angular/common/http';

//import { Observable } from 'rxjs';
//import { map, catchError } from 'rxjs/operators';
//import { PageInfo } from '../models/pageInfo';

//@Injectable()
//export class BlogService {


//  constructor(private http: HttpClient) { }

//  public search(itemType: string) {
//    return this.http.get<PageInfo>('api/v2/Menu' + '?itemType=' + itemType)
//      .pipe(catchError(this.handleError))
//      .map((serviceResponse: PageInfo) => {
//        return serviceResponse;
//      });
//  }

//  private handleError(error: any) {
//    console.error('server error:', error);
//    if (error.error instanceof Error) {
//      const errMessage = error.error.message;
//      return Observable.throw(errMessage);
//      // Use the following instead if using lite-server
//      // return Observable.throw(err.text() || 'backend server error');
//    }
//    return Observable.throw(error || 'Node.js server error');
//  }
//}
