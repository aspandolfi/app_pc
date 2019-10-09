import { Component, OnInit, OnDestroy } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { Artigo } from 'src/app/models/artigo';
import { MessageService } from 'src/app/services/message.service';
import { ToastrService } from 'ngx-toastr';
import { IMessage, Action } from 'src/app/models/message';
import { CadastroArtigoComponent } from '../cadastro-artigo/cadastro-artigo.component';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { ArtigoService } from '../../services/artigo.service';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { UserManagerService } from '../../services/user-manager.service';

@Component({
  selector: 'app-artigo',
  templateUrl: './artigo.component.html',
  styleUrls: ['./artigo.component.scss']
})
export class ArtigoComponent implements OnInit, OnDestroy {

  private modalRef: BsModalRef;
  private subscription: Subscription;
  isLoadingUltimaAtualizacao: boolean = false;
  ultimaAtualizacao: string;

  artigos: Artigo[] = [];
  returnedArtigos: Artigo[] = [];

  pageSize = 10;
  currentPage = 1;

  get canEdit() {
    return this.userManager.isAdmin();
  }

  constructor(private modalService: BsModalService,
    private messageService: MessageService,
    private toastr: ToastrService,
    private artigoService: ArtigoService,
    private userManager: UserManagerService) {
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.getArtigos();
    this.getUltimaAtualizacao();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private getArtigos() {
    this.artigoService.getAll().subscribe(res => {
      if (res.data) {
        this.artigos = res.data;
        this.returnedArtigos = this.artigos.slice(0, this.pageSize);
      }
    }, () => this.toastr.error('Falha ao buscar os artigos'));
  }

  private getUltimaAtualizacao() {
    this.isLoadingUltimaAtualizacao = true;

    this.artigoService.getUltimaAtualizacao()
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

  private addToTable(artigo: Artigo) {
    this.artigos.push(artigo);
    this.pageChanged({ itemsPerPage: this.pageSize, page: this.currentPage });
  }

  private removeFromTable(artigo: Artigo) {
    let index = this.artigos.findIndex(x => x.id == artigo.id);
    this.artigos.splice(index, 1);
    this.pageChanged({ itemsPerPage: this.pageSize, page: this.currentPage });
  }

  private updateTable(artigo: Artigo) {
    let index = this.artigos.findIndex(x => x.id == artigo.id);
    this.artigos[index] = artigo;
  }

  openModal(artigo: Artigo) {
    const initialState = {
      artigo: artigo == undefined ? new Artigo() : artigo
    };
    this.modalRef = this.modalService.show(CadastroArtigoComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  openModalExcluir(artigo: Artigo) {
    const initialState = {
      model: artigo,
      uri: 'api/artigo/'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  pageChanged(event: PageChangedEvent) {
    this.currentPage = event.page;
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedArtigos = this.artigos.slice(startItem, endItem);
  }

}
