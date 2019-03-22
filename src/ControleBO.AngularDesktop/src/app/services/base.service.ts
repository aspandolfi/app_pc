import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result } from '../models/result';

export interface ApiUrl {
  apiUrl: string;
}

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  private apiUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private localUrl: string) { }

  private getBaseUrl() {
    this.http.get<ApiUrl>(`${this.localUrl}api/configuration`)
      .subscribe(res => this.apiUrl = res.apiUrl,
        error => console.log(error));
  }

  public get<T>(uri: string): Observable<Result<T>> {
    return this.http.get<Result<T>>(uri);
  }

  public post<T>(uri: string, data: T): Observable<Result<T>> {
    return this.http.post<Result<T>>(uri, data);
  }

  public put<T>(uri: string, data: T): Observable<Result<T>> {
    return this.http.put<Result<T>>(uri, data);
  }

  public delete(uri: string): Observable<Result<any>> {
    return this.http.delete<Result<any>>(uri);
  }
}
