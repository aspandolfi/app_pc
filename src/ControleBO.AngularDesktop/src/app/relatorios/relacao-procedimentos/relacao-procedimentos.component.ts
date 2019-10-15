import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { RelatorioService } from '../../services/relatorio.service';
import { ToastrService } from 'ngx-toastr';
import { Result } from '../../models/result';
import { SituacaoService } from '../../services/situacao.service';
import { Situacao } from '../../models/situacao';
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
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-relacao-procedimentos',
  templateUrl: './relacao-procedimentos.component.html',
  styleUrls: ['./relacao-procedimentos.component.scss']
})
export class RelacaoProcedimentosComponent implements OnInit {

  bsConfig: Partial<BsDatepickerConfig> = { containerClass: 'theme-default' };

  situacoes: Situacao[] = [];
  selectedSituacaoId: number = null;

  private dt: DataTables.DataTables;

  searchDe: Date = null;
  searchAte: Date = null;

  constructor(private relatorioService: RelatorioService,
    private situacaoService: SituacaoService,
    private toastr: ToastrService,
    private localeService: BsLocaleService,
    private chRef: ChangeDetectorRef) {
    this.localeService.use('pt-br');
  }

  ngOnInit() {
    this.getSituacoes();
  }

  private getSituacoes() {
    this.situacaoService.getAll().subscribe(res => {
      if (res.data) {
        this.situacoes = res.data;
      }
    }, () => this.toastr.error('Falha ao buscar as situações.'));
  }

  private getRelacaoProcedimentos(situacaoId?: number, de?: Date, ate?: Date) {

    this.relatorioService.getRelacaoProcedimentos(situacaoId, de, ate).subscribe(res => {
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
              download: 'open',
              extension: '.pdf',
              text: 'Exportar para PDF',
              title: 'Controle de Procedimentos Criminais - Relação de Procedimentos',
              filename: 'Relacao de Procedimentos',
              pageSize: 'LEGAL',
              orientation: 'landscape',
              customize: function (doc) {
                //doc.content[1].table.widths = Array(doc.content[1].table.body[0].length + 1).join('*').split('');
                //doc.defaultStyle.alignment = 'left';
              }
            }
          ],
          dom: 'Bfrtip',
          language: {
            url: 'assets/Portuguese-Brasil.json'
          }
        };

        if (this.dt) {
          this.dt = new $.fn.dataTable.Api('#relacao-procedimenos');
          this.dt.settings().clear();
          this.dt.settings().rows.add(res.data.dataSet);
          this.dt.draw();
        }
        else {
          this.dt = $('#relacao-procedimenos').DataTable(dtOptions);
        }

      }
    }, (error: Result<any>) => {
      this.toastr.error(error.message);
    });
  }

  onSituacaoChange(event) {
    this.selectedSituacaoId = event.id;
    this.getRelacaoProcedimentos(this.selectedSituacaoId, this.searchDe, this.searchAte);
  }

  onSearchDeChange(value: Date): void {
    this.searchDe = value;
    this.getRelacaoProcedimentos(this.selectedSituacaoId, this.searchDe, this.searchAte);
  }

  onSearchAteChange(value: Date): void {
    this.searchAte = value;
    this.getRelacaoProcedimentos(this.selectedSituacaoId, this.searchDe, this.searchAte);
  }
}
