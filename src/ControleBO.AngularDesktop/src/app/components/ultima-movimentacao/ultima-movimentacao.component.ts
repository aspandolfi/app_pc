import { Component, OnInit, Input } from '@angular/core';
import { Movimentacao } from 'src/app/models/movimentacao';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CadastroMovimentacaoComponent } from '../cadastro-movimentacao/cadastro-movimentacao.component';

@Component({
  selector: 'app-ultima-movimentacao',
  templateUrl: './ultima-movimentacao.component.html',
  styleUrls: ['./ultima-movimentacao.component.scss']
})
export class UltimaMovimentacaoComponent implements OnInit {

  private _ultimasMovimentacoes: Movimentacao[] = [];

  modalRef: BsModalRef;

  @Input("ultimasMovimentacoes")
  set ultimasMovimentacoes(ultimasMovimentacoes: Movimentacao[]) {
    if (!ultimasMovimentacoes) {
      this._ultimasMovimentacoes = [];
    }
    else {
      this._ultimasMovimentacoes = ultimasMovimentacoes;
    }
  }

  get ultimasMovimentacoes() {
    return this._ultimasMovimentacoes
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

  @Input("titulo")
  titulo: string = "Últimas Movimentações";

  page = 1;
  pageSize = 3;

  get totalItems() {
    return this._ultimasMovimentacoes.length;
  }

  @Input('enableActions')
  enableActions: boolean = true;

  constructor(private modalService: BsModalService) { }

  ngOnInit() {
  }

  pageChanged(event: any): void {
    this.page = event.page;
  }

  openModalExcluir(movimentacao: Movimentacao) {
    const initialState = {
      model: movimentacao,
      uri: 'api/movimentacao/',
      propertyToDescribe: 'destino'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  openModalCadastro(movimentacao: Movimentacao) {
    const initialState = {
      model: movimentacao
    };
    this.modalRef = this.modalService.show(CadastroMovimentacaoComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

}
