import { Component, OnInit, OnDestroy } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { CadastroTipoProcedimentoComponent } from '../cadastro-tipo-procedimento/cadastro-tipo-procedimento.component';
import { TipoProcedimento } from 'src/app/models/tipo-procedimento';
import { ToastrService } from 'ngx-toastr';
import { MessageService } from 'src/app/services/message.service';
import { Subscription } from 'rxjs';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { IMessage, Action } from 'src/app/models/message';
import { TipoProcedimentoService } from '../../services/tipo-procedimento.service';
import { PageChangedEvent } from 'ngx-bootstrap/pagination/public_api';

@Component({
  selector: 'app-tipo-procedimento',
  templateUrl: './tipo-procedimento.component.html',
  styleUrls: ['./tipo-procedimento.component.css']
})
export class TipoProcedimentoComponent implements OnInit, OnDestroy {

  private modalRef: BsModalRef;
  private subscription: Subscription;
  private isLoadingUltimaAtualizacao: boolean = false;
  private ultimaAtualizacao: string;

  private tipos: TipoProcedimento[] = [];
  private returnedTipos: TipoProcedimento[] = [];

  private pageSize = 10;
  private currentPage = 1;

  constructor(private modalService: BsModalService,
    private toastr: ToastrService,
    private messageService: MessageService,
    private tipoProcedimentoService: TipoProcedimentoService) {
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.getTiposProcedimento();
    this.getUltimaAtualizacao();
  }

  private getTiposProcedimento() {
    this.tipoProcedimentoService.getAll().subscribe(res => {
      if (res.data) {
        this.tipos = res.data;
        this.returnedTipos = this.tipos.slice(0, this.pageSize);
      }
    }, () => this.toastr.error('Falha ao buscar os assuntos'));
  }

  private getUltimaAtualizacao() {
    this.isLoadingUltimaAtualizacao = true;

    this.tipoProcedimentoService.getUltimaAtualizacao()
      .subscribe(res => {
        this.ultimaAtualizacao = res.data;
      },
        () => this.toastr.error("Falha ao carregar a última atualização."),
        () => this.isLoadingUltimaAtualizacao = false);
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
    else if (message.action == Action.Updated) {
      this.updateTable(message.data);
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private addToTable(tipoProcedimento: TipoProcedimento) {
    this.tipos.push(tipoProcedimento);
  }

  private removeFromTable(tipoProcedimento: TipoProcedimento) {
    let index = this.tipos.indexOf(tipoProcedimento);
    this.tipos.splice(index, 1);
  }

  private updateTable(tipoProcedimento: TipoProcedimento) {
    let index = this.tipos.findIndex(x => x.id == tipoProcedimento.id);
    this.tipos[index] = tipoProcedimento;
  }

  private openModal(tipoProcedimento: TipoProcedimento) {
    const initialState = {
      tipoProcedimento: tipoProcedimento == undefined ? new TipoProcedimento() : tipoProcedimento
    };
    this.modalRef = this.modalService.show(CadastroTipoProcedimentoComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  private openModalExcluir(tipoProcedimento: TipoProcedimento) {
    const initialState = {
      model: tipoProcedimento,
      uri: 'api/tipo-procedimento/'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  private pageChanged(event: PageChangedEvent) {
    this.currentPage = event.page;
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedTipos = this.tipos.slice(startItem, endItem);
  }

}
