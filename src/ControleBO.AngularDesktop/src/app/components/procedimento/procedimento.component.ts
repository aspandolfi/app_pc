import { Component, OnInit } from '@angular/core';
import { ProcedimentoService } from 'src/app/services/procedimento.service';
import { ToastrService } from 'ngx-toastr';
import { ProcedimentoList } from 'src/app/models/procedimento';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-procedimento',
  templateUrl: './procedimento.component.html',
  styleUrls: ['./procedimento.component.css']
})
export class ProcedimentoComponent implements OnInit {

  bsConfig: Partial<BsDatepickerConfig> = { containerClass: 'theme-default' };

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

  constructor(private procedimentoService: ProcedimentoService,
    private toastr: ToastrService,
    private localeService: BsLocaleService) {
    this.localeService.use('pt-br');
  }

  ngOnInit() {
    this.getProcedimentos();
    this.getUltimaAtualizacao();
  }

  private getProcedimentos() {
    this.isLoading = true;

    this.procedimentoService.getAll()
      .subscribe(res => {
        this.procedimentos = this.setProcedimentos(res.data);
        this.returnedProcedimentos = this.procedimentos.slice(0, this.pageSize);
      },
        () => this.toastr.error("Falha ao carregar os procedimentos."),
        () => {
          this.isLoading = false;
        });
  }

  private getUltimaAtualizacao() {
    this.isLoadingUltimaAtualizacao = true;

    this.procedimentoService.getUltimaAtualizacao()
      .subscribe(res => {
        this.ultimaAtualizacao = res.data;
      },
        () => this.toastr.error("Falha ao carregar a última atualização."),
        () => this.isLoadingUltimaAtualizacao = false);
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
