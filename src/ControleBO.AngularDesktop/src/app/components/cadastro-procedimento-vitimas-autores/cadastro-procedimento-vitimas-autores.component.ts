import { Component, OnInit, Input } from '@angular/core';
import { Vitima } from 'src/app/models/vitima';
import { VitimaService } from 'src/app/services/vitima.service';
import { ToastrService } from 'ngx-toastr';
import { MessageService } from 'src/app/services/message.service';
import { Indiciado } from 'src/app/models/indiciado';
import { IndiciadoService } from 'src/app/services/indiciado.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cadastro-procedimento-vitimas-autores',
  templateUrl: './cadastro-procedimento-vitimas-autores.component.html',
  styleUrls: ['./cadastro-procedimento-vitimas-autores.component.css']
})
export class CadastroProcedimentoVitimasAutoresComponent implements OnInit {

  private procedimentoId: any;

  private isLoadingVitimas: boolean;
  private isLoadingIndiciados: boolean;

  private vitimas: Vitima[] = [];
  private indiciados: Indiciado[] = [];

  constructor(private vitimaService: VitimaService,
    private indiciadoService: IndiciadoService,
    private toastr: ToastrService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.route.parent.paramMap.subscribe(params => {
      this.procedimentoId = params.get('id')
      console.log(this.procedimentoId);
      console.log('work!!!');
      this.getVitimas(this.procedimentoId);
      this.getIndiciados(this.procedimentoId);
    });
  }

  private getVitimas(procedimentoId) {
    this.isLoadingVitimas = true;
    this.vitimaService.getAllFiltered(procedimentoId).subscribe(res =>
      this.vitimas = res.data,
      () => this.toastr.error('Falha ao buscar as Vítimas.'),
      () => this.isLoadingVitimas = false);
  }

  private getIndiciados(procedimentoId) {
    this.isLoadingIndiciados = true;
    this.indiciadoService.getAllFiltered(procedimentoId).subscribe(res =>
      this.indiciados = res.data,
      () => this.toastr.error('Falha ao buscar os Indiciados.'),
      () => this.isLoadingIndiciados = false);
  }

}
