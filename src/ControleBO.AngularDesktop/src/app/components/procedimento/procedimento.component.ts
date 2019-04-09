import { Component, OnInit } from '@angular/core';
import { ProcedimentoService } from 'src/app/services/procedimento.service';
import { Datatablejs } from 'src/app/models/datatablejs';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-procedimento',
  templateUrl: './procedimento.component.html',
  styleUrls: ['./procedimento.component.css']
})
export class ProcedimentoComponent implements OnInit {

  private datatablejs: Datatablejs;
  private isLoading: boolean;

  dtOptions: DataTables.Settings = {};

  constructor(private procedimentoService: ProcedimentoService, private toastr: ToastrService, private spinner: NgxSpinnerService) {
  }

  ngOnInit() {
    this.spinner.show();
    this.getProcedimentosAsDatatable();
  }

  getProcedimentosAsDatatable() {
    this.isLoading = true;

    this.procedimentoService.getAll()
      .subscribe(res => {
        this.datatablejs = res.data;
        this.mountDatatable(this.datatablejs);
      },
        () => this.toastr.error("Falha ao carregar os procedimentos."),
        () => this.spinner.hide());
  }

  private mountDatatable(datatablejs: Datatablejs) {
    this.dtOptions.columns = datatablejs.headers;
    this.dtOptions.data = datatablejs.dataSet;
  }

}
