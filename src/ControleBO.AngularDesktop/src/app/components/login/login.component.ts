import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import * as $ from 'jquery';
import { ToastrService } from 'ngx-toastr';
import { Login } from '../../models/login';
import { AuthService } from '../../services/auth.service';
import { MessageService } from '../../services/message.service';
import { Message } from '../../models/message';
import { Result } from '../../models/result';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private login: Login = { email: '', password: '', rememberMe: false };
  private message: string = '';

  private submitted: boolean = false;

  constructor(public modalRef: BsModalRef,
    private authService: AuthService,
    private messageService: MessageService,
    private toastr: ToastrService) { }

  ngOnInit() {
    $('body').addClass('bg-dark');
    $('app-sidebar').hide();
  }

  private doLogin() {

    this.message = '';

    if (!this.login.email) {
      this.message = 'O e-mail é obrigatório.';
      return;
    }

    if (!this.login.password) {
      this.message = 'A senha é obrigatória.';
      return;
    }

    this.submitted = true;

    this.authService.login(this.login).subscribe(res => {
      if (res.success) {
        localStorage.setItem('access_token', JSON.stringify(res.data));
        this.messageService.send(new Message(res));
        $('body').removeClass('bg-dark');
        $('app-sidebar').show();
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
