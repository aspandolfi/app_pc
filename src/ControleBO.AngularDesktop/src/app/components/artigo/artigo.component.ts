import { Component, OnInit, OnDestroy } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { Artigo } from 'src/app/models/artigo';
import { MessageService } from 'src/app/services/message.service';
import { ToastrService } from 'ngx-toastr';
import { IMessage } from 'src/app/models/message';
import { CadastroArtigoComponent } from '../cadastro-artigo/cadastro-artigo.component';
import { ConfirmarExclusaoComponent } from '../confirmar-exclusao/confirmar-exclusao.component';

@Component({
  selector: 'app-artigo',
  templateUrl: './artigo.component.html',
  styleUrls: ['./artigo.component.css']
})
export class ArtigoComponent implements OnInit, OnDestroy {

  private modalRef: BsModalRef;
  private subscription: Subscription;

  artigos: Artigo[] = [
    { id: 1, descricao: 'Descrição 1' },
    { id: 2, descricao: 'Descrição 2' },
    { id: 3, descricao: 'Descrição 3' },
    { id: 4, descricao: 'Descrição 4' },
    { id: 5, descricao: 'Descrição 5' }
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

  addToTable(artigo: Artigo) {
    this.artigos.push(artigo);
  }

  removeFromTable(artigo: Artigo) {
    let index = this.artigos.indexOf(artigo);
    this.artigos.splice(index, 1);
  }

  openModal(artigo: Artigo) {
    const initialState = {
      artigo: artigo == undefined ? new Artigo() : artigo
    };
    this.modalRef = this.modalService.show(CadastroArtigoComponent, { initialState, class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

  openModalExcluir(artigo: Artigo) {
    const initialState = {
      model: artigo,
      uri: 'api/artigo/'
    };
    this.modalRef = this.modalService.show(ConfirmarExclusaoComponent, { initialState, class: 'modal-dialog-centered', ignoreBackdropClick: true, backdrop: true });
  }

}
