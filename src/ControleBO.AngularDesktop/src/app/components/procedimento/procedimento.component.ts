import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import 'datatables.net';
import 'datatables.net-dt';
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

  constructor(private procedimentoService: ProcedimentoService, private toastr: ToastrService, private spinner: NgxSpinnerService) {
    this.getProcedimentosAsDatatable();
  }

  ngOnInit() {
  }

  getProcedimentosAsDatatable() {
    this.isLoading = true;

    this.procedimentoService.getAll()
      .subscribe(res => {
        this.datatablejs = res.data;
        this.mountDatatable(this.datatablejs);
      },
        () => this.toastr.error("Falha ao carregar os procedimentos."));
  }

  private mountDatatable(datatablejs: Datatablejs) {
    $(document).ready(() => {
      $('#procedimentos').DataTable({
        columns: datatablejs.headers,
        serverSide: true,
        processing: true,
        ajax: this.procedimentoService.url + '/datatablequery'
      });
    });
  }

}
