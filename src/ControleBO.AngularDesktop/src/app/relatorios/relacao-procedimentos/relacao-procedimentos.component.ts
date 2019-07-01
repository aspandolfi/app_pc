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

@Component({
  selector: 'app-relacao-procedimentos',
  templateUrl: './relacao-procedimentos.component.html',
  styleUrls: ['./relacao-procedimentos.component.css']
})
export class RelacaoProcedimentosComponent implements OnInit {

  private situacoes: Situacao[] = [];
  private selectedSituacaoId: number;

  private dt: DataTables.DataTables;

  constructor(private relatorioService: RelatorioService,
    private situacaoService: SituacaoService,
    private toastr: ToastrService,
    private chRef: ChangeDetectorRef) { }

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

  private getRelacaoProcedimentos(situacaoId: number) {

    this.relatorioService.getRelacaoProcedimentos(situacaoId).subscribe(res => {
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

  private onSituacaoChange(event) {
    this.selectedSituacaoId = event.id;
    this.getRelacaoProcedimentos(this.selectedSituacaoId);
  }

}