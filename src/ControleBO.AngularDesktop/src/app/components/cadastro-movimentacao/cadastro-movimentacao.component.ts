import { Component, OnInit } from '@angular/core';
import { Movimentacao } from 'src/app/models/movimentacao';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { MovimentacaoService } from 'src/app/services/movimentacao.service';
import { MessageService } from 'src/app/services/message.service';
import { Message, Action } from 'src/app/models/message';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker/public_api';

@Component({
  selector: 'app-cadastro-movimentacao',
  templateUrl: './cadastro-movimentacao.component.html',
  styleUrls: ['./cadastro-movimentacao.component.scss']
})
export class CadastroMovimentacaoComponent implements OnInit {

  bsConfig: Partial<BsDatepickerConfig> = { containerClass: 'theme-default' };

  model: Movimentacao;

  submitted = false;

  get isNovoProcedimento() {
    return this.model.procedimentoId ? false : true;
  }

  constructor(public modalRef: BsModalRef,
    private movimentacaoService: MovimentacaoService,
    private messageService: MessageService) { }

  ngOnInit() {
  }

  save() {
    this.submitted = true;

    if (this.model.procedimentoId) {
      if (this.model.id) {
        this.movimentacaoService.update(this.model)
          .subscribe(res => {
            this.messageService.send(new Message(res, Action.Updated));
          }, error => {
            this.messageService.send(new Message(error));
          }, () => this.modalRef.hide())
          .add(() => this.submitted = false);
      }
      else {
        this.movimentacaoService.create(this.model)
          .subscribe(res => {
            this.messageService.send(new Message(res, Action.Created));
          }, error => {
            this.messageService.send(new Message(error));
          }, () => this.modalRef.hide())
          .add(() => this.submitted = false);
      }
    }
    else {
      this.messageService.send(new Message({
        data: this.model,
        message: 'A movimentação foi inserida e está pendente para ser cadastrada.',
        errors: null,
        success: true
      }, Action.Created));
      setTimeout(() => {
        this.submitted = false;
        this.modalRef.hide();
      }, 300);
    }
  }

}
