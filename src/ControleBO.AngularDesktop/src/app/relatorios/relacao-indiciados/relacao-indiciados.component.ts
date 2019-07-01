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
  selector: 'app-relacao-indiciados',
  templateUrl: './relacao-indiciados.component.html',
  styleUrls: ['./relacao-indiciados.component.css']
})
export class RelacaoIndiciadosComponent implements OnInit {

  constructor(private relatorioService: RelatorioService,
    private toastr: ToastrService,
    private chRef: ChangeDetectorRef) { }

  ngOnInit() {
    this.getRelacaoIndiciados();
  }

  private getRelacaoIndiciados() {

    this.relatorioService.getRelacaoIndiciados().subscribe(res => {
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

        $('#relacao-indiciados').DataTable(dtOptions);
      }
    }, (error: Result<any>) => {
      this.toastr.error(error.message);
    });
  }

}
