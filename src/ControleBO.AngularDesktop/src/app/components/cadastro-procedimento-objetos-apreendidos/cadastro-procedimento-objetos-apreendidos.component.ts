import { Component, OnInit } from '@angular/core';
import { ObjetoApreendido } from '../../models/objeto-apreendido';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { ObjetoApreendidoService } from '../../services/objeto-apreendido.service';
import { Result } from '../../models/result';

@Component({
  selector: 'app-cadastro-procedimento-objetos-apreendidos',
  templateUrl: './cadastro-procedimento-objetos-apreendidos.component.html',
  styleUrls: ['./cadastro-procedimento-objetos-apreendidos.component.css']
})
export class CadastroProcedimentoObjetosApreendidosComponent implements OnInit {

  private procedimentoId: number;

  private submitted: boolean = false;

  private objeto: ObjetoApreendido = { id: 0, descricao: '', procedimentoId: 0 };

  constructor(private route: ActivatedRoute,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private objetoApreendidoService: ObjetoApreendidoService) { }

  ngOnInit() {
    this.spinner.show();

    this.route.parent.paramMap.subscribe(params => {
      this.procedimentoId = +params.get('id');
      this.getObjetos(this.procedimentoId);
    });
  }

  private getObjetos(procedimentoId: number) {
    this.objetoApreendidoService.getByProcedimento(procedimentoId).subscribe(res => {
      if (res.data) {
        this.objeto = res.data;
      }
    },
      (error: Result<any>) => {
        this.toastr.error('Falha ao buscar os objetos apreendidos.');
        error.errors.forEach(m => this.toastr.error(m));
        this.spinner.hide();
      },
      () => this.spinner.hide());
  }

  private salvar() {

    if (!this.objeto.descricao) {
      this.toastr.warning('O campo Objetos é obrigatório.');
      return;
    }

    this.objeto.procedimentoId = this.procedimentoId;

    if (!this.objeto.procedimentoId) {
      this.toastr.warning('Por favor verifique se o procedimento é válido.');
      return;
    }

    this.submitted = true;

    if (this.objeto.id) {
      this.objetoApreendidoService.update(this.objeto).subscribe(res => {
        this.objeto = res.data;
        this.toastr.success(res.message);
      },
        (error: Result<any>) => {
          this.toastr.error(error.message);
          error.errors.forEach(m => this.toastr.error(m));
        },
        () => this.submitted = false);
    }
    else {
      this.objetoApreendidoService.create(this.objeto).subscribe(res => {
        this.objeto = res.data;
        this.toastr.success(res.message);
      },
        (error: Result<any>) => {
          this.toastr.error(error.message);
          error.errors.forEach(m => this.toastr.error(m));
        },
        () => this.submitted = false);
    }
  }

}
