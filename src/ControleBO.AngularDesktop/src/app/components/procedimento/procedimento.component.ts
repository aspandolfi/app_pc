import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProcedimentoService } from 'src/app/services/procedimento.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { IProcedimentoViewModel } from 'src/app/models/procedimento';

@Component({
  selector: 'app-procedimento',
  templateUrl: './procedimento.component.html',
  styleUrls: ['./procedimento.component.css']
})
export class ProcedimentoComponent implements OnInit {

  searchFilter: string;
  ultimaAtualizacao: string;
  private _procedimentos: IProcedimentoViewModel[] = [];
  private isLoading: boolean;
  private isLoadingUltimaAtualizacao: boolean;

  private page = 1;
  private pageSize = 10;
  private totalItems = this._procedimentos.length;

  constructor(private procedimentoService: ProcedimentoService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) {
  }

  get procedimentos(): IProcedimentoViewModel[] {
    return this._procedimentos
      .map((procedimento, i) => ({ id: i + 1, ...procedimento }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

  ngOnInit() {
    //this.spinner.show();
    //this.getProcedimentos();
    //this.getUltimaAtualizacao();
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
        () => this.spinner.hide());
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
