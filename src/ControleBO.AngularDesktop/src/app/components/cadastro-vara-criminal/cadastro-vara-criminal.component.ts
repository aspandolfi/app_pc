import { Component, OnInit } from '@angular/core';
import { VaraCriminal } from '../../models/vara-criminal';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { VaraCriminalService } from '../../services/vara-criminal.service';
import { MessageService } from '../../services/message.service';
import { ToastrService } from 'ngx-toastr';
import { Message, Action } from '../../models/message';
import { Result } from '../../models/result';

@Component({
  selector: 'app-cadastro-vara-criminal',
  templateUrl: './cadastro-vara-criminal.component.html',
  styleUrls: ['./cadastro-vara-criminal.component.css']
})
export class CadastroVaraCriminalComponent implements OnInit {

  vara: VaraCriminal;

  submitted = false;

  constructor(public modalRef: BsModalRef,
    private varaCriminalService: VaraCriminalService,
    private messageService: MessageService,
    private toastr: ToastrService) { }

  ngOnInit() {
  }

  save() {
    this.submitted = true;

    if (this.vara.id) {
      this.varaCriminalService.update(this.vara)
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
      this.varaCriminalService.create(this.vara)
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
