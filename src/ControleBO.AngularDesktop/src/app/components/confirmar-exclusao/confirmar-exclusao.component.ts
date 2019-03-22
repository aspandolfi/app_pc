import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { MessageService } from 'src/app/services/message.service';
import { BaseService } from 'src/app/services/base.service';
import { Message } from 'src/app/models/message';

@Component({
  selector: 'app-confirmar-exclusao',
  templateUrl: './confirmar-exclusao.component.html',
  styleUrls: ['./confirmar-exclusao.component.css']
})
export class ConfirmarExclusaoComponent implements OnInit {

  model: any;
  uri: string;

  submitted: boolean = false;

  constructor(public modalRef: BsModalRef,
    private messageService: MessageService,
    private baseService: BaseService) { }

  ngOnInit() {
  }

  excluir(id: number) {
    //this.baseService.delete(this.uri + id)
    //  .subscribe(result => {
    //    this.messageService.send(new Message(result.message, result.data));
    //  }, error => this.messageService.send(new Message(error, null, true)));
    this.submitted = true;
    setTimeout(() => {
      this.messageService.send(new Message("Excluído com sucesso!", this.model));
      this.submitted = false;
    }, 3000);
  }

}
