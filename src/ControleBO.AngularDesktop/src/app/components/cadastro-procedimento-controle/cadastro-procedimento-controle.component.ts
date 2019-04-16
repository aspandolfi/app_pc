import { Component, OnInit, Input } from '@angular/core';
import { Procedimento } from 'src/app/models/procedimento';

@Component({
  selector: 'app-cadastro-procedimento-controle',
  templateUrl: './cadastro-procedimento-controle.component.html',
  styleUrls: ['./cadastro-procedimento-controle.component.css']
})
export class CadastroProcedimentoControleComponent implements OnInit {

  @Input("procedimento") procedimento: Procedimento;

  constructor() { }

  ngOnInit() {
  }

}
