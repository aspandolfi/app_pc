import { Component, OnInit } from '@angular/core';
import { TipoSituacao } from '../../models/tipo-situacao';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { TipoSiutacaoService } from '../../services/tipo-siutacao.service';
import { MessageService } from '../../services/message.service';
import { ToastrService } from 'ngx-toastr';
import { Message, Action } from '../../models/message';
import { Result } from '../../models/result';
import { UserManagerService } from '../../services/user-manager.service';

@Component({
  selector: 'app-cadastro-tipo-situacao',
  templateUrl: './cadastro-tipo-situacao.component.html',
  styleUrls: ['./cadastro-tipo-situacao.component.scss']
})
export class CadastroTipoSituacaoComponent implements OnInit {

  tipoSituacao: TipoSituacao;

  submitted = false;

  get canEdit() {
    return this.userManager.canEdit();
  }

  constructor(public modalRef: BsModalRef,
    private tipoSituacaoService: TipoSiutacaoService,
    private messageService: MessageService,
    private toastr: ToastrService,
    private userManager: UserManagerService) { }

  ngOnInit() {
  }

  save() {
    this.submitted = true;

    if (this.tipoSituacao.id) {
      this.tipoSituacaoService.update(this.tipoSituacao)
        .subscribe(res => {
          this.messageService.send(new Message(res, Action.Updated));
          this.modalRef.hide();
        }, (error: Result<any>) => {
          if (error.errors) {
            error.errors.forEach(m => this.toastr.warning(m));
          }
          this.submitted = false;
          this.toastr.error(error.message);
        }, () => {
          this.submitted = false;
        });
    }
    else {
      this.tipoSituacaoService.create(this.tipoSituacao)
        .subscribe(res => {
          this.messageService.send(new Message(res, Action.Created));
          this.modalRef.hide();
        }, (error: Result<any>) => {
          if (error.errors) {
            error.errors.forEach(m => this.toastr.warning(m));
          }
          this.submitted = false;
          this.toastr.error(error.message);
        }, () => {
          this.submitted = false;
        });
    }
  }

}
