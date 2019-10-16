import { Component, OnInit } from '@angular/core';
import { UnidadePolicial } from '../../models/unidade-policial';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { UnidadePolicialService } from '../../services/unidade-policial.service';
import { MessageService } from '../../services/message.service';
import { ToastrService } from 'ngx-toastr';
import { Message, Action } from '../../models/message';
import { Result } from '../../models/result';

@Component({
  selector: 'app-cadastro-unidade-policial',
  templateUrl: './cadastro-unidade-policial.component.html',
  styleUrls: ['./cadastro-unidade-policial.component.scss']
})
export class CadastroUnidadePolicialComponent implements OnInit {

  unidadePolicial: UnidadePolicial;

  submitted = false;

  constructor(public modalRef: BsModalRef,
    private unidadePolicialService: UnidadePolicialService,
    private messageService: MessageService,
    private toastr: ToastrService) { }

  ngOnInit() {
  }

  save() {
    this.submitted = true;

    if (this.unidadePolicial.id) {
      this.unidadePolicialService.update(this.unidadePolicial)
        .subscribe(res => {
          this.messageService.send(new Message(res, Action.Updated));
          this.modalRef.hide();
        }, (error: Result<any>) => {
          if (error.errors) {
            error.errors.forEach(m => this.toastr.warning(m));
          }
          this.toastr.error(error.message);
        }).add(() => this.submitted = false);
    }
    else {
      this.unidadePolicialService.create(this.unidadePolicial)
        .subscribe(res => {
          this.messageService.send(new Message(res, Action.Created));
          this.modalRef.hide();
        }, (error: Result<any>) => {
          if (error.errors) {
            error.errors.forEach(m => this.toastr.warning(m));
          }
          this.toastr.error(error.message);
        }).add(() => this.submitted = false);
    }
  }

}
