import { Component, OnInit } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ObjetoApreendido } from 'src/app/models/objeto-apreendido';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ObjetoApreendidoService } from 'src/app/services/objeto-apreendido.service';
import { MessageService } from 'src/app/services/message.service';
import { UserManagerService } from 'src/app/services/user-manager.service';
import { ToastrService } from 'ngx-toastr';
import { Result } from 'src/app/models/result';
import { Message, Action } from 'src/app/models/message';

@Component({
  selector: 'app-cadastro-objetos',
  templateUrl: './cadastro-objetos.component.html',
  styleUrls: ['./cadastro-objetos.component.scss']
})
export class CadastroObjetosComponent implements OnInit {

  bsConfig: Partial<BsDatepickerConfig> = { containerClass: 'theme-default' };

  model: ObjetoApreendido;

  submitted = false;

  constructor(public modalRef: BsModalRef,
    private objetoService: ObjetoApreendidoService,
    private messageService: MessageService,
    private toastr: ToastrService,
    private userManager: UserManagerService) { }

  ngOnInit() {
  }

  canEdit() {
    return this.userManager.canEdit();
  }

  save() {

    if (!this.model.descricao) {
      this.toastr.warning('O campo Descrição é obrigatório.');
      return;
    }

    this.submitted = true;

    if (this.model.id) {
      this.objetoService.update(this.model)
        .subscribe(res => {
          this.messageService.send(new Message(res, Action.Updated));
          this.modalRef.hide();
        }, (res: Result<any>) => {
          if (res.errors) {
            res.errors.forEach(m => this.toastr.warning(m));
          }
          this.toastr.error(res.message);
          this.submitted = false;
        }, () => {
          this.submitted = false;
        });
    }
    else {
      this.objetoService.create(this.model)
        .subscribe(res => {
          this.messageService.send(new Message(res, Action.Created));
          this.modalRef.hide();
        }, (res: Result<any>) => {
          if (res.errors) {
            res.errors.forEach(m => this.toastr.warning(m));
          }
          this.toastr.error(res.message);
          this.submitted = false;
        }, () => {
          this.submitted = false;
        });
    }
  }

}
