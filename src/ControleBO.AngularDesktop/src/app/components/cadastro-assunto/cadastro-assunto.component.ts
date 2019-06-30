import { Component, OnInit } from '@angular/core';
import { Assunto } from '../../models/assunto';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { MessageService } from '../../services/message.service';
import { ToastrService } from 'ngx-toastr';
import { AssuntoService } from '../../services/assunto.service';
import { Message, Action } from '../../models/message';
import { Result } from '../../models/result';

@Component({
  selector: 'app-cadastro-assunto',
  templateUrl: './cadastro-assunto.component.html',
  styleUrls: ['./cadastro-assunto.component.css']
})
export class CadastroAssuntoComponent implements OnInit {

  assunto: Assunto;

  private submitted = false;

  constructor(public modalRef: BsModalRef,
    private assuntoService: AssuntoService,
    private messageService: MessageService,
    private toastr: ToastrService) { }

  ngOnInit() {
  }

  private save() {
    if (this.assunto.id) {
      this.assuntoService.update(this.assunto)
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
      this.assuntoService.create(this.assunto)
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
