import { Component, OnInit, OnDestroy } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { TipoSituacao } from '../../models/tipo-situacao';
import { ToastrService } from 'ngx-toastr';
import { MessageService } from '../../services/message.service';
import { TipoSiutacaoService } from '../../services/tipo-siutacao.service';
import { IMessage, Action } from '../../models/message';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { CadastroTipoSituacaoComponent } from '../cadastro-tipo-situacao/cadastro-tipo-situacao.component';
import { Situacao } from '../../models/situacao';
import { SituacaoService } from '../../services/situacao.service';
import { UserManagerService } from '../../services/user-manager.service';

@Component({
  selector: 'app-tipo-situacao',
  templateUrl: './tipo-situacao.component.html',
  styleUrls: ['./tipo-situacao.component.scss']
})
export class TipoSituacaoComponent implements OnInit, OnDestroy {

  private modalRef: BsModalRef;
  private subscription: Subscription;
  isLoadingUltimaAtualizacao: boolean = false;
  ultimaAtualizacao: string;

  situacoes: Situacao[] = [];
  selectedSituacaoId: number = 1;

  tipos: TipoSituacao[] = [];
  returnedTipos: TipoSituacao[] = [];

  tipo: TipoSituacao;

  pageSize = 10;
  currentPage = 1;

  get canEdit() {
    return this.userManager.canEdit();
  }

  constructor(private modalService: BsModalService,
    private toastr: ToastrService,
    private messageService: MessageService,
    private tipoSituacaoService: TipoSiutacaoService,
    private situacaoService: SituacaoService,
    private userManager: UserManagerService) {
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.getSituacoes();
  }

  private getSituacoes() {
    this.situacaoService.getAll().subscribe(res => {
      if (res.data) {
        this.situacoes = res.data;
      }
    }, () => this.toastr.error('Falha ao buscar as situações.'));
  }

  private getUltimaAtualizacao(situacaoId: number) {
    this.isLoadingUltimaAtualizacao = true;

    this.tipoSituacaoService.getUltimaAtualizacao(situacaoId)
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

  private addToTable(tipoSituacao: TipoSituacao) {
    this.tipos.push(tipoSituacao);
    this.pageChanged({ itemsPerPage: this.pageSize, page: this.currentPage });
  }

  private removeFromTable(tipoSituacao: TipoSituacao) {
    let index = this.tipos.findIndex(x => x.id == tipoSituacao.id);
    this.tipos.splice(index, 1);
    this.pageChanged({ itemsPerPage: this.pageSize, page: this.currentPage });
  }

  private updateTable(tipoSituacao: TipoSituacao) {
    let index = this.tipos.findIndex(x => x.id == tipoSituacao.id);
    this.tipos[index] = tipoSituacao;
  }

  openModal(tipoSituacao: TipoSituacao) {
    const initialState = {
      tipoSituacao: tipoSituacao == undefined ? new TipoSituacao(this.selectedSituacaoId) : tipoSituacao
    };
    this.modalRef = this.modalService.show(CadastroTipoSituacaoComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  openModalExcluir(tipoSituacao: TipoSituacao) {
    const initialState = {
      model: tipoSituacao,
      uri: 'api/tipo-situacao/'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  pageChanged(event: PageChangedEvent) {
    this.currentPage = event.page;
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedTipos = this.tipos.slice(startItem, endItem);
  }

  onSituacaoChange(event) {
    this.selectedSituacaoId = event.id;
    this.tipos = this.situacoes.find(x => x.id == this.selectedSituacaoId).tipos;
    if (this.tipos) {
      this.returnedTipos = this.tipos.slice(0, this.pageSize);
      this.getUltimaAtualizacao(this.selectedSituacaoId);
    }
  }

}
