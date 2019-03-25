import { Component, OnInit } from '@angular/core';
import { Artigo } from 'src/app/models/artigo';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ArtigoService } from 'src/app/services/artigo.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-cadastro-artigo',
  templateUrl: './cadastro-artigo.component.html',
  styleUrls: ['./cadastro-artigo.component.css']
})
export class CadastroArtigoComponent implements OnInit {

  artigo: Artigo;

  submitted = false;

  constructor(public modalRef: BsModalRef, private artigoService: ArtigoService, private messageService: MessageService) { }

  ngOnInit() {
  }

  save() { }

}
