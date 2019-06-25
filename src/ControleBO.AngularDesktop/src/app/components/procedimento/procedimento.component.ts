import { Component, OnInit } from '@angular/core';
import { ProcedimentoService } from 'src/app/services/procedimento.service';
import { ToastrService } from 'ngx-toastr';
import { ProcedimentoList } from 'src/app/models/procedimento';

@Component({
  selector: 'app-procedimento',
  templateUrl: './procedimento.component.html',
  styleUrls: ['./procedimento.component.css']
})
export class ProcedimentoComponent implements OnInit {

  private searchFilter: string = '';
  private ultimaAtualizacao: string;
  private _procedimentos: ProcedimentoList[] = [];
  private isLoading: boolean;
  private isLoadingUltimaAtualizacao: boolean;

  private page = 1;
  private pageSize = 10;

  get totalItems() {
    return this._procedimentos.length;
  }

  constructor(private procedimentoService: ProcedimentoService,
    private toastr: ToastrService) {
  }

  get procedimentos(): ProcedimentoList[] {
    return this._procedimentos
      .map((procedimento, i) => ({ id: i + 1, ...procedimento }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

  ngOnInit() {
    this.getProcedimentos();
    this.getUltimaAtualizacao();
  }

  pageChanged(event: any): void {
    this.page = event.page;
    this.procedimentos;
  }

  getProcedimentos() {
    this.isLoading = true;

    this.procedimentoService.getAll()
      .subscribe(res => {
        this._procedimentos = res.data;
      },
        () => this.toastr.error("Falha ao carregar os procedimentos."),
        () => {
          this.isLoading = false;
        });
  }

  getUltimaAtualizacao() {
    this.isLoadingUltimaAtualizacao = true;

    this.procedimentoService.getUltimaAtualizacao()
      .subscribe(res => {
        this.ultimaAtualizacao = res.data;
      },
        () => this.toastr.error("Falha ao carregar a última atualização."),
        () => this.isLoadingUltimaAtualizacao = false);
  }
}
