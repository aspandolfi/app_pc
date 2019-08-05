import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Result } from '../models/result';
import { FileService } from './file.service';
import { retry, catchError } from 'rxjs/operators';
import { AuthenticationService } from './authentication.service';
import { ApiConfiguration } from '../api-configuration';

export interface ApiUrl {
  apiUrl: string;
}

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  get apiUrl(): string {
    return ApiConfiguration.ApiUrl;
  }

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private localUrl: string,
    private fileService: FileService,
    private authentication: AuthenticationService) {
    this.getBaseUrl();
  }

  public getHttpHeaders() {
    const headers: HttpHeaders = new HttpHeaders();
    const auth = this.authentication;
    if (auth) {
      const token = auth.authentication.token;
      return headers.set('Authorization', `Bearer ${token}`);
    }
  }

  private getBaseUrl() {
    //ApiConfiguration.ApiUrl = this.fileService.getConfig().apiUrl
    //this.apiUrl = ;
    //this.apiUrl = "";
  }

  public get<T>(uri: string): Observable<Result<T>> {
    return this.http.get<Result<T>>(this.apiUrl + uri, { headers: this.getHttpHeaders() })
      .pipe(retry(2), catchError(this.handleError));
  }

  public post<T>(uri: string, data: T): Observable<Result<T>> {
    return this.http.post<Result<T>>(this.apiUrl + uri, data, { headers: this.getHttpHeaders() })
      .pipe(catchError(this.handleError));
  }

  public put<T>(uri: string, data: T): Observable<Result<T>> {
    return this.http.put<Result<T>>(this.apiUrl + uri, data, { headers: this.getHttpHeaders() })
      .pipe(catchError(this.handleError));
  }

  public delete(uri: string): Observable<Result<any>> {
    return this.http.delete<Result<any>>(this.apiUrl + uri, { headers: this.getHttpHeaders() })
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse): Observable<Result<any>> {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      //console.error(
      //  `Backend returned code ${error.status}, ` +
      //  `body was: ${error.error}`);
      //console.log(error.error);
    }
    // return an observable with a user-facing error message

    // Erro de domínio
    if (error.status === 400) {
      return throwError(
        error.error);
    }

    if (error.status === 403) {
      return throwError(
        { message: 'Você não tem autorização para executar essa operação.' });
    }

    if (error.status === 404) {
      return throwError(
        { message: 'Falha ao se comunicar com o servidor. Por favor contate o administrador do sistema.' });
    }

    if (error.status === 500) {
      return throwError(
        { message: 'Erro interno do servidor. Por favor contate o administrador do sistema.' });
    }

    return throwError(
      error);
  };
}
