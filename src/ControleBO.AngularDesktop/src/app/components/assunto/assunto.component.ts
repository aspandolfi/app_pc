import { Component, OnInit, OnDestroy } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { Assunto } from '../../models/assunto';
import { MessageService } from '../../services/message.service';
import { ToastrService } from 'ngx-toastr';
import { AssuntoService } from '../../services/assunto.service';
import { IMessage, Action } from '../../models/message';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { CadastroAssuntoComponent } from '../cadastro-assunto/cadastro-assunto.component';
import { UserManagerService } from '../../services/user-manager.service';

@Component({
  selector: 'app-assunto',
  templateUrl: './assunto.component.html',
  styleUrls: ['./assunto.component.scss']
})
export class AssuntoComponent implements OnInit, OnDestroy {

  private modalRef: BsModalRef;
  private subscription: Subscription;
  isLoadingUltimaAtualizacao: boolean = false;
  ultimaAtualizacao: string;

  assuntos: Assunto[] = [];
  returnedAssuntos: Assunto[] = [];

  pageSize = 10;
  currentPage = 1;

  get canEdit() {
    return this.userManager.isAdmin();
  }

  constructor(private modalService: BsModalService,
    private messageService: MessageService,
    private toastr: ToastrService,
    private assuntoService: AssuntoService,
    private userManager: UserManagerService) {
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.getAssuntos();
    this.getUltimaAtualizacao();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private getAssuntos() {
    this.assuntoService.getAll().subscribe(res => {
      if (res.data) {
        this.assuntos = res.data;
        this.returnedAssuntos = this.assuntos.slice(0, this.pageSize);
      }
    }, () => this.toastr.error('Falha ao buscar os assuntos'));
  }

  private getUltimaAtualizacao() {
    this.isLoadingUltimaAtualizacao = true;

    this.assuntoService.getUltimaAtualizacao()
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

  private addToTable(assunto: Assunto) {
    this.assuntos.push(assunto);
    this.pageChanged({ itemsPerPage: this.pageSize, page: this.currentPage });
  }

  private removeFromTable(assunto: Assunto) {
    let index = this.assuntos.findIndex(x => x.id == assunto.id);
    this.assuntos.splice(index, 1);
    this.pageChanged({ itemsPerPage: this.pageSize, page: this.currentPage });
  }

  private updateTable(assunto: Assunto) {
    let index = this.assuntos.findIndex(x => x.id == assunto.id);
    this.assuntos[index] = assunto;
  }

  openModal(assunto: Assunto) {
    const initialState = {
      assunto: assunto == undefined ? new Assunto() : assunto
    };
    this.modalRef = this.modalService.show(CadastroAssuntoComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  openModalExcluir(assunto: Assunto) {
    const initialState = {
      model: assunto,
      uri: 'api/assunto/'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  pageChanged(event: PageChangedEvent) {
    this.currentPage = event.page;
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedAssuntos = this.assuntos.slice(startItem, endItem);
  }

}
