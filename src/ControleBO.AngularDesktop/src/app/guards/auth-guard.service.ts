import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, CanActivateChild, CanLoad, Route, UrlSegment } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { MessageService } from '../services/message.service';
import { LoginComponent } from '../components/login/login.component';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate, CanActivateChild, CanLoad {

  private modalRef: BsModalRef;
  private subscription: Subscription;

  private state: RouterStateSnapshot;

  constructor(private router: Router,
    private modalService: BsModalService,
    private messageService: MessageService) {
    this.onReceiveMessage();
  }

  private isAuthenticated: boolean = false;

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (!this.isAuthenticated) {
      this.state = state;
      this.openModal();
    }

    return this.isAuthenticated;
  }

  canActivateChild(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.isAuthenticated;
  }

  canLoad(route: Route, segments: UrlSegment[]) {
    return this.isAuthenticated;
  }

  private openModal() {
    this.modalRef = this.modalService.show(LoginComponent, { class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  private onReceiveMessage() {
    this.subscription = this.messageService.messageListener$.subscribe(
      message => {
        if (message.data.authenticated) {
          this.isAuthenticated = true;
          this.modalRef.hide();
          this.subscription.unsubscribe();
          this.router.navigate([this.state.url]);
        }
      });
  }
}
