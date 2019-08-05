import { Injectable, OnDestroy } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, CanActivateChild, CanLoad, Route, UrlSegment } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { LoginComponent } from '../components/login/login.component';
import { AuthenticationService } from '../services/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate, CanActivateChild, CanLoad, OnDestroy {

  private modalRef: BsModalRef;
  //private subscription: Subscription;

  private state: RouterStateSnapshot;

  constructor(private router: Router,
    private modalService: BsModalService,
    private authentication: AuthenticationService) {
    //this.onReceiveMessage();
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (!this.authentication.isValidToken) {
      this.state = state;
      this.openModal();
    }

    return this.authentication.isValidToken;
  }

  canActivateChild(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.authentication.isValidToken;
  }

  canLoad(route: Route, segments: UrlSegment[]) {
    return this.authentication.isValidToken;
  }

  ngOnDestroy(): void {
    //this.subscription.unsubscribe();
  }

  private openModal() {
    this.modalRef = this.modalService.show(LoginComponent, { class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  //private onReceiveMessage() {
  //  this.subscription = this.authentication.messageListener$.subscribe(
  //    message => {
  //      if (message.data.authenticated) {
  //        this.modalRef.hide();
  //        this.router.navigate([this.state.url]);
  //      }
  //    });
  //}
}
