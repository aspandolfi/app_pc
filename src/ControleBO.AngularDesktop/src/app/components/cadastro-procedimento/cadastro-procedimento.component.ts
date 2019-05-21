import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cadastro-procedimento',
  templateUrl: './cadastro-procedimento.component.html',
  styleUrls: ['./cadastro-procedimento.component.css']
})
export class CadastroProcedimentoComponent implements OnInit, AfterViewInit {

  private procedimentoId: string;

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.paramMap.subscribe(
      params => {
        this.procedimentoId = params.get('id');
        if (this.procedimentoId) {
          console.log('com id', this.procedimentoId);
          this.router.navigate(['cadastro-procedimento', { outlets: { procedimento: null } }]);
          this.router.navigate(['cadastro-procedimento', this.procedimentoId, { outlets: { procedimento: 'controle' } }]);
        }
        else {
          console.log('sem id');
          this.router.navigate(['cadastro-procedimento', { outlets: { procedimento: null } }]);
          this.router.navigate(['cadastro-procedimento', { outlets: { procedimento: 'controle' } }]);
        }
      }
    );
  }

  ngAfterViewInit(): void {
  }

}
