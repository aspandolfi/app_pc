import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result } from '../models/result';
import { FileService } from './file.service';
import { retry } from 'rxjs/operators';

export interface ApiUrl {
  apiUrl: string;
}

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  public apiUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private localUrl: string, private fileService: FileService) {
    this.getBaseUrl();
  }

  private getBaseUrl() {
    //this.apiUrl = this.fileService.getConfig().apiUrl;
    this.apiUrl = "";
  }

  public get<T>(uri: string): Observable<Result<T>> {
    return this.http.get<Result<T>>(this.apiUrl + uri).pipe(retry(3));
  }

  public post<T>(uri: string, data: T): Observable<Result<T>> {
    return this.http.post<Result<T>>(this.apiUrl + uri, data);
  }

  public put<T>(uri: string, data: T): Observable<Result<T>> {
    return this.http.put<Result<T>>(this.apiUrl + uri, data);
  }

  public delete(uri: string): Observable<Result<any>> {
    return this.http.delete<Result<any>>(this.apiUrl + uri);
  }
}
