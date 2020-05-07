import { Injectable } from '@angular/core';
import { authResponse } from './auth-response';
import { TokenService } from './token.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  authresultobj: authResponse;
  baseUrl: string = 'http://localhost/Eduquayapi/';
  loginUrl: string = this.baseUrl + 'api/v1/Identity/Login';
  patientUrl: string = this.baseUrl + 'api/v1/Patient/GetPatients';

  constructor(private httpClient: HttpClient, private tokenService: TokenService) { }

  //Observable<HttpResponse<authresult>>
  userAuthentication(emailInput: string, passwordInput: string): Observable<any> {
    let httpHeaders = new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Headers': 'Origin, X-Requested-With, Content-Type, Accept',
      'Access-Control-Allow-Methods': 'HEAD, GET, POST, PUT, PATCH, DELETE',
      'No-Auth': 'True',
      'Content-Type': 'application/json',
      'Cache-Control': 'no-cache'
    });
    let options = {
      headers: httpHeaders
    };
    let postData = { 'email': emailInput, 'password': passwordInput };

    return this.httpClient.post(this.loginUrl, postData, options);
    // .pipe(
    //   catchError(errorRes => {
    //     let errorMessage = "An unknown error occurred";
    //     if(!errorRes.error || !errorRes.error.error){
    //       return throwError(errorMessage);
    //     }
    //     switch(errorRes.error.error.message){
    //       case 'email':
    //         console.log('error');
    //     }
    //     return throwError(errorMessage);
    //   })
    // );
    //.pipe(retry(3), catchError(this.handleError('userAuthentication', [])));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  private log(message: string) {
    console.log(message);
  }

}
