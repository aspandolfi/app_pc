import { Component, OnInit } from '@angular/core';
import { TipoProcedimento } from 'src/app/models/tipo-procedimento';
import { TipoProcedimentoService } from 'src/app/services/tipo-procedimento.service';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { MessageService } from 'src/app/services/message.service';
import { Message } from 'src/app/models/message';

@Component({
  selector: 'app-cadastro-tipo-procedimento',
  templateUrl: './cadastro-tipo-procedimento.component.html',
  styleUrls: ['./cadastro-tipo-procedimento.component.css']
})
export class CadastroTipoProcedimentoComponent implements OnInit {

  tipoProcedimento: TipoProcedimento;

  submitted = false;

  constructor(public modalRef: BsModalRef, private tipoProcedimentoService: TipoProcedimentoService, private messageService: MessageService) { }

  ngOnInit() {

  }

  save() {
    if (this.tipoProcedimento.id) {
      this.tipoProcedimentoService.update(this.tipoProcedimento)
        .subscribe(res => {
          this.messageService.send(new Message(res.message, res.data));
        }, error => {
          this.messageService.send(new Message(error.message, error, true));
        }, () => {
          this.submitted = false;
          this.modalRef.hide();
        });
    }
    else {
      this.tipoProcedimentoService.create(this.tipoProcedimento)
        .subscribe(res => {
          this.messageService.send(new Message(res.message, res.data));
        }, error => {
          this.messageService.send(new Message(error.message, error, true));
        }, () => {
          this.submitted = false;
          this.modalRef.hide();
        });
    }
  }
}
