import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProcedimentoService } from 'src/app/services/procedimento.service';
import { ToastrService } from 'ngx-toastr';
import { ProcedimentoList, Procedimento } from 'src/app/models/procedimento';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { UserManagerService } from '../../services/user-manager.service';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { MessageService } from 'src/app/services/message.service';
import { IMessage, Action } from 'src/app/models/message';

@Component({
  selector: 'app-procedimento',
  templateUrl: './procedimento.component.html',
  styleUrls: ['./procedimento.component.scss']
})
export class ProcedimentoComponent implements OnInit, OnDestroy {

  bsConfig: Partial<BsDatepickerConfig> = { containerClass: 'theme-default' };

  private modalRef: BsModalRef;
  private subscription: Subscription;

  searchDe: Date;
  searchAte: Date;

  searchFilter: string = '';
  ultimaAtualizacao: string;
  returnedProcedimentos: ProcedimentoList[] = [];
  procedimentos: ProcedimentoList[] = [];
  isLoading: boolean;
  isLoadingUltimaAtualizacao: boolean;

  pageSize = 10;
  currentPage = 1;

  get canEdit() {
    return this.userManager.canEdit();
  }

  get isAdmin() {
    return this.userManager.isAdmin();
  }

  constructor(private procedimentoService: ProcedimentoService,
    private modalService: BsModalService,
    private messageService: MessageService,
    private toastr: ToastrService,
    private localeService: BsLocaleService,
    private userManager: UserManagerService) {
    this.localeService.use('pt-br');
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.getProcedimentos();
    this.getUltimaAtualizacao();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private getProcedimentos() {
    this.isLoading = true;

    this.procedimentoService.getAll()
      .subscribe(res => {
        this.procedimentos = this.setProcedimentos(res.data);
        this.returnedProcedimentos = this.procedimentos.slice(0, this.pageSize);
      },
        () => this.toastr.error("Falha ao carregar os procedimentos."))
      .add(() => this.isLoading = false);
  }

  private getUltimaAtualizacao() {
    this.isLoadingUltimaAtualizacao = true;

    this.procedimentoService.getUltimaAtualizacao()
      .subscribe(res => {
        this.ultimaAtualizacao = res.data;
      },
        () => this.toastr.error("Falha ao carregar a última atualização."))
      .add(() => this.isLoadingUltimaAtualizacao = false);
  }

  private setProcedimentos(values: ProcedimentoList[]) {
    let items: ProcedimentoList[] = [];

    if (values) {
      for (let value of values) {
        items.push(new ProcedimentoList(value));
      }
    }
    return items;
  }

  openModalExcluir(procedimento: Procedimento) {
    const initialState = {
      propertyToDescribe: 'numeroProcessual',
      model: procedimento,
      uri: 'api/procedimento/'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
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
    if (message.action == Action.Removed) {
      this.removeFromTable(message.data);
    }
  }

  private removeFromTable(procedimento: Procedimento) {
    let index = this.procedimentos.findIndex(x => x.id == procedimento.id);
    this.procedimentos.splice(index, 1);
    this.pageChanged({ itemsPerPage: this.pageSize, page: this.currentPage });
  }

  pageChanged(event: PageChangedEvent) {
    this.currentPage = event.page;
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedProcedimentos = this.procedimentos.slice(startItem, endItem);
  }

  onSearchDeChange(value: Date): void {
    this.searchDe = value;
    this.searchByDate(this.searchDe, this.searchAte);
  }

  onSearchAteChange(value: Date): void {
    this.searchAte = value;
    this.searchByDate(this.searchDe, this.searchAte);
  }

  searchByDate(de?: Date, ate?: Date) {
    if (de && ate) {
      this.returnedProcedimentos = this.procedimentos.filter(x => x.dataInsercao >= de && x.dataInsercao <= ate);
    }
    else if (de && !ate) {
      this.returnedProcedimentos = this.procedimentos.filter(x => x.dataInsercao >= de);
    }
    else if (!de && ate) {
      this.returnedProcedimentos = this.procedimentos.filter(x => x.dataInsercao <= ate);
    }
    else {
      this.returnedProcedimentos = this.procedimentos.slice(0, this.pageSize);
    }
  }

  limparFiltros() {
    this.searchFilter = '';
    this.searchDe = null;
    this.searchAte = null;
    this.returnedProcedimentos = this.procedimentos.slice(0, this.pageSize);
  }
}
