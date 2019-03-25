import { Component, OnInit, OnDestroy } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { Municipio } from 'src/app/models/municipio';
import { MessageService } from 'src/app/services/message.service';
import { ToastrService } from 'ngx-toastr';
import { IMessage } from 'src/app/models/message';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';
import { CadastroMunicipioComponent } from '../cadastro-municipio/cadastro-municipio.component';

@Component({
  selector: 'app-municipio',
  templateUrl: './municipio.component.html',
  styleUrls: ['./municipio.component.css']
})
export class MunicipioComponent implements OnInit, OnDestroy {

  private modalRef: BsModalRef;
  private subscription: Subscription;

  municipios: Municipio[] = [
    { id: 1, nome: 'Descrição 1', cep: '', uf: '' },
    { id: 2, nome: 'Descrição 2', cep: '', uf: '' },
    { id: 3, nome: 'Descrição 3', cep: '', uf: '' },
    { id: 4, nome: 'Descrição 4', cep: '', uf: '' },
    { id: 5, nome: 'Descrição 5', cep: '', uf: '' }
  ]

  constructor(private modalService: BsModalService, private messageService: MessageService, private toastr: ToastrService) {
    this.onReceiveMessage();
  }

  ngOnInit() {
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  onReceiveMessage() {
    this.subscription = this.messageService.messageListener$.subscribe(
      message => {
        if (!message.isError) {
          this.toastr.success(message.text);
          this.postReceiveMessage(message);
        }
        else {
          this.toastr.error(message.text);
        }
        this.modalRef.hide();
      });
  }

  postReceiveMessage(message: IMessage) {
    if (message.text.includes('Cadastrado')) {
      this.addToTable(message.data);
    }
    else if (message.text.includes('Excluído')) {
      this.removeFromTable(message.data);
    }
  }

  addToTable(municipio: Municipio) {
    this.municipios.push(municipio);
  }

  removeFromTable(municipio: Municipio) {
    let index = this.municipios.indexOf(municipio);
    this.municipios.splice(index, 1);
  }

  openModal(municipio: Municipio) {
    const initialState = {
      municipio: municipio == undefined ? new Municipio() : municipio
    };
    this.modalRef = this.modalService.show(CadastroMunicipioComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  openModalExcluir(municipio: Municipio) {
    const initialState = {
      model: municipio,
      uri: 'api/municipio/'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

}
