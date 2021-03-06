import { Component, OnInit, Input, AfterViewInit, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { Procedimento } from 'src/app/models/procedimento';
import { TipoProcedimento } from 'src/app/models/tipo-procedimento';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { TipoProcedimentoService } from 'src/app/services/tipo-procedimento.service';
import { ToastrService } from 'ngx-toastr';
import { VaraCriminal } from 'src/app/models/vara-criminal';
import { VaraCriminalService } from 'src/app/services/vara-criminal.service';
import { Municipio } from 'src/app/models/municipio';
import { MunicipioService } from 'src/app/services/municipio.service';
import { ProcedimentoService } from 'src/app/services/procedimento.service';
import { BsLocaleService, BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { Artigo } from 'src/app/models/artigo';
import { Assunto } from 'src/app/models/assunto';
import { ArtigoService } from 'src/app/services/artigo.service';
import { AssuntoService } from 'src/app/services/assunto.service';
import { Message, Action, IMessage } from 'src/app/models/message';
import { TabsMessageService } from 'src/app/services/tabs-message.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UnidadePolicialService } from 'src/app/services/unidade-policial.service';
import { UnidadePolicial } from 'src/app/models/unidade-policial';
import { Result } from 'src/app/models/result';
import { MovimentacaoService } from '../../services/movimentacao.service';
import { UserManagerService } from '../../services/user-manager.service';
import { Movimentacao } from 'src/app/models/movimentacao';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { MessageService } from 'src/app/services/message.service';
import { Subscription } from 'rxjs';
import { CadastroMovimentacaoComponent } from '../cadastro-movimentacao/cadastro-movimentacao.component';

@Component({
  selector: 'app-cadastro-procedimento-controle',
  templateUrl: './cadastro-procedimento-controle.component.html',
  styleUrls: ['./cadastro-procedimento-controle.component.scss']
})
export class CadastroProcedimentoControleComponent implements OnInit, AfterViewInit, OnDestroy {

  bsConfig: Partial<BsDatepickerConfig> = { containerClass: 'theme-default' };

  placeHolderYear: string = `00000/${new Date().getFullYear()}`;

  private tipoProcedimento: TipoProcedimento;
  tipoProcedimentoSelected: string;
  private varaCriminal: VaraCriminal;
  varaCriminalSelected: string;
  private comarca: Municipio;
  comarcaSelected: string;
  private artigo: Artigo;
  artigoSelected: string;
  private assunto: Assunto;
  assuntoSelected: string;
  private delegacia: UnidadePolicial;
  delegaciaSelected: string;

  procedimento: Procedimento = new Procedimento();

  tiposProcedimento: TipoProcedimento[] = [];
  varasCriminais: VaraCriminal[] = [];
  municipios: Municipio[] = [];
  assuntos: Assunto[] = [];
  artigos: Artigo[] = [];
  delegacias: UnidadePolicial[] = [];
  movimentacoes: Movimentacao[] = [];

  @Input("procedimentoId")
  procedimentoId: number;

  isLoading: boolean = false;
  isLoadingTipos: boolean = false;
  isLoadingComarcas: boolean = false;
  isLoadingVaras: boolean = false;
  isLoadingArtigos: boolean = false;
  isLoadingAssuntos: boolean = false;
  isLoadingDelegacias: boolean = false;
  isLoadingMovimentacoes: boolean;

  isNoResultProcedimentoTipo: boolean = false;
  isNoResultComarca: boolean = false;
  isNoResultVaraCriminal: boolean = false;
  isNoResultAssunto: boolean = false;
  isNoResultArtigo: boolean = false;
  isNoResultDelegacia: boolean = false;

  private modalRef: BsModalRef;
  private subscription: Subscription;

  get canEdit() {
    return this.userManager.canEdit();
  }

  constructor(private tipoProcedimentoService: TipoProcedimentoService,
    private varaCriminalService: VaraCriminalService,
    private municipioService: MunicipioService,
    private procedimentoService: ProcedimentoService,
    private artigoService: ArtigoService,
    private assuntoService: AssuntoService,
    private unidadePolicialService: UnidadePolicialService,
    private movimentacaoService: MovimentacaoService,
    private localeService: BsLocaleService,
    private toastr: ToastrService,
    private tabsMessageService: TabsMessageService,
    private route: ActivatedRoute,
    private router: Router,
    private cdr: ChangeDetectorRef,
    private userManager: UserManagerService,
    private modalService: BsModalService,
    private messageService: MessageService, ) {
    this.changeLocale();
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.route.parent.paramMap.subscribe(params => {
      this.procedimentoId = +params.get('id');
      this.getProcedimento(this.procedimentoId);
      this.getMovimentacoes(this.procedimentoId);
    });
  }

  ngAfterViewInit() {
    //this.cdr.detectChanges();
  }

  private getProcedimento(procedimentoId) {
    if (procedimentoId) {
      this.procedimentoService.get(procedimentoId).subscribe(res => {
        if (res.data) {
          this.procedimento = new Procedimento(res.data); // Success
        }
        else {
          this.toastr.warning(`O Procedimento # ${procedimentoId} não foi encontrado.`);
          this.router.navigate(['cadastro-procedimento', { outlets: { procedimento: null } }]); // clear the router
          this.router.navigate(['procedimentos']);
        }
      },
        () => this.toastr.error(`Falha ao buscar o Procedimento # ${procedimentoId}.`), // Fail
        () => {
          this.isLoading = false;
          this.cdr.detectChanges();
        } // Completed
      ).add(() => {
        this.getTiposProcedimentos();
        this.getDelegacias();
        this.getMunicipios();
        this.getVarasCriminais();
        this.getArtigos();
        this.getAssuntos();
        //this.getUltimaMovimentacao();
      });
    }
    else {
      this.procedimento = new Procedimento();
      this.getDelegacias();
      this.getTiposProcedimentos();
      this.getMunicipios();
      this.getVarasCriminais();
      this.getArtigos();
      this.getAssuntos();
    }
  }

  private getTiposProcedimentos() {

    this.isLoadingTipos = true;

    this.tipoProcedimentoService.getAll().subscribe(res =>
      this.tiposProcedimento = res.data, // Success
      () => this.toastr.error("Falha ao buscar os Tipos de Procedimento."), // Fail
      () => this.isLoadingTipos = false // Completed
    ).add(() => {
      this.tipoProcedimento = this.tiposProcedimento.find(x => x.id == this.procedimento.tipoProcedimentoId);
      if (this.tipoProcedimento) {
        this.tipoProcedimentoSelected = this.tipoProcedimento.descricao;
      }
    }
    );
  }

  private getVarasCriminais() {
    this.isLoadingVaras = true;

    this.varaCriminalService.getAll().subscribe(res =>
      this.varasCriminais = res.data, // Success
      () => this.toastr.error("Falha ao buscar as Varas Criminais."), // Fail
      () => this.isLoadingVaras = false // Completed
    ).add(() => {
      this.varaCriminal = this.varasCriminais.find(x => x.id == this.procedimento.varaCriminalId)
      if (this.varaCriminal) {
        this.varaCriminalSelected = this.varaCriminal.descricao;
      }
    }
    );
  }

  private getMunicipios() {
    this.isLoadingComarcas = true;

    this.municipioService.getAll().subscribe(res =>
      this.municipios = res.data, // Success
      () => this.toastr.error("Falha ao buscar os Municípios."), // Fail
      () => this.isLoadingComarcas = false // Completed
    ).add(() => {
      this.comarca = this.municipios.find(x => x.id == this.procedimento.comarcaId);
      if (this.comarca) {
        this.comarcaSelected = this.comarca.nome;
      }
    });
  }

  private getAssuntos() {
    this.isLoadingAssuntos = true;

    this.assuntoService.getAll().subscribe(res => this.assuntos = res.data,
      () => this.toastr.error("Falha ao buscar os Assuntos."),
      () => this.isLoadingAssuntos = false
    ).add(() => {
      this.assunto = this.assuntos.find(x => x.id == this.procedimento.assuntoId);
      if (this.assunto) {
        this.assuntoSelected = this.assunto.descricao;
      }
    });
  }

  private getArtigos() {
    this.isLoadingArtigos = true;

    this.artigoService.getAll().subscribe(res => this.artigos = res.data,
      () => this.toastr.error("Falha ao buscar os Artigos."),
      () => this.isLoadingArtigos = false
    ).add(() => {
      this.artigo = this.artigos.find(x => x.id == this.procedimento.artigoId);
      if (this.artigo) {
        this.artigoSelected = this.artigo.descricao;
      }
    });
  }

  private getDelegacias() {
    this.isLoadingDelegacias = true;

    this.unidadePolicialService.getAll().subscribe(res => {
      if (res.data) {
        res.data.map(u => this.delegacias.push(
          { codigo: u.codigo, codigoCargoQO: u.codigoCargoQO, descricao: `${u.descricao} - ${u.sigla}`, id: u.id, sigla: u.sigla }
        ));
      }
    },
      () => this.toastr.error("Falha ao buscar as Delegacias."),
      () => this.isLoadingDelegacias = false
    ).add(() => {
      this.delegacia = this.delegacias.find(x => x.id == this.procedimento.delegaciaId);
      if (this.delegacia) {
        this.delegaciaSelected = this.delegacia.descricao;
      }
    });
  }

  private getUltimaMovimentacao() {
    this.movimentacaoService.geLastByProcedimentoId(this.procedimentoId).subscribe(res => {
      this.procedimento.movimentacoes.push(res.data);
    }, (error) => this.toastr.error(error.message));
  }

  onSelectTipoProcedimento(event: TypeaheadMatch) {
    if (!this.tiposProcedimento.find(x => x.id == event.item.id)) {
      this.isNoResultProcedimentoTipo = true;
      this.tipoProcedimento = undefined;
      return;
    }
    this.isNoResultProcedimentoTipo = false;
    this.tipoProcedimento = event.item;
  }

  onSelectComarca(event: TypeaheadMatch) {
    if (!this.municipios.find(x => x.id == event.item.id)) {
      this.isNoResultComarca = true;
      this.comarca = undefined;
      return;
    }
    this.isNoResultComarca = false;
    this.comarca = event.item;
  }

  onSelectVaraCriminal(event: TypeaheadMatch) {
    if (!this.varasCriminais.find(x => x.id == event.item.id)) {
      this.isNoResultVaraCriminal = true;
      this.varaCriminal = undefined;
      return;
    }
    this.isNoResultVaraCriminal = false;
    this.varaCriminal = event.item;
  }

  onSelectArtigo(event: TypeaheadMatch) {
    if (!this.artigos.find(x => x.id == event.item.id)) {
      this.isNoResultArtigo = true;
      this.artigo = undefined;
      return;
    }
    this.isNoResultArtigo = false;
    this.artigo = event.item;
  }

  onSelectAssunto(event: TypeaheadMatch) {
    if (!this.assuntos.find(x => x.id == event.item.id)) {
      this.isNoResultAssunto = true;
      this.assunto = undefined;
      return;
    }
    this.isNoResultAssunto = false;
    this.assunto = event.item;
  }

  onSelectDelegacia(event: TypeaheadMatch) {
    if (!this.delegacias.find(x => x.id == event.item.id)) {
      this.isNoResultDelegacia = true;
      this.delegacia = undefined;
      return;
    }
    this.isNoResultDelegacia = false;
    this.delegacia = event.item;
  }

  private changeLocale() {
    this.localeService.use('pt-br');
  }

  tipoProcedimentoNoResults(event: boolean): void {
    this.isNoResultProcedimentoTipo = event;
  }

  comarcaNoResults(event: boolean): void {
    this.isNoResultComarca = event;
  }

  varaCriminalNoResults(event: boolean): void {
    this.isNoResultVaraCriminal = event;
  }

  artigoNoResults(event: boolean): void {
    this.isNoResultArtigo = event;
  }

  assuntoNoResults(event: boolean): void {
    this.isNoResultAssunto = event;
  }

  delegaciaNoResults(event: boolean): void {
    this.isNoResultDelegacia = event;
  }

  salvar() {

    //if (!this.tipoProcedimento) {
    //  this.toastr.error('Tipo de Procedimento inválido. Por favor selecione um item válido.');
    //  return;
    //}

    //if (!this.comarca) {
    //  this.toastr.error('Comarca inválida. Por favor selecione um item válido.');
    //  return;
    //}

    //if (!this.varaCriminal) {
    //  this.toastr.error('Vara Criminal inválida. Por favor selecione um item válido.');
    //  return;
    //}

    //if (!this.assunto) {
    //  this.toastr.error('Assunto inválido. Por favor selecione um item válido.');
    //  return;
    //}

    //if (!this.artigo) {
    //  this.toastr.error('Artigo inválido. Por favor selecione um item válido.');
    //  return;
    //}

    //if (!this.delegacia) {
    //  this.toastr.error('Delegacia de Origem inválida. Por favor selecione um item válido.');
    //  return;
    //}

    this.procedimento.tipoProcedimentoId = this.tipoProcedimento ? this.tipoProcedimento.id : undefined;
    this.procedimento.varaCriminalId = this.varaCriminal ? this.varaCriminal.id : undefined;
    this.procedimento.comarcaId = this.comarca ? this.comarca.id : undefined;
    this.procedimento.assuntoId = this.assunto ? this.assunto.id : undefined;
    this.procedimento.artigoId = this.artigo ? this.artigo.id : undefined;
    this.procedimento.delegaciaId = this.delegacia ? this.delegacia.id : undefined;

    if (!this.procedimentoId) {
      this.procedimento.movimentacoes = this.movimentacoes;
    }

    this.isLoading = true;

    if (this.procedimento.id) {
      this.procedimentoService.update(this.procedimento).subscribe(res => {
        if (res.success) {
          this.toastr.success(res.message);
        }
      }, (res: Result<any>) => {
        this.toastr.error(res.message);
        if (res.errors) {
          res.errors.forEach(m => this.toastr.error(m));
        }
      }).add(() => {
        this.isLoading = false;
      });
    }
    else {
      this.procedimentoService.create(this.procedimento).subscribe(res => {
        if (res.success) {
          this.toastr.success(res.message);
          this.tabsMessageService.send(new Message(res, Action.Created));
        }
      }, (res: Result<any>) => {
        this.toastr.error(res.message);
        if (res.errors) {
          res.errors.forEach(m => this.toastr.error(m));
        }
      }).add(() => {
        this.isLoading = false;
      });
    }
  }

  private getMovimentacoes(procedimentoId) {
    this.isLoadingMovimentacoes = true;
    this.movimentacaoService.getByProcedimentoId(procedimentoId).subscribe(res => {
      this.movimentacoes = res.data;
    },
      () => this.toastr.error('Falha ao buscar as Movimentações')
    ).add(() => this.isLoadingMovimentacoes = false);
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
    this.movimentacoes.sort((a, b) => a.data > b.data ? -1 : 1);
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
