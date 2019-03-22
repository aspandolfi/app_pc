import { Component, OnInit, TemplateRef, OnDestroy } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { CadastroTipoProcedimentoComponent } from '../cadastro-tipo-procedimento/cadastro-tipo-procedimento.component';
import { TipoProcedimento } from 'src/app/models/tipo-procedimento';
import { ToastrService } from 'ngx-toastr';
import { MessageService } from 'src/app/services/message.service';
import { Subscription } from 'rxjs';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { IMessage } from 'src/app/models/message';

@Component({
  selector: 'app-tipo-procedimento',
  templateUrl: './tipo-procedimento.component.html',
  styleUrls: ['./tipo-procedimento.component.css']
})
export class TipoProcedimentoComponent implements OnInit, OnDestroy {

  modalRef: BsModalRef;
  subscription: Subscription;

  tipos: TipoProcedimento[] = [
    { id: 1, sigla: 'TNE', descricao: 'Descrição 1' },
    { id: 2, sigla: 'TNE 2', descricao: 'Descrição 2' },
    { id: 3, sigla: 'TNE 3', descricao: 'Descrição 3' },
    { id: 4, sigla: 'TNE 4', descricao: 'Descrição 4' },
    { id: 5, sigla: 'TNE 5', descricao: 'Descrição 5' }
  ]

  constructor(private modalService: BsModalService,
    private toastr: ToastrService,
    private messageService: MessageService) {
    this.onListen();
  }

  ngOnInit() {

  }

  onListen() {
    this.subscription = this.messageService.messageListener$.subscribe(
      message => {
        if (!message.isError) {
          this.toastr.success(message.text);
          this.onReceiveMessage(message);
        }
        else {
          this.toastr.error(message.text);
        }
        this.modalRef.hide();
      });
  }

  onReceiveMessage(message: IMessage) {
    if (message.text.includes('Cadastrado')) {
      this.addToTable(message.data);
    }
    else {
      this.removeFromTable(message.data);
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  addToTable(tipoProcedimento: TipoProcedimento) {
    this.tipos.push(tipoProcedimento);
  }

  removeFromTable(tipoProcedimento: TipoProcedimento) {
    let index = this.tipos.indexOf(tipoProcedimento);
    this.tipos.splice(index, 1);
  }

  openModal(tipoProcedimento: TipoProcedimento) {
    const initialState = {
      tipoProcedimento: tipoProcedimento == undefined ? new TipoProcedimento() : tipoProcedimento
    };
    this.modalRef = this.modalService.show(CadastroTipoProcedimentoComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  openModalExcluir(tipoProcedimento: TipoProcedimento) {
    const initialState = {
      model: tipoProcedimento,
      uri: 'api/tipo-procedimento/'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

}
