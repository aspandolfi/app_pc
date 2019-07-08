import { Component, OnInit } from '@angular/core';
import { Vitima } from 'src/app/models/vitima';
import { VitimaService } from 'src/app/services/vitima.service';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Message, Action } from 'src/app/models/message';
import { Municipio } from 'src/app/models/municipio';
import { ToastrService } from 'ngx-toastr';
import { MunicipioService } from 'src/app/services/municipio.service';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead/public_api';
import { MessageService } from 'src/app/services/message.service';
import { Result } from 'src/app/models/result';

@Component({
  selector: 'app-cadastro-vitima',
  templateUrl: './cadastro-vitima.component.html',
  styleUrls: ['./cadastro-vitima.component.scss']
})
export class CadastroVitimaComponent implements OnInit {

  model: Vitima;

  submitted = false;
  isLoadingMunicipios = false;
  isNoResultNaturalidade = false;

  municipios: Municipio[] = [];
  naturalidade: Municipio;
  naturalidadeSelected: string;

  constructor(public modalRef: BsModalRef,
    private vitimaService: VitimaService,
    private messageService: MessageService,
    private municipioService: MunicipioService,
    private toastr: ToastrService) {
  }

  ngOnInit() {
    this.getMunicipios();
  }

  save() {

    if (!this.naturalidade) {
      this.toastr.error('Município inválido. Por favor selecione um item válido.');
      return;
    }
    this.model.naturalidadeId = this.naturalidade.id;

    this.submitted = true;

    if (this.model.id) {
      this.vitimaService.update(this.model)
        .subscribe(res => {
          this.messageService.send(new Message(res, Action.Updated));
          this.modalRef.hide();
        }, (error: Result<any>) => {
          error.errors.forEach(m => this.toastr.warning(m));
          this.toastr.error(error.message);
        }, () => {
          this.submitted = false;
        });
    }
    else {
      this.vitimaService.create(this.model)
        .subscribe(res => {
          this.messageService.send(new Message(res, Action.Created));
          this.modalRef.hide();
        }, (error: Result<any>) => {
          error.errors.forEach(m => this.toastr.warning(m));
          this.toastr.error(error.message);
        }, () => {
          this.submitted = false;
        });
    }
  }

  private getMunicipios() {
    this.isLoadingMunicipios = true;

    this.municipioService.getAll().subscribe(res =>
      this.municipios = res.data, // Success
      () => this.toastr.error("Falha ao buscar os Municípios."), // Fail
      () => this.isLoadingMunicipios = false // Completed
    ).add(() => {
      this.naturalidade = this.municipios.find(x => x.id == this.model.naturalidadeId);
      if (this.naturalidade) {
        this.naturalidadeSelected = this.naturalidade.nome;
      }
    });
  }

  onSelectNaturalidade(event: TypeaheadMatch) {
    if (!this.municipios.find(x => x.id == event.item.id)) {
      this.isNoResultNaturalidade = true;
      this.naturalidade = null;
      return;
    }
    this.isNoResultNaturalidade = false;
    this.naturalidade = event.item;
  }

  naturalidadeNoResults(event: boolean): void {
    this.isNoResultNaturalidade = event;
  }

}
