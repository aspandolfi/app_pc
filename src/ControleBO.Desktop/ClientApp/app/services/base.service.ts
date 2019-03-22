import { Injectable, Inject } from '@angular/core';
import { ResponseModel } from '../models/responseModel';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

export interface ApiUrl {
    apiUrl: string;
}

@Injectable()
export class BaseService {

    private apiUrl: string = '';

    constructor(private http: HttpClient, @Inject('BASE_URL') private localUrl: string) {
        this.getBaseUrl();
    }

    private getBaseUrl() {
        this.http.get<ApiUrl>(this.localUrl + 'api/configuration')
            .subscribe(res => this.apiUrl = res.apiUrl,
                error => console.log(error));
    }

    public get<T>(uri: string): Observable<ResponseModel<T>> {
        return this.http.get<ResponseModel<T>>(uri);
    }

    public post<T>(uri: string, data: T): Observable<ResponseModel<T>> {
        return this.http.post<ResponseModel<T>>(uri, data);
    }

    public put<T>(uri: string, data: T): Observable<ResponseModel<T>> {
        return this.http.put<ResponseModel<T>>(uri, data);
    }

    public delete(uri: string): Observable<ResponseModel<any>> {
        return this.http.delete<ResponseModel<any>>(uri);
    }
}