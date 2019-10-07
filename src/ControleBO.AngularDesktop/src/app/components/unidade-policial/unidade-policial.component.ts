import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { UnidadePolicial } from '../../models/unidade-policial';
import { ToastrService } from 'ngx-toastr';
import { MessageService } from '../../services/message.service';
import { UnidadePolicialService } from '../../services/unidade-policial.service';
import { IMessage, Action } from '../../models/message';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { CadastroUnidadePolicialComponent } from '../cadastro-unidade-policial/cadastro-unidade-policial.component';
import { UserManagerService } from '../../services/user-manager.service';

@Component({
  selector: 'app-unidade-policial',
  templateUrl: './unidade-policial.component.html',
  styleUrls: ['./unidade-policial.component.scss']
})
export class UnidadePolicialComponent implements OnInit {

  private modalRef: BsModalRef;
  private subscription: Subscription;
  isLoadingUltimaAtualizacao: boolean = false;
  ultimaAtualizacao: string;

  unidadesPoliciais: UnidadePolicial[] = [];
  returnedUnidadesPoliciais: UnidadePolicial[] = [];

  pageSize = 10;
  currentPage = 1;

  get canEdit() {
    return this.userManager.canEdit();
  }

  constructor(private modalService: BsModalService,
    private toastr: ToastrService,
    private messageService: MessageService,
    private unidadePolicialService: UnidadePolicialService,
    private userManager: UserManagerService) {
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.getUnidadesPoliciais();
    this.getUltimaAtualizacao();
  }

  private getUnidadesPoliciais() {
    this.unidadePolicialService.getAll().subscribe(res => {
      if (res.data) {
        this.unidadesPoliciais = res.data;
        this.returnedUnidadesPoliciais = this.unidadesPoliciais.slice(0, this.pageSize);
      }
    }, () => this.toastr.error('Falha ao buscar as unidades policiais'));
  }

  private getUltimaAtualizacao() {
    this.isLoadingUltimaAtualizacao = true;

    this.unidadePolicialService.getUltimaAtualizacao()
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
          if (message.errors) {
            message.errors.forEach(m => this.toastr.error(m));
          }
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

  private addToTable(unidadePolicial: UnidadePolicial) {
    this.unidadesPoliciais.push(unidadePolicial);
    this.pageChanged({ itemsPerPage: this.pageSize, page: this.pageSize });
  }

  private removeFromTable(unidadePolicial: UnidadePolicial) {
    let index = this.unidadesPoliciais.findIndex(x => x.id == unidadePolicial.id);
    this.unidadesPoliciais.splice(index, 1);
    this.pageChanged({ itemsPerPage: this.pageSize, page: this.pageSize });
  }

  private updateTable(unidadePolicial: UnidadePolicial) {
    let index = this.unidadesPoliciais.findIndex(x => x.id == unidadePolicial.id);
    this.unidadesPoliciais[index] = unidadePolicial;
  }

  openModal(unidadePolicial: UnidadePolicial) {
    const initialState = {
      unidadePolicial: unidadePolicial == undefined ? new UnidadePolicial() : unidadePolicial
    };
    this.modalRef = this.modalService.show(CadastroUnidadePolicialComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  openModalExcluir(unidadePolicial: UnidadePolicial) {
    const initialState = {
      model: unidadePolicial,
      uri: 'api/unidade-policial/'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  pageChanged(event: PageChangedEvent) {
    this.currentPage = event.page;
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedUnidadesPoliciais = this.unidadesPoliciais.slice(startItem, endItem);
  }

}
