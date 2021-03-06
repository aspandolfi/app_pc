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
import { Result } from '../../models/result';
import { UserManagerService } from '../../services/user-manager.service';

@Component({
  selector: 'app-cadastro-procedimento-situacao',
  templateUrl: './cadastro-procedimento-situacao.component.html',
  styleUrls: ['./cadastro-procedimento-situacao.component.scss']
})
export class CadastroProcedimentoSituacaoComponent implements OnInit, OnDestroy {

  bsConfig: Partial<BsDatepickerConfig> = { containerClass: 'theme-default' };

  get Situacao() {
    return Situacao;
  }

  private procedimentoId: number;

  isLoadingSituacaoProcedimento: boolean;
  isLoadingSituacoes: boolean;
  isLoadingMovimentacoes: boolean;

  observacao: string = '';

  situacao: Situacao = { id: 1, codigo: Situacao.NaDelegacia };
  situacoes: Situacao[] = [];
  movimentacoes: Movimentacao[] = [];
  situacaoProcedimento: SituacaoProcedimento = { id: 0, observacao: this.observacao, procedimentoId: this.procedimentoId, situacaoId: this.situacao.id, DataRelatorio: null };
  tipoSituacao: TipoSituacao;
  indiciamentos = [
    {
      id: 1, descricao: 'Com indiciamento'
    },
    {
      id: 2, descricao: 'Sem indiciamento'
    }
  ];
  dataRelatorio: Date = new Date();

  selectedSituacaoId: number;
  selectedTipoSituacaoId: number = 0;
  selectedIndiciamentoId: number = 1;

  private modalRef: BsModalRef;
  private subscription: Subscription;

  get canEdit() {
    return this.userManager.canEdit();
  }

  constructor(private route: ActivatedRoute,
    private toastr: ToastrService,
    private situacaoService: SituacaoService,
    private movimentacaoService: MovimentacaoService,
    private situacaoProcedimentoService: SituacaoProcedimentoService,
    private modalService: BsModalService,
    private messageService: MessageService,
    private cdr: ChangeDetectorRef,
    private userManager: UserManagerService) {
    this.onReceiveMessage();
  }

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
        this.situacaoProcedimento = new SituacaoProcedimento(res.data);
        this.observacao = this.situacaoProcedimento.observacao;
        this.dataRelatorio = this.situacaoProcedimento.DataRelatorio;

        if (this.situacaoProcedimento.situacaoTipoId) {
          this.selectedIndiciamentoId = this.indiciamentos[1].id;
        }

      }
    },
      () => this.toastr.error('Falha ao buscar a Situação Atual.')
    ).add(() => {
      this.isLoadingSituacaoProcedimento = false;
      //this.cdr.detectChanges();

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
      });
  }

  onSituacaoChange(event) {
    this.situacao = event;
    this.selectedTipoSituacaoId = 0;
    this.tipoSituacao = null;
    this.dataRelatorio = null;
  }

  onTipoSituacaoChange(event) {
    this.tipoSituacao = event;
  }

  onIndiciamentoChange(event) {
    this.dataRelatorio = null;
    this.selectedTipoSituacaoId = 0;
    this.tipoSituacao = null;
  }

  salvar() {

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

    if (this.situacao.codigo == Situacao.Relatado && this.selectedIndiciamentoId == 1 && !this.dataRelatorio) {
      this.toastr.warning('Por favor selecione uma data de relatório válida.');
      this.dataRelatorio = null;
      return;
    }

    if (this.situacao.codigo != Situacao.NaDelegacia && this.selectedIndiciamentoId == 2 && !this.tipoSituacao) {
      this.toastr.warning('Por favor selecione um motivo válido.');
      return;
    }

    if (this.situacao.codigo == Situacao.NaJustica && !this.tipoSituacao) {
      this.toastr.warning('Por favor selecione um motivo válido.');
      return;
    }

    if (this.situacao.codigo == Situacao.Outros) {
      if (!this.situacaoProcedimento.observacao) {
        this.toastr.warning('O campo Observação é obrigatório quando a situação é Outros.');
        return;
      }
    }

    if (this.situacao.codigo == Situacao.Relatado) {
      this.situacaoProcedimento.DataRelatorio = this.dataRelatorio;

      if (!this.dataRelatorio) {
        this.toastr.warning('Por favor selecione uma data de relatório válida.');
        this.dataRelatorio = null;
        return;
      }

      if (this.tipoSituacao) {
        if (this.tipoSituacao.id != this.situacaoProcedimento.situacaoTipoId) {
          this.situacaoProcedimento.id = 0;
        }
      }
    }

    if (this.tipoSituacao) {
      this.situacaoProcedimento.situacaoTipoId = this.tipoSituacao.id;
    }
    this.situacaoProcedimento.observacao = this.observacao;

    if (this.situacaoProcedimento.id) {
      this.situacaoProcedimentoService.update(this.situacaoProcedimento).subscribe(res => {
        if (res.success) {
          this.toastr.success(res.message);
        }
      }, (res: Result<any>) => {
        this.toastr.error(res.message);
        if (res.errors) {
          res.errors.forEach(m => this.toastr.error(m));
        }
      }).add(() => {
        this.isLoadingSituacaoProcedimento = false;
      });
    }
    else {
      this.situacaoProcedimentoService.create(this.situacaoProcedimento).subscribe(res => {
        if (res.success) {
          this.toastr.success(res.message);
        }
      }, (res: Result<any>) => {
        this.toastr.error(res.message);
        if (res.errors) {
          res.errors.forEach(m => this.toastr.error(m));
        }
      }).add(() => {
        this.isLoadingSituacaoProcedimento = false;
      });
    }

  }

  openModalMovimentacao(movimentacao: Movimentacao) {
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
    let index = this.movimentacoes.findIndex(x => x.id == movimentacao.id);
    this.movimentacoes.splice(index, 1);
  }
}
