import { Injectable, OnDestroy } from '@angular/core';
import { AuthService } from './auth.service';
import { Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserManagerService implements OnDestroy {

  private subscription: Subscription;

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

  constructor(private authService: AuthService) {
    this.onReceiveMessage();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
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

  private onReceiveMessage() {
    this.authService.messageListener$.subscribe(message => {
      if (message) {
        this._name = message.data.nome;
        this._email = message.data.email;
        this._role = message.data.regra;

        sessionStorage.setItem('__username', this._name);
        sessionStorage.setItem('__userrole', this._role);
      }
    });
  }
}
