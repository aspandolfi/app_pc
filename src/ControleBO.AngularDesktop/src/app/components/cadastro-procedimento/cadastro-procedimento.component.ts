import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cadastro-procedimento',
  templateUrl: './cadastro-procedimento.component.html',
  styleUrls: ['./cadastro-procedimento.component.scss']
})
export class CadastroProcedimentoComponent implements OnInit, AfterViewInit {

  procedimentoId: string;

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.paramMap.subscribe(
      params => {
        this.procedimentoId = params.get('id');
        if (this.procedimentoId) {
          //this.router.navigate(['cadastro-procedimento', { outlets: { procedimento: null } }]);
          this.router.navigate(['cadastro-procedimento', this.procedimentoId, { outlets: { procedimento: 'controle' } }]);
        }
        else {
          //this.router.navigate(['cadastro-procedimento', { outlets: { procedimento: null } }]);
          this.router.navigate(['cadastro-procedimento', { outlets: { procedimento: 'controle' } }]);
        }
      }
    );
  }

  ngAfterViewInit(): void {
  }

}
