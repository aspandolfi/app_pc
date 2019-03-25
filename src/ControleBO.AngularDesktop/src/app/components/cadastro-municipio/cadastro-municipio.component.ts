import { Component, OnInit } from '@angular/core';
import { Municipio } from 'src/app/models/municipio';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { MunicipioService } from 'src/app/services/municipio.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-cadastro-municipio',
  templateUrl: './cadastro-municipio.component.html',
  styleUrls: ['./cadastro-municipio.component.css']
})
export class CadastroMunicipioComponent implements OnInit {

  municipio: Municipio;
  submitted = false;

  constructor(public modalRef: BsModalRef, private municipioService: MunicipioService, private messageService: MessageService) { }

  ngOnInit() {
  }

  save() { }

}
