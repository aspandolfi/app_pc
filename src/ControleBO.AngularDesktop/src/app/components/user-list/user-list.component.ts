import { Component, OnInit, OnDestroy } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { MessageService } from '../../services/message.service';
import { IMessage, Action } from '../../models/message';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { Usuario } from '../../models/usuario';
import { UserRegisterComponent } from '../user-register/user-register.component';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit, OnDestroy {

  private modalRef: BsModalRef;
  private subscription: Subscription;

  private usuarios: Usuario[] = [];

  constructor(private modalService: BsModalService,
    private toastr: ToastrService,
    private messageService: MessageService,
    private authService: AuthService) {
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.getUsuarios();
  }

  private getUsuarios() {
    this.authService.getAll().subscribe(res => {
      if (res.data) {
        this.usuarios = res.data;
      }
    },
      () => this.toastr.error('Falha ao buscar os usuários'));
  }

  private onReceiveMessage() {
    this.subscription = this.messageService.messageListener$.subscribe(
      message => {
        if (!message.isError) {
          this.toastr.success(message.text);
          this.postReceiveMessage(message);
        }
        else {
          this.toastr.error(message.text);
        }
        this.modalRef.hide();
      });
  }

  private postReceiveMessage(message: IMessage) {
    if (message.action == Action.Created) {
      this.addToTable(message.data);
    }
    else if (message.action == Action.Removed) {
      this.removeFromTable(message.data);
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private addToTable(usuario: Usuario) {
    this.usuarios.push(usuario);
  }

  private removeFromTable(usuario: Usuario) {
    let index = this.usuarios.indexOf(usuario);
    this.usuarios.splice(index, 1);
  }

  private openModal(usuario: Usuario) {
    const initialState = {
      usuario: usuario == undefined ? new Usuario() : usuario
    };
    this.modalRef = this.modalService.show(UserRegisterComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  private openModalExcluir(usuario: Usuario) {
    const initialState = {
      model: usuario,
      uri: 'api/account/',
      propertyToDescribe: 'nome'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

}
