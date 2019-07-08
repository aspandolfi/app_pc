import { Component, OnInit, OnDestroy, AfterViewInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { Municipio } from 'src/app/models/municipio';
import { MessageService } from 'src/app/services/message.service';
import { ToastrService } from 'ngx-toastr';
import { IMessage, Action } from 'src/app/models/message';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { CadastroMunicipioComponent } from '../cadastro-municipio/cadastro-municipio.component';
import { MunicipioService } from '../../services/municipio.service';
import { PageChangedEvent } from 'ngx-bootstrap/pagination/public_api';

@Component({
  selector: 'app-municipio',
  templateUrl: './municipio.component.html',
  styleUrls: ['./municipio.component.scss']
})
export class MunicipioComponent implements OnInit, OnDestroy, AfterViewInit {

  ngAfterViewInit(): void {

  }

  private modalRef: BsModalRef;
  private subscription: Subscription;
  isLoadingUltimaAtualizacao: boolean = false;
  ultimaAtualizacao: string;

  municipios: Municipio[] = []
  returnedMunicipios: Municipio[] = [];

  pageSize = 10;
  currentPage = 1;

  constructor(private modalService: BsModalService,
    private messageService: MessageService,
    private toastr: ToastrService,
    private municipioService: MunicipioService) {
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.getMunicipios();
    this.getUltimaAtualizacao();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private getMunicipios() {
    this.municipioService.getAll().subscribe(res => {
      if (res.data) {
        this.municipios = res.data;
        this.returnedMunicipios = this.municipios.slice(0, this.pageSize);
      }
    }, () => this.toastr.error('Falha ao buscar os municípios'));
  }

  private getUltimaAtualizacao() {
    this.isLoadingUltimaAtualizacao = true;

    this.municipioService.getUltimaAtualizacao()
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

  private addToTable(municipio: Municipio) {
    this.municipios.push(municipio);
  }

  private updateTable(municipio: Municipio) {
    let index = this.municipios.findIndex(x => x.id == municipio.id);
    this.municipios[index] = municipio;
  }

  private removeFromTable(municipio: Municipio) {
    let index = this.municipios.indexOf(municipio);
    this.municipios.splice(index, 1);
  }

  openModal(municipio: Municipio) {
    const initialState = {
      municipio: municipio == undefined ? new Municipio() : municipio
    };
    this.modalRef = this.modalService.show(CadastroMunicipioComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  openModalExcluir(municipio: Municipio) {
    const initialState = {
      model: municipio,
      uri: 'api/municipio/'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  pageChanged(event: PageChangedEvent) {
    this.currentPage = event.page;
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedMunicipios = this.municipios.slice(startItem, endItem);
  }

}
