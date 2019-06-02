import { Component, OnInit, Input, AfterViewInit, ChangeDetectorRef } from '@angular/core';
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
import { NgxSpinnerService } from 'ngx-spinner';
import { BsLocaleService, BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { Artigo } from 'src/app/models/artigo';
import { Assunto } from 'src/app/models/assunto';
import { ArtigoService } from 'src/app/services/artigo.service';
import { AssuntoService } from 'src/app/services/assunto.service';
import { Message, Action } from 'src/app/models/message';
import { TabsMessageService } from 'src/app/services/tabs-message.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UnidadePolicialService } from 'src/app/services/unidade-policial.service';
import { UnidadePolicial } from 'src/app/models/unidade-policial';
import { Result } from 'src/app/models/result';

@Component({
  selector: 'app-cadastro-procedimento-controle',
  templateUrl: './cadastro-procedimento-controle.component.html',
  styleUrls: ['./cadastro-procedimento-controle.component.css']
})
export class CadastroProcedimentoControleComponent implements OnInit, AfterViewInit {

  private bsConfig: Partial<BsDatepickerConfig> = { containerClass: 'theme-default' };

  private tipoProcedimento: TipoProcedimento;
  private tipoProcedimentoSelected: string;
  private varaCriminal: VaraCriminal;
  private varaCriminalSelected: string;
  private comarca: Municipio;
  private comarcaSelected: string;
  private artigo: Artigo;
  private artigoSelected: string;
  private assunto: Assunto;
  private assuntoSelected: string;
  private delegacia: UnidadePolicial;
  private delegaciaSelected: string;

  private procedimento: Procedimento = new Procedimento();

  private tiposProcedimento: TipoProcedimento[] = [];
  private varasCriminais: VaraCriminal[] = [];
  private municipios: Municipio[] = [];
  private assuntos: Assunto[] = [];
  private artigos: Artigo[] = [];
  private delegacias: UnidadePolicial[] = [];

  @Input("procedimentoId")
  procedimentoId: number;

  private isLoading: boolean = false;
  private isLoadingTipos: boolean = false;
  private isLoadingComarcas: boolean = false;
  private isLoadingVaras: boolean = false;
  private isLoadingArtigos: boolean = false;
  private isLoadingAssuntos: boolean = false;
  private isLoadingDelegacias: boolean = false;

  private isNoResultProcedimentoTipo: boolean = false;
  private isNoResultComarca: boolean = false;
  private isNoResultVaraCriminal: boolean = false;
  private isNoResultAssunto: boolean = false;
  private isNoResultArtigo: boolean = false;
  private isNoResultDelegacia: boolean = false;

  constructor(private tipoProcedimentoService: TipoProcedimentoService,
    private varaCriminalService: VaraCriminalService,
    private municipioService: MunicipioService,
    private procedimentoService: ProcedimentoService,
    private artigoService: ArtigoService,
    private assuntoService: AssuntoService,
    private unidadePolicialService: UnidadePolicialService,
    private spinner: NgxSpinnerService,
    private localeService: BsLocaleService,
    private toastr: ToastrService,
    private tabsMessageService: TabsMessageService,
    private route: ActivatedRoute,
    private router: Router,
    private cdr: ChangeDetectorRef) {
    this.changeLocale();
  }

  ngOnInit() {
    this.route.parent.paramMap.subscribe(params => {
      this.procedimentoId = +params.get('id');
      this.getProcedimento(this.procedimentoId);
    });
  }

  ngAfterViewInit() {
    //this.cdr.detectChanges();
  }

  private getProcedimento(procedimentoId) {
    if (procedimentoId) {
      this.spinner.show();
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
          this.spinner.hide();
          this.cdr.detectChanges();
        } // Completed
      ).add(() => {
        this.getTiposProcedimentos();
        this.getDelegacias();
        this.getMunicipios();
        this.getVarasCriminais();
        this.getArtigos();
        this.getAssuntos();
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

    this.unidadePolicialService.getAll().subscribe(res => this.delegacias = res.data,
      () => this.toastr.error("Falha ao buscar as Delegacias."),
      () => this.isLoadingDelegacias = false
    ).add(() => {
      this.delegacia = this.delegacias.find(x => x.id == this.procedimento.delegaciaId);
      if (this.delegacia) {
        this.delegaciaSelected = this.delegacia.descricao;
      }
    });
  }

  private onSelectTipoProcedimento(event: TypeaheadMatch) {
    if (!this.tiposProcedimento.find(x => x.id == event.item.id)) {
      this.isNoResultProcedimentoTipo = true;
      this.tipoProcedimento = undefined;
      return;
    }
    this.isNoResultProcedimentoTipo = false;
    this.tipoProcedimento = event.item;
  }

  private onSelectComarca(event: TypeaheadMatch) {
    if (!this.municipios.find(x => x.id == event.item.id)) {
      this.isNoResultComarca = true;
      this.comarca = undefined;
      return;
    }
    this.isNoResultComarca = false;
    this.comarca = event.item;
  }

  private onSelectVaraCriminal(event: TypeaheadMatch) {
    if (!this.varasCriminais.find(x => x.id == event.item.id)) {
      this.isNoResultVaraCriminal = true;
      this.varaCriminal = undefined;
      return;
    }
    this.isNoResultVaraCriminal = false;
    this.varaCriminal = event.item;
  }

  private onSelectArtigo(event: TypeaheadMatch) {
    if (!this.artigos.find(x => x.id == event.item.id)) {
      this.isNoResultArtigo = true;
      this.artigo = undefined;
      return;
    }
    this.isNoResultArtigo = false;
    this.artigo = event.item;
  }

  private onSelectAssunto(event: TypeaheadMatch) {
    if (!this.assuntos.find(x => x.id == event.item.id)) {
      this.isNoResultAssunto = true;
      this.assunto = undefined;
      return;
    }
    this.isNoResultAssunto = false;
    this.assunto = event.item;
  }

  private onSelectDelegacia(event: TypeaheadMatch) {
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

  private tipoProcedimentoNoResults(event: boolean): void {
    this.isNoResultProcedimentoTipo = event;
  }

  private comarcaNoResults(event: boolean): void {
    this.isNoResultComarca = event;
  }

  private varaCriminalNoResults(event: boolean): void {
    this.isNoResultVaraCriminal = event;
  }

  private artigoNoResults(event: boolean): void {
    this.isNoResultArtigo = event;
  }

  private assuntoNoResults(event: boolean): void {
    this.isNoResultAssunto = event;
  }

  private delegaciaNoResults(event: boolean): void {
    this.isNoResultDelegacia = event;
  }

  private salvar() {

    if (!this.tipoProcedimento) {
      this.toastr.error('Tipo de Procedimento inválido. Por favor selecione um item válido.');
      return;
    }

    if (!this.comarca) {
      this.toastr.error('Comarca inválida. Por favor selecione um item válido.');
      return;
    }

    if (!this.varaCriminal) {
      this.toastr.error('Vara Criminal inválida. Por favor selecione um item válido.');
      return;
    }

    if (!this.assunto) {
      this.toastr.error('Assunto inválido. Por favor selecione um item válido.');
      return;
    }

    if (!this.artigo) {
      this.toastr.error('Artigo inválido. Por favor selecione um item válido.');
      return;
    }

    if (!this.delegacia) {
      this.toastr.error('Delegacia de Origem inválida. Por favor selecione um item válido.');
      return;
    }

    this.procedimento.varaCriminalId = this.varaCriminal.id;
    this.procedimento.tipoProcedimentoId = this.tipoProcedimento.id;
    this.procedimento.comarcaId = this.comarca.id;
    this.procedimento.assuntoId = this.assunto.id;
    this.procedimento.artigoId = this.artigo.id;
    this.procedimento.delegaciaId = this.delegacia.id;

    this.isLoading = true;
    this.spinner.show();

    if (this.procedimento.id) {
      this.procedimentoService.update(this.procedimento).subscribe(res => {
        if (res.success) {
          this.toastr.success(res.message);
        }
      }, (res) => {
        this.toastr.error(res.message);
        res.error.errors.forEach(m => this.toastr.error(m));
      }).add(() => {
        this.spinner.hide();
        this.isLoading = false;
      });
    }
    else {
      this.procedimentoService.create(this.procedimento).subscribe(res => {
        if (res.success) {
          this.toastr.success(res.message);
          this.tabsMessageService.send(new Message(res, Action.Created));
        }
      }, (error: Result<any>) => {
        this.toastr.error(error.message);
        error.errors.forEach(m => this.toastr.error(m));
      }).add(() => {
        this.spinner.hide();
        this.isLoading = false;
      });
    }
  }

}
