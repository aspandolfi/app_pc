import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import * as $ from 'jquery';
import { ToastrService } from 'ngx-toastr';
import { Login } from '../../models/login';
import { Result } from '../../models/result';
import { Router } from '@angular/router';
import { UserManagerService } from '../../services/user-manager.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  login: Login = { email: localStorage.getItem('___rememberme'), password: '', rememberMe: false };
  message: string = '';

  submitted: boolean = false;

  constructor(public modalRef: BsModalRef,
    private userManager: UserManagerService,
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit() {
    $('body').addClass('bg-dark');
    $('#wrapper').css('display', 'none');
    $('app-sidebar').hide();
  }

  onKeyEnter(event: any) {
    this.doLogin();
  }

  doLogin() {

    this.message = '';

    if (!this.login.email) {
      this.message = 'O e-mail é obrigatório.';
      return;
    }

    if (!this.login.password) {
      this.message = 'A senha é obrigatória.';
      return;
    }

    if (this.login.rememberMe) {
      localStorage.setItem('___rememberme', this.login.email);
    }

    this.submitted = true;

    this.userManager.login(this.login).subscribe(res => {
      if (res.success) {
        localStorage.setItem('access_token', JSON.stringify(res.data));

        this.userManager.refreshUserByTime(null, true);
        this.userManager.refreshUserTokenByTime();

        $('body').removeClass('bg-dark');
        $('#wrapper').css('display', '');
        $('app-sidebar').show();

        this.modalRef.hide();
        this.router.navigate(['home']);
      }
    }, (err: Result<any>) => {
      this.message = err.message;
      if (err.errors) {
        err.errors.forEach(m => this.toastr.error(m));
      }
      this.submitted = false;
    }, () => this.submitted = false);
  }
}
