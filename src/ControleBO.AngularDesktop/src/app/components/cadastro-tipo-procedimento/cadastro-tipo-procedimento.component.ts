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
    this.submitted = true;
    setTimeout(() => {
      this.messageService.send(new Message('Cadastrado com sucesso!', this.tipoProcedimento));
      this.submitted = false;
      this.modalRef.hide();
    }, 3000);


    //if (this.tipoProcedimento.id) {
    //  this.tipoProcedimentoService.update(this.tipoProcedimento)
    //    .subscribe(res => {
    //      if (res.success) {
    //        this.toastr.success(res.message);
    //      }
    //    },
    //      error => this.toastr.error(error));
    //}
  }
}
