import { Component, OnInit } from '@angular/core';
import { Municipio } from 'src/app/models/municipio';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { MunicipioService } from 'src/app/services/municipio.service';
import { MessageService } from 'src/app/services/message.service';
import { ToastrService } from 'ngx-toastr';
import { Action, Message } from '../../models/message';
import { Result } from '../../models/result';

@Component({
  selector: 'app-cadastro-municipio',
  templateUrl: './cadastro-municipio.component.html',
  styleUrls: ['./cadastro-municipio.component.css']
})
export class CadastroMunicipioComponent implements OnInit {

  municipio: Municipio;
  private submitted = false;

  constructor(public modalRef: BsModalRef,
    private municipioService: MunicipioService,
    private messageService: MessageService,
    private toastr: ToastrService) { }

  ngOnInit() {
  }

  save() {
    this.submitted = true;

    if (this.municipio.id) {
      this.municipioService.update(this.municipio)
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
      this.municipioService.create(this.municipio)
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
