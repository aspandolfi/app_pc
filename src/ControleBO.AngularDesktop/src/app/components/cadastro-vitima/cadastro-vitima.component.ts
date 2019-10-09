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
import { UserManagerService } from '../../services/user-manager.service';
import { Observable } from 'rxjs';
import { mergeMap } from 'rxjs/operators';

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

  vitimasDataSource: Observable<any>;
  vitimaSelected: string;

  typeaheadLoadingVitimas: boolean;

  get canEdit() {
    return this.userManager.canEdit();
  }

  constructor(public modalRef: BsModalRef,
    private vitimaService: VitimaService,
    private messageService: MessageService,
    private municipioService: MunicipioService,
    private toastr: ToastrService,
    private userManager: UserManagerService) {
    this.initVitimasDataSource();
  }

  ngOnInit() {
    this.getMunicipios();

    if (this.model.id) {
      this.vitimaSelected = this.model.nome;
    }
  }

  initVitimasDataSource() {
    this.vitimasDataSource = Observable.create((observer: any) => {
      observer.next(this.vitimaSelected);
    })
      .pipe(
        mergeMap((token: string) => this.vitimaService.getByText(token))
      );
  }

  save() {

    //if (!this.naturalidade) {
    //  this.toastr.error('Município inválido. Por favor selecione um item válido.');
    //  return;
    //}
    this.model.naturalidadeId = this.naturalidade ? this.naturalidade.id : undefined;
    this.model.nome = this.model.nome ? this.model.nome : this.vitimaSelected;

    this.submitted = true;

    if (this.model.id) {
      this.vitimaService.update(this.model)
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
      this.vitimaService.create(this.model)
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

  changeTypeaheadLoadingVitimas(e: boolean) {
    this.typeaheadLoadingVitimas = e;
  }

  typeaheadOnSelectVitima(e: TypeaheadMatch) {
    this.model.nome = e.value;
  }

}
