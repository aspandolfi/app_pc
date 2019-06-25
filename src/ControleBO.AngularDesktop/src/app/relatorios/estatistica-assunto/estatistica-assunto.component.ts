import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import * as $ from 'jquery';
import 'pdfmake';
import pdfMake from "pdfmake/build/pdfmake";
import pdfFonts from "pdfmake/build/vfs_fonts";
pdfMake.vfs = pdfFonts.pdfMake.vfs;
import 'datatables.net';
import 'datatables.net-buttons';
import 'datatables.net-buttons/js/buttons.print';
import 'datatables.net-buttons/js/buttons.html5';
import 'datatables.net-bs4';
import 'datatables.net-buttons-bs4';
import { RelatorioService } from '../../services/relatorio.service';
import { ToastrService } from 'ngx-toastr';
import { Result } from '../../models/result';

@Component({
  selector: 'app-estatistica-assunto',
  templateUrl: './estatistica-assunto.component.html',
  styleUrls: ['./estatistica-assunto.component.css']
})
export class EstatisticaAssuntoComponent implements OnInit {

  constructor(private relatorioService: RelatorioService,
    private toastr: ToastrService,
    private chRef: ChangeDetectorRef) { }

  ngOnInit() {
    this.getEstatisticaPorAssunto();
  }

  private getEstatisticaPorAssunto() {

    this.relatorioService.getEstatisticaPorAssunto().subscribe(res => {
      if (res.data) {

        this.chRef.detectChanges();

        const dtOptions: any = {
          columns: res.data.headers,
          data: res.data.dataSet,
          paging: false,
          info: false,
          lengthChange: false,
          searching: false,
          ordering: false,
          columnDefs: [
            { className: 'dt-body-center', targets: '_all' }
          ],
          buttons: [
            'pdf'
          ],
          dom: 'Bfrtip'
        };

        $('#estatistica-assunto').DataTable(dtOptions);
      }
    }, (error: Result<any>) => {
      this.toastr.error(error.message);
    });
  }

}
