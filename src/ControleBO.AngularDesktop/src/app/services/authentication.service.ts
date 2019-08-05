import { Injectable } from '@angular/core';
import { Authentication } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private _authentication: Authentication = new Authentication();

  get authentication() {

    let item = localStorage.getItem('access_token');
    if (item) {
      this._authentication = new Authentication(JSON.parse(item));
    }
    else {
      this._authentication = new Authentication();
    }

    return this._authentication;
  }

  get isValidToken() {
    return this.authentication.expiration > new Date().setHours(23, 59);
  }

  constructor() {
  }
}
