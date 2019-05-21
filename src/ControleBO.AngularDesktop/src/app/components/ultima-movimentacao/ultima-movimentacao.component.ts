import { Component, OnInit, Input } from '@angular/core';
import { UltimaMovimentacao } from 'src/app/models/ultima-movimentacao';

@Component({
  selector: 'app-ultima-movimentacao',
  templateUrl: './ultima-movimentacao.component.html',
  styleUrls: ['./ultima-movimentacao.component.css']
})
export class UltimaMovimentacaoComponent implements OnInit {

  private _ultimasMovimentacoes: UltimaMovimentacao[] = [];

  @Input("ultimasMovimentacoes")
  set ultimasMovimentacoes(ultimasMovimentacoes: UltimaMovimentacao[]) {
    if (!ultimasMovimentacoes) {
      this._ultimasMovimentacoes = [];
    }
    else {
      this._ultimasMovimentacoes = ultimasMovimentacoes;
    }
  }

  get ultimasMovimentacoes() {
    return this._ultimasMovimentacoes
      .map((item, i) => ({ id: i + 1, ...item }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

  @Input("titulo")
  titulo: string = "Últimas Movimentações";

  private page = 1;
  private pageSize = 3;
  private totalItems = this.ultimasMovimentacoes.length;

  constructor() { }

  ngOnInit() {
  }

  pageChanged(event: any): void {
    this.page = event.page;
    this.ultimasMovimentacoes;
  }

}
