import { Component, OnInit, OnDestroy } from '@angular/core';
import { ObjetoApreendido } from '../../models/objeto-apreendido';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ObjetoApreendidoService } from '../../services/objeto-apreendido.service';
import { Result } from '../../models/result';
import { UserManagerService } from '../../services/user-manager.service';
import { Subscription } from 'rxjs';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { MessageService } from 'src/app/services/message.service';
import { IMessage, Action } from 'src/app/models/message';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { CadastroObjetosComponent } from '../cadastro-objetos/cadastro-objetos.component';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';

@Component({
  selector: 'app-cadastro-procedimento-objetos-apreendidos',
  templateUrl: './cadastro-procedimento-objetos-apreendidos.component.html',
  styleUrls: ['./cadastro-procedimento-objetos-apreendidos.component.scss']
})
export class CadastroProcedimentoObjetosApreendidosComponent implements OnInit, OnDestroy {

  private procedimentoId: number;

  objetos: ObjetoApreendido[] = [];
  returnedObjetos: ObjetoApreendido[] = [];
  pageSize = 7;
  currentPage = 1;

  private subscription: Subscription;

  private modalRef: BsModalRef;

  get canEdit() {
    return this.userManager.canEdit();
  }

  constructor(private route: ActivatedRoute,
    private toastr: ToastrService,
    private objetoApreendidoService: ObjetoApreendidoService,
    private userManager: UserManagerService,
    private messageService: MessageService,
    private modalService: BsModalService) {
    this.onReceiveMessage();
  }

  ngOnInit() {

    this.route.parent.paramMap.subscribe(params => {
      this.procedimentoId = +params.get('id');
      this.getObjetos(this.procedimentoId);
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private getObjetos(procedimentoId: number) {
    this.objetoApreendidoService.getByProcedimento(procedimentoId).subscribe(res => {
      if (res.data) {
        this.objetos = this.setObjetos(res.data);
        this.returnedObjetos = this.objetos.slice(0, this.pageSize);
      }
    },
      (error: Result<any>) => {
        this.toastr.error('Falha ao buscar os objetos apreendidos.');
        if (error.errors) {
          error.errors.forEach(m => this.toastr.error(m));
        }
      });
  }

  private setObjetos(values: ObjetoApreendido[]) {
    let items: ObjetoApreendido[] = [];

    if (values) {
      for (let value of values) {
        items.push(new ObjetoApreendido(value.procedimentoId, value));
      }
    }
    return items;
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
    else if (message.action == Action.Updated) {
      this.updateToTable(message.data);
    }
    else if (message.action == Action.Removed) {
      this.removeFromTable(message.data);
    }
  }

  private addToTable(model: any) {
    this.objetos.push(model);
    this.currentPage = this.getCurrentPage(this.currentPage, this.objetos.length);
    this.pageChanged({ page: this.currentPage, itemsPerPage: this.pageSize });
  }

  private updateToTable(model: any) {
    let index = this.objetos.findIndex(x => x.id == model.id);
    this.objetos[index] = model;
    this.currentPage = this.getCurrentPage(this.currentPage, this.objetos.length);
    this.pageChanged({ page: this.currentPage, itemsPerPage: this.pageSize });
  }

  private removeFromTable(model: any) {
    let index = this.objetos.findIndex(x => x.id == model.id);
    this.objetos.splice(index, 1);
    this.currentPage = this.getCurrentPage(this.currentPage, this.objetos.length);
    this.pageChanged({ page: this.currentPage, itemsPerPage: this.pageSize });
  }

  openModal(model: any) {
    const config = {
      initialState: {
        model: null
      },
      class: 'modal-lg modal-dialog-centered',
      ignoreBackdropClick: true,
      backdrop: true
    }
    config.initialState.model = new ObjetoApreendido(this.procedimentoId, model);
    this.modalRef = this.modalService.show(CadastroObjetosComponent, config);
  }

  openModalExcluir(model: any) {
    const config = {
      initialState: {
        model: model,
        uri: 'api/objeto-apreendido/'
      },
      class: 'modal-dialog-centered',
      ignoreBackdropClick: true,
      backdrop: true
    }
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, config);
  }

  pageChanged(event: PageChangedEvent) {
    this.currentPage = event.page;
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedObjetos = this.objetos.slice(startItem, endItem);
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
