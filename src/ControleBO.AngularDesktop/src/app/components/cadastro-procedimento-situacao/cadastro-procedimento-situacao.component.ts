import { Component, OnInit, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Situacao } from 'src/app/models/situacao';
import { SituacaoService } from 'src/app/services/situacao.service';
import { Movimentacao } from 'src/app/models/movimentacao';
import { MovimentacaoService } from 'src/app/services/movimentacao.service';
import { SituacaoProcedimento } from 'src/app/models/situacao-procedimento';
import { SituacaoProcedimentoService } from 'src/app/services/situacao-procedimento.service';
import { TipoSituacao } from 'src/app/models/tipo-situacao';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { MessageService } from 'src/app/services/message.service';
import { CadastroMovimentacaoComponent } from '../cadastro-movimentacao/cadastro-movimentacao.component';
import { IMessage, Action } from 'src/app/models/message';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-cadastro-procedimento-situacao',
  templateUrl: './cadastro-procedimento-situacao.component.html',
  styleUrls: ['./cadastro-procedimento-situacao.component.css']
})
export class CadastroProcedimentoSituacaoComponent implements OnInit, OnDestroy {

  private bsConfig: Partial<BsDatepickerConfig> = { containerClass: 'theme-default' };

  private procedimentoId: number;

  private isLoadingSituacaoProcedimento: boolean;
  private isLoadingSituacoes: boolean;
  private isLoadingMovimentacoes: boolean;

  private observacao: string = '';

  private situacao: Situacao = { id: 1 };
  private situacoes: Situacao[] = [];
  private movimentacoes: Movimentacao[] = [];
  private situacaoProcedimento: SituacaoProcedimento = { id: 0, observacao: this.observacao, procedimentoId: this.procedimentoId, situacaoId: this.situacao.id, DataRelatorio: null };
  private tipoSituacao: TipoSituacao;
  private indiciamentos = [
    {
      id: 1, descricao: 'Com indiciamento'
    },
    {
      id: 2, descricao: 'Sem indiciamento'
    }
  ];
  private dataRelatorio: Date = new Date();

  private selectedSituacaoId: number;
  private selectedTipoSituacaoId: number = 0;
  private selectedIndiciamentoId: number = 1;

  private modalRef: BsModalRef;
  private subscription: Subscription;

  constructor(private route: ActivatedRoute,
    private toastr: ToastrService,
    private situacaoService: SituacaoService,
    private movimentacaoService: MovimentacaoService,
    private situacaoProcedimentoService: SituacaoProcedimentoService,
    private modalService: BsModalService,
    private messageService: MessageService,
    private cdr: ChangeDetectorRef,
    private spinner: NgxSpinnerService) {
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.spinner.show();

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
        this.situacaoProcedimento = new SituacaoProcedimento(res.data);
        this.observacao = this.situacaoProcedimento.observacao;
        this.dataRelatorio = this.situacaoProcedimento.DataRelatorio;

        if (this.situacaoProcedimento.situacaoTipoId) {
          this.selectedIndiciamentoId = this.indiciamentos[1].id;
        }

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
      () => {
        this.isLoadingMovimentacoes = false;
        this.spinner.hide();
      });
  }

  private onSituacaoChange(event) {
    this.situacao = event;
  }

  private onTipoSituacaoChange(event) {
    this.tipoSituacao = event;
  }

  private salvar() {

    this.situacaoProcedimento.procedimentoId = this.procedimentoId;
    this.situacaoProcedimento.situacaoTipoId = null;

    if (!this.situacao) {
      this.toastr.warning('Por favor selecione uma situação válida.');
      return;
    }

    if (this.situacaoProcedimento.situacaoId != this.situacao.id) {
      this.situacaoProcedimento.id = 0;
    }

    this.situacaoProcedimento.situacaoId = this.situacao.id;

    if (this.situacao.id != 1 && !this.tipoSituacao) {
      this.toastr.warning('Por favor selecione uma motivo válido.');
      return;
    }

    if (this.situacao.id == 3) {
      this.situacaoProcedimento.DataRelatorio = this.dataRelatorio;

      if (this.tipoSituacao.id != this.situacaoProcedimento.situacaoTipoId) {
        this.situacaoProcedimento.id = 0;
      }
    }

    if (this.tipoSituacao) {
      this.situacaoProcedimento.situacaoTipoId = this.tipoSituacao.id;
    }
    this.situacaoProcedimento.observacao = this.observacao;

    this.spinner.show();

    if (this.situacaoProcedimento.id) {
      this.situacaoProcedimentoService.update(this.situacaoProcedimento).subscribe(res => {
        if (res.success) {
          this.toastr.success(res.message);
        }
      }, (res) => {
        this.toastr.error(res.message);
        res.errors.forEach(m => this.toastr.error(m));
      }).add(() => {
        this.spinner.hide();
        this.isLoadingSituacaoProcedimento = false;
        this.spinner.hide();
      });
    }
    else {
      this.situacaoProcedimentoService.create(this.situacaoProcedimento).subscribe(res => {
        if (res.success) {
          this.toastr.success(res.message);
        }
      }, (res) => {
        this.toastr.error(res.message);
        res.errors.forEach(m => this.toastr.error(m));
      }).add(() => {
        this.spinner.hide();
        this.isLoadingSituacaoProcedimento = false;
        this.spinner.hide();
      });
    }

  }

  private openModalMovimentacao(movimentacao: Movimentacao) {
    const initialState = {
      model: movimentacao == undefined ? new Movimentacao(this.procedimentoId) : movimentacao
    };
    this.modalRef = this.modalService.show(CadastroMovimentacaoComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
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
          message.errors.forEach(m => this.toastr.error(m));
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
    else if (message.action == Action.Updated) {
      this.updateTable(message.data);
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private addToTable(movimentacao: Movimentacao) {
    this.movimentacoes.push(movimentacao);
  }

  private updateTable(movimentacao: Movimentacao) {
    let index = this.movimentacoes.findIndex(x => x.id == movimentacao.id);
    this.movimentacoes[index] = movimentacao;
  }

  private removeFromTable(movimentacao: Movimentacao) {
    let index = this.movimentacoes.indexOf(movimentacao);
    this.movimentacoes.splice(index, 1);
  }
}
