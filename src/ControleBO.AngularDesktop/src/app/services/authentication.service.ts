import { Injectable } from '@angular/core';
import { Authentication } from '../models/login';
import { Router } from '@angular/router';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends MessageService {

  private _authentication: Authentication = new Authentication();

  get authentication() {
    if (!this._authentication.token) {
      let item = localStorage.getItem('access_token');
      if (item) {
        this._authentication = new Authentication(JSON.parse(item));
      }
      else {
        this._authentication = new Authentication();
      }
    }
    return this._authentication;
  }

  get isValidToken() {
    return this.authentication.expiration < new Date().setHours(23, 59);
  }

  logOut() {
    if (this._authentication.token) {
      localStorage.removeItem('access_token');
      this._authentication = new Authentication();
      this.navigateToHome();
    }
  }

  private navigateToHome() {
    if (this.router.url.includes('procedimentos')) {
      window.location.reload()
    }
    else {
      this.router.navigate(['home']);
    }
  }

  constructor(private router: Router) {
    super();
  }
}
