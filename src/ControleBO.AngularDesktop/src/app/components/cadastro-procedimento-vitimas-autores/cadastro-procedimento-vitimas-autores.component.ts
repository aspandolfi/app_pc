import { Component, OnInit, OnDestroy } from '@angular/core';
import { Vitima } from 'src/app/models/vitima';
import { VitimaService } from 'src/app/services/vitima.service';
import { ToastrService } from 'ngx-toastr';
import { Indiciado } from 'src/app/models/indiciado';
import { IndiciadoService } from 'src/app/services/indiciado.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { IMessage, Action } from 'src/app/models/message';
import { CadastroVitimaComponent } from '../cadastro-vitima/cadastro-vitima.component';
import { CadastroIndiciadoComponent } from '../cadastro-indiciado/cadastro-indiciado.component';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-cadastro-procedimento-vitimas-autores',
  templateUrl: './cadastro-procedimento-vitimas-autores.component.html',
  styleUrls: ['./cadastro-procedimento-vitimas-autores.component.scss']
})
export class CadastroProcedimentoVitimasAutoresComponent implements OnInit, OnDestroy {

  private procedimentoId: any;

  isLoadingVitimas: boolean;
  isLoadingIndiciados: boolean;

  vitimas: Vitima[] = [];
  indiciados: Indiciado[] = [];
  pageSize = 4;
  currentPageVitimas = 1;
  currentPageIndiciados = 1;
  returnedVitimas: Vitima[] = [];
  returnedIndiciados: Indiciado[] = [];

  private subscription: Subscription;

  private modalRef: BsModalRef;

  constructor(private vitimaService: VitimaService,
    private indiciadoService: IndiciadoService,
    private toastr: ToastrService,
    private messageService: MessageService,
    private modalService: BsModalService,
    private route: ActivatedRoute,
    private router: Router) {
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.route.parent.paramMap.subscribe(params => {
      this.procedimentoId = params.get('id')
      this.getVitimas(this.procedimentoId);
      this.getIndiciados(this.procedimentoId);
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private getVitimas(procedimentoId) {
    this.isLoadingVitimas = true;
    this.vitimaService.getByProcedimentoId(procedimentoId).subscribe(res => {
      this.vitimas = res.data;
      this.returnedVitimas = this.vitimas.slice(0, this.pageSize);
    },
      () => this.toastr.error('Falha ao buscar as Vítimas.'),
      () => this.isLoadingVitimas = false);
  }

  private getIndiciados(procedimentoId) {
    this.isLoadingIndiciados = true;
    this.indiciadoService.getAllFiltered(procedimentoId).subscribe(res => {
      this.indiciados = res.data;
      this.returnedIndiciados = this.indiciados.slice(0, this.pageSize);
    },
      () => this.toastr.error('Falha ao buscar os Indiciados.'),
      () => this.isLoadingIndiciados = false);
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
  }

  private addToTable(model: any) {
    if (!Object.getOwnPropertyDescriptor(model, 'apelido')) {
      this.vitimas.push(model);
      this.currentPageVitimas = this.getCurrentPage(this.currentPageVitimas, this.vitimas.length);
      this.pageVitimasChanged({ page: this.currentPageVitimas, itemsPerPage: this.pageSize });
    }
    else {
      this.indiciados.push(model);
      this.currentPageIndiciados = this.getCurrentPage(this.currentPageIndiciados, this.indiciados.length);
      this.pageIndiciadosChanged({ page: this.currentPageIndiciados, itemsPerPage: this.pageSize });
    }
  }

  private removeFromTable(model: any) {
    if (!Object.getOwnPropertyDescriptor(model, 'apelido')) {
      let index = this.vitimas.indexOf(model);
      this.vitimas.splice(index, 1);
      this.currentPageVitimas = this.getCurrentPage(this.currentPageVitimas, this.vitimas.length);
      this.pageVitimasChanged({ page: this.currentPageVitimas, itemsPerPage: this.pageSize });
    }
    else {
      let index = this.indiciados.indexOf(model);
      this.indiciados.splice(index, 1);
      this.currentPageIndiciados = this.getCurrentPage(this.currentPageIndiciados, this.indiciados.length);
      this.pageIndiciadosChanged({ page: this.currentPageIndiciados, itemsPerPage: this.pageSize });
    }
  }

  openModal(event, model: any) {
    const config = {
      initialState: {
        model: null
      },
      class: 'modal-lg modal-dialog-centered',
      ignoreBackdropClick: true,
      backdrop: true
    }

    if (event.target.dataset.name == 'btnVitima') {
      config.initialState.model = model == undefined ? new Vitima(this.procedimentoId) : model;
      this.modalRef = this.modalService.show(CadastroVitimaComponent, config);
    }
    else {
      config.initialState.model = model == undefined ? new Indiciado(this.procedimentoId) : model;
      this.modalRef = this.modalService.show(CadastroIndiciadoComponent, config);
    }
  }

  openModalExcluir(event, model: any) {
    const config = {
      initialState: {
        model: model,
        uri: ''
      },
      class: 'modal-dialog-centered',
      ignoreBackdropClick: true,
      backdrop: true
    }
    if (event.target.dataset.name == 'btnVitima') {
      config.initialState.uri = 'api/vitima/';
    }
    else {
      config.initialState.uri = 'api/indiciado/';
    }
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, config);
  }

  pageVitimasChanged(event: PageChangedEvent) {
    this.currentPageVitimas = event.page;
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedVitimas = this.vitimas.slice(startItem, endItem);
  }

  pageIndiciadosChanged(event: PageChangedEvent) {
    this.currentPageIndiciados = event.page;
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedIndiciados = this.indiciados.slice(startItem, endItem);
  }

  private getCurrentPage(currentPage: number, arrayLength: number) {
    let calc = arrayLength / this.pageSize;

    if (currentPage < calc) {
      return currentPage + 1;
    }
    else if (currentPage > calc && (arrayLength % this.pageSize) == 0) {
      return currentPage - 1;
    }
    return currentPage;
  }

}
