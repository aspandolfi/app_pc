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
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-estatistica-assunto',
  templateUrl: './estatistica-assunto.component.html',
  styleUrls: ['./estatistica-assunto.component.scss']
})
export class EstatisticaAssuntoComponent implements OnInit {

  bsConfig: Partial<BsDatepickerConfig> = { containerClass: 'theme-default' };

  searchDe: Date = null;
  searchAte: Date = null;

  private dt: DataTables.DataTables;

  constructor(private relatorioService: RelatorioService,
    private toastr: ToastrService,
    private localeService: BsLocaleService,
    private chRef: ChangeDetectorRef) {
    this.localeService.use('pt-br');
  }

  ngOnInit() {
    this.getEstatisticaPorAssunto();
  }

  private getEstatisticaPorAssunto(de?: Date, ate?: Date) {

    this.relatorioService.getEstatisticaPorAssunto(de, ate).subscribe(res => {
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
              extend: 'pdfHtml5',
              extension: '.pdf',
              download: 'open',
              text: 'Exportar para PDF',
              title: 'Controle de Procedimentos Criminais - Estatística por Assunto',
              filename: 'Estatistica por assunto',
              pageSize: 'A4',
              customize: function (doc) {
                doc.content[1].table.widths = Array(doc.content[1].table.body[0].length + 1).join('*').split('');
                doc.defaultStyle.alignment = 'center';
              }
            }
          ],
          dom: 'Bfrtip',
          language: {
            url: 'assets/Portuguese-Brasil.json'
          }
        };

        if (this.dt) {
          this.dt = new $.fn.dataTable.Api('#estatistica-assunto');
          this.dt.settings().clear();
          this.dt.settings().rows.add(res.data.dataSet);
          this.dt.draw();
        }
        else {
          this.dt = $('#estatistica-assunto').DataTable(dtOptions);
        }
      }
    }, (error: Result<any>) => {
      this.toastr.error(error.message);
    });
  }

  onSearchDeChange(value: Date): void {
    this.searchDe = value;
    this.getEstatisticaPorAssunto(this.searchDe, this.searchAte);
  }

  onSearchAteChange(value: Date): void {
    this.searchAte = value;
    this.getEstatisticaPorAssunto(this.searchDe, this.searchAte);
  }

}
