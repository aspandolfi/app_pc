import { Component, OnInit } from '@angular/core';
import { Artigo } from 'src/app/models/artigo';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ArtigoService } from 'src/app/services/artigo.service';
import { MessageService } from 'src/app/services/message.service';
import { Result } from '../../models/result';
import { ToastrService } from 'ngx-toastr';
import { Action, Message } from '../../models/message';

@Component({
  selector: 'app-cadastro-artigo',
  templateUrl: './cadastro-artigo.component.html',
  styleUrls: ['./cadastro-artigo.component.scss']
})
export class CadastroArtigoComponent implements OnInit {

  artigo: Artigo;

  submitted = false;

  constructor(public modalRef: BsModalRef,
    private artigoService: ArtigoService,
    private messageService: MessageService,
    private toastr: ToastrService) { }

  ngOnInit() {
  }

  save() {
    this.submitted = true;

    if (this.artigo.id) {
      this.artigoService.update(this.artigo)
        .subscribe(res => {
          this.messageService.send(new Message(res, Action.Updated));
          this.modalRef.hide();
        }, (error: Result<any>) => {
          if (error.errors) {
            error.errors.forEach(m => this.toastr.warning(m));
          }
          this.toastr.error(error.message);
        }, () => {
          this.submitted = false;
        });
    }
    else {
      this.artigoService.create(this.artigo)
        .subscribe(res => {
          this.messageService.send(new Message(res, Action.Created));
          this.modalRef.hide();
        }, (error: Result<any>) => {
          if (error.errors) {
            error.errors.forEach(m => this.toastr.warning(m));
          }
          this.toastr.error(error.message);
        }, () => {
          this.submitted = false;
        });
    }
  }

}
