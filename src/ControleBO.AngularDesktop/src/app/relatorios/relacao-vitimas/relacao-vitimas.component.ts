import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { RelatorioService } from '../../services/relatorio.service';
import { ToastrService } from 'ngx-toastr';
import { Result } from '../../models/result';
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

@Component({
  selector: 'app-relacao-vitimas',
  templateUrl: './relacao-vitimas.component.html',
  styleUrls: ['./relacao-vitimas.component.css']
})
export class RelacaoVitimasComponent implements OnInit {

  constructor(private relatorioService: RelatorioService,
    private toastr: ToastrService,
    private chRef: ChangeDetectorRef) { }

  ngOnInit() {
    this.getRelacaoVitimas();
  }

  private getRelacaoVitimas() {

    this.relatorioService.getRelacaoVitimas().subscribe(res => {
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
            {
              extend: 'pdf',
              extension: '.pdf',
              text: 'Exportar para PDF',
              title: 'Controle de Procedimentos Criminais - Relação de Vítimas',
              filename: 'Relacao de Vitimas.pdf',
              pageSize: 'A4',
              customize: function (doc) {
                doc.content[1].table.widths = Array(doc.content[1].table.body[0].length + 1).join('*').split('');
              }
            }
          ],
          dom: 'Bfrtip',
          language: {
            url: 'assets/Portuguese-Brasil.json'
          }
        };

        $('#relacao-vitimas').DataTable(dtOptions);
      }
    }, (error: Result<any>) => {
      this.toastr.error(error.message);
    });
  }

}
