import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { MessageService } from 'src/app/services/message.service';
import { BaseService } from 'src/app/services/base.service';
import { Message, Action } from 'src/app/models/message';

@Component({
  selector: 'app-confirmar-exclusao',
  templateUrl: './confirmar-exclusao.component.html',
  styleUrls: ['./confirmar-exclusao.component.scss']
})
export class ConfirmarExclusaoComponent implements OnInit {

  model: any;
  uri: string;
  propertyToDescribe: string;

  submitted: boolean = false;

  constructor(public modalRef: BsModalRef,
    private messageService: MessageService,
    private baseService: BaseService) { }

  ngOnInit() {
  }

  excluir(id: number) {
    this.submitted = true;

    this.baseService.delete(this.uri + id)
      .subscribe(result => {
        result.data = this.model;
        this.messageService.send(new Message(result, Action.Removed));
        this.modalRef.hide();
      },
        error => this.messageService.send(new Message(error)),
        () => this.submitted = false);
  }

  getDescribe() {
    if (this.model.hasOwnProperty(this.propertyToDescribe)) {
      return this.model[this.propertyToDescribe];
    }

    if (this.model.hasOwnProperty('descricao')) {
      return this.model['descricao'];
    }

    return this.model['nome'];
  }

}
