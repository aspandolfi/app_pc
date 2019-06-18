import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Situacao } from 'src/app/models/situacao';
import { SituacaoService } from 'src/app/services/situacao.service';
import { Movimentacao } from 'src/app/models/movimentacao';
import { MovimentacaoService } from 'src/app/services/movimentacao.service';
import { SituacaoProcedimento } from 'src/app/models/situacao-procedimento';
import { SituacaoProcedimentoService } from 'src/app/services/situacao-procedimento.service';
import { TipoSituacao } from 'src/app/models/tipo-situacao';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker/public_api';

@Component({
  selector: 'app-cadastro-procedimento-situacao',
  templateUrl: './cadastro-procedimento-situacao.component.html',
  styleUrls: ['./cadastro-procedimento-situacao.component.css']
})
export class CadastroProcedimentoSituacaoComponent implements OnInit {

  private bsConfig: Partial<BsDatepickerConfig> = { containerClass: 'theme-default' };

  private procedimentoId: number;

  private isLoadingSituacaoProcedimento: boolean;
  private isLoadingSituacoes: boolean;
  private isLoadingMovimentacoes: boolean;

  private observacao: string = '';

  private situacao: Situacao = { id: 1 };
  private situacoes: Situacao[] = [];
  private movimentacoes: Movimentacao[] = [];
  private situacaoProcedimento: SituacaoProcedimento = { id: 0, observacao: this.observacao, procedimentoId: this.procedimentoId, situacaoId: this.situacao.id, dataRelatorio: new Date() };
  private tipoSituacao: TipoSituacao;
  private indiciamentos = [
    {
      id: 1, descricao: 'Com indiciamento'
    },
    {
      id: 2, descricao: 'Sem indiciamento'
    }
  ];

  private selectedSituacaoId: number;
  private selectedTipoSituacaoId: number = 0;
  private selectedIndiciamentoId: number = 1;

  constructor(private route: ActivatedRoute,
    private toastr: ToastrService,
    private situacaoService: SituacaoService,
    private movimentacaoService: MovimentacaoService,
    private situacaoProcedimentoService: SituacaoProcedimentoService,
    private cdr: ChangeDetectorRef) { }

  ngOnInit() {
    this.route.parent.paramMap.subscribe(params => {
      this.procedimentoId = +params.get('id');
      this.getSituacaoProcedimento(this.procedimentoId);
      this.getMovimentacoes(this.procedimentoId);
    });
  }

  private getSituacaoProcedimento(procedimentoId: number) {
    this.isLoadingSituacaoProcedimento = true;
    this.situacaoProcedimentoService.getByProcedimento(procedimentoId).subscribe(res => {
      if (res.data) {
        this.situacaoProcedimento = res.data;
      }
    },
      () => this.toastr.error('Falha ao buscar a Situação Atual.'),
      () => {
        this.isLoadingSituacaoProcedimento = false;
        this.cdr.detectChanges();
      }
    ).add(() => {
      this.getSituacoes();
    });
  }

  private getSituacoes() {
    this.isLoadingSituacoes = true;
    this.situacaoService.getAll().subscribe(res => {
      this.situacoes = res.data;
    },
      () => this.toastr.error('Falha ao buscar as Situações.'),
      () => this.isLoadingSituacoes = false)
      .add(() => {
        if (this.situacaoProcedimento) {
          this.situacao = this.situacoes.find(x => x.id == this.situacaoProcedimento.situacaoId);

          if (this.situacao) {
            this.selectedSituacaoId = this.situacao.id;

            if (this.situacaoProcedimento.situacaoTipoId) {
              this.tipoSituacao = this.situacao.tipos.find(x => x.id == this.situacaoProcedimento.situacaoTipoId);
              if (this.tipoSituacao) {
                this.selectedTipoSituacaoId = this.tipoSituacao.id;
              }
            }
          }
        }
        else {
          this.selectedSituacaoId = this.situacoes[0].id;
        }
      });
  }

  private getMovimentacoes(procedimentoId) {
    this.isLoadingMovimentacoes = true;
    this.movimentacaoService.getByProcedimentoId(procedimentoId).subscribe(res => {
      this.movimentacoes = res.data;
    },
      () => this.toastr.error('Falha ao buscar as Movimentações'),
      () => this.isLoadingMovimentacoes = false)
  }

  private onSituacaoChange(event) {
    this.situacao = event;
  }

  private onTipoSituacaoChange(event) {
    this.tipoSituacao = event;
  }

  private salvar() {
    if (!this.situacao) {
      this.toastr.warning('Por favor selecione uma situação válida.');
      return;
    }

    this.situacaoProcedimento.situacaoId = this.situacao.id;

    if (this.situacao.id != 1 && !this.tipoSituacao) {
      this.toastr.warning('Por favor selecione uma motivo válido.');
      return;
    }

    this.situacaoProcedimento.situacaoId = this.tipoSituacao.id;
    this.situacaoProcedimento.observacao = this.observacao;


  }

}
