import { Component, OnInit, AfterViewInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AuthService } from '../../services/auth.service';
import { MessageService } from '../../services/message.service';
import { ToastrService } from 'ngx-toastr';
import { RegisterUsuario } from '../../models/usuario';
import { Result } from '../../models/result';
import { Message, Action } from '../../models/message';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit, AfterViewInit {

  submitted: boolean = false;
  isCollapsed: boolean = false;

  usuario: RegisterUsuario = new RegisterUsuario();

  constructor(public modalRef: BsModalRef,
    private authService: AuthService,
    private messageService: MessageService,
    private toastr: ToastrService) { }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
    if (this.usuario.id) {
      this.isCollapsed = true
    }
  }

  salvar() {
    this.submitted = true;

    if (this.usuario.id) {
      this.authService.update(this.usuario).subscribe(res => {
        if (res.success) {
          this.messageService.send(new Message(res, Action.Updated));
        }
      }, (err: Result<any>) => {
        this.toastr.error(err.message);
        if (err.errors) {
          err.errors.forEach(m => this.toastr.error(m));
        }
        this.submitted = false;
      }, () => this.submitted = false);
    }
    else {
      this.authService.create(this.usuario).subscribe(res => {
        if (res.success) {
          this.messageService.send(new Message(res, Action.Created));
        }
      }, (err: Result<any>) => {
        this.toastr.error(err.message);
        if (err.errors) {
          err.errors.forEach(m => this.toastr.error(m));
        }
        this.submitted = false;
      }, () => this.submitted = false);
    }
  }

  onChangeAlterarSenha(event: any) {
    this.isCollapsed = !event.target.checked;
  }

}
