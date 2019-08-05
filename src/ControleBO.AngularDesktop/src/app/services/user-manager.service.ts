import { Injectable, OnDestroy } from '@angular/core';
import { AuthService } from './auth.service';
import { Usuario } from '../models/usuario';
import { Login } from '../models/login';
import { Router } from '@angular/router';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class UserManagerService implements OnDestroy {

  /* ms  * s  * min = 5 min */
  private readonly timeToRefresh: number = 1000 * 60;
  private readonly timeToRefreshToken: number = 1000 * 60 * 60;

  private intervalId: any;
  private intervalTokenId: any;

  private _name: string;
  private _role: string;
  private _email: string;

  get name(): string {
    if (this._name) {
      return this._name;
    }

    let name = sessionStorage.getItem('__username');

    return name;
  }
  get role(): string {
    if (this.role) {
      return this._role;
    }

    let role = sessionStorage.getItem('__userrole');

    return role;
  }
  get email(): string {
    return this._email;
  }

  private readonly roles: string[] = [
    'Admin',
    'User',
    'Viewer',
    'SuperUser'
  ];

  constructor(private authService: AuthService,
    private authentication: AuthenticationService,
    private router: Router) {
  }

  ngOnDestroy(): void {
    clearInterval(this.intervalId);
    clearInterval(this.intervalTokenId);
    this.dispose();
  }

  isAdmin() {
    return this._role === this.roles[0] || this._role === this.roles[3];
  }

  isUser() {
    return this._role === this.roles[1];
  }

  isViewer() {
    return this._role === this.roles[2];
  }

  isInRole(role: string) {
    return this.roles.find(x => x.includes(role));
  }

  canEdit() {
    return this.isAdmin() || this.isUser();
  }

  refreshUserByTime(user?: Usuario, refreshNow?: boolean) {

    // O método é chamado no loginComponent e no AppComponent (caso reload na página)
    if (this.authentication.isValidToken && !this.intervalId) {
      if (user) {
        this.setUser(user);
      }

      if (refreshNow) {
        this.authService.getCurrent().subscribe(res => {
          if (res) {
            this.setUser(res.data);
          }
        });
      }

      this.intervalId = setInterval(() => {
        this.authService.getCurrent().subscribe(res => {
          if (res) {
            this.setUser(res.data);
          }
        })
      }, this.timeToRefresh);
    }
  }

  refreshUserTokenByTime(refreshNow?: boolean) {

    // O método é chamado no loginComponent e no AppComponent (caso reload na página)
    if (this.authentication.isValidToken && !this.intervalTokenId) {

      if (refreshNow) {
        this.authService.refresh().subscribe(res => {
          if (res.data) {
            localStorage.setItem('access_token', JSON.stringify(res.data));
          }
        });
      }

      this.intervalTokenId = setInterval(() => {
        this.authService.getCurrent().subscribe(res => {
          if (res.data) {
            localStorage.setItem('access_token', JSON.stringify(res.data));
          }
        })
      }, this.timeToRefreshToken);
    }
  }

  logOut() {
    this.authService.logOut();
    this.ngOnDestroy();
    this.navigateToHome();
  }

  login(login: Login) {
    return this.authService.login(login);
  }

  private navigateToHome() {
    if (this.router.url.includes('procedimentos')) {
      window.location.reload()
    }
    else {
      this.router.navigate(['home']);
    }
  }

  private setUser(user: Usuario) {
    this._name = user.nome;
    this._email = user.email;
    this._role = user.regra;

    sessionStorage.setItem('__username', this._name);
    sessionStorage.setItem('__userrole', this._role);
  }

  private dispose() {
    this._name = null;
    this._email = null;
    this._role = null;
    this.intervalId = null;
    sessionStorage.removeItem('__username');
    sessionStorage.removeItem('__userrole');
  }
}
