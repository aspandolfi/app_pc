import { Component, OnInit } from '@angular/core';
import { Indiciado } from 'src/app/models/indiciado';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { IndiciadoService } from 'src/app/services/indiciado.service';
import { Message, Action } from 'src/app/models/message';
import { MunicipioService } from 'src/app/services/municipio.service';
import { Municipio } from 'src/app/models/municipio';
import { ToastrService } from 'ngx-toastr';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead/public_api';
import { Result } from 'src/app/models/result';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-cadastro-indiciado',
  templateUrl: './cadastro-indiciado.component.html',
  styleUrls: ['./cadastro-indiciado.component.scss']
})
export class CadastroIndiciadoComponent implements OnInit {

  model: Indiciado;

  submitted = false;
  isLoadingMunicipios = false;
  isNoResultNaturalidade = false;

  municipios: Municipio[] = [];
  naturalidade: Municipio;
  naturalidadeSelected: string;


  constructor(public modalRef: BsModalRef,
    private indiciadoService: IndiciadoService,
    private messageService: MessageService,
    private municipioService: MunicipioService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.getMunicipios();
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

  save() {
    this.submitted = true;

    if (this.model.id) {
      this.indiciadoService.update(this.model)
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
      this.indiciadoService.create(this.model)
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

}
