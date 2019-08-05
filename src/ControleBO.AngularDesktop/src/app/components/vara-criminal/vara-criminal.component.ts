import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { VaraCriminal } from '../../models/vara-criminal';
import { MessageService } from '../../services/message.service';
import { ToastrService } from 'ngx-toastr';
import { VaraCriminalService } from '../../services/vara-criminal.service';
import { IMessage, Action } from '../../models/message';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { PageChangedEvent } from 'ngx-bootstrap/pagination/public_api';
import { CadastroVaraCriminalComponent } from '../cadastro-vara-criminal/cadastro-vara-criminal.component';
import { UserManagerService } from '../../services/user-manager.service';

@Component({
  selector: 'app-vara-criminal',
  templateUrl: './vara-criminal.component.html',
  styleUrls: ['./vara-criminal.component.scss']
})
export class VaraCriminalComponent implements OnInit {

  private modalRef: BsModalRef;
  private subscription: Subscription;
  isLoadingUltimaAtualizacao: boolean = false;
  ultimaAtualizacao: string;

  varas: VaraCriminal[] = [];
  returnedVaras: VaraCriminal[] = [];

  pageSize = 10;
  currentPage = 1;

  get canEdit() {
    return this.userManager.canEdit();
  }

  constructor(private modalService: BsModalService,
    private messageService: MessageService,
    private toastr: ToastrService,
    private varaCriminalService: VaraCriminalService,
    private userManager: UserManagerService) {
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.getVaras();
    this.getUltimaAtualizacao();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private getVaras() {
    this.varaCriminalService.getAll().subscribe(res => {
      if (res.data) {
        this.varas = res.data;
        this.returnedVaras = this.varas.slice(0, this.pageSize);
      }
    }, () => this.toastr.error('Falha ao buscar as Varas Criminais'));
  }

  private getUltimaAtualizacao() {
    this.isLoadingUltimaAtualizacao = true;

    this.varaCriminalService.getUltimaAtualizacao()
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

  private addToTable(vara: VaraCriminal) {
    this.varas.push(vara);
  }

  private removeFromTable(vara: VaraCriminal) {
    let index = this.varas.indexOf(vara);
    this.varas.splice(index, 1);
  }

  private updateTable(vara: VaraCriminal) {
    let index = this.varas.findIndex(x => x.id == vara.id);
    this.varas[index] = vara;
  }

  openModal(vara: VaraCriminal) {
    const initialState = {
      vara: vara == undefined ? new VaraCriminal() : vara
    };
    this.modalRef = this.modalService.show(CadastroVaraCriminalComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  openModalExcluir(vara: VaraCriminal) {
    const initialState = {
      model: vara,
      uri: 'api/vara-criminal/'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  pageChanged(event: PageChangedEvent) {
    this.currentPage = event.page;
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedVaras = this.varas.slice(startItem, endItem);
  }

}
