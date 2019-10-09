import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Datatablejs } from '../models/datatablejs';

@Injectable({
  providedIn: 'root'
})
export class RelatorioService {

  private readonly uri: string = 'api/relatorio';

  constructor(private baseService: BaseService) { }

  getEstatisticaPorAssunto(de?: Date, ate?: Date) {

    let from = de ? de.toJSON() : null;
    let to = ate ? ate.toJSON() : null;

    return this.baseService.get<Datatablejs>(`${this.uri}/estatistica-assunto?de=${from}&ate=${to}`);
  }
  getRelacaoProcedimentos(situacaoId?: number, de?: Date, ate?: Date) {

    let from = de ? de.toJSON() : null;
    let to = ate ? ate.toJSON() : null;

    return this.baseService.get<Datatablejs>(`${this.uri}/relacao-procedimentos?situacaoId=${situacaoId}&de=${from}&ate=${to}`);
  }
  getRelacaoIndiciados() {
    return this.baseService.get<Datatablejs>(`${this.uri}/relacao-indiciados`);
  }
  getRelacaoVitimas() {
    return this.baseService.get<Datatablejs>(`${this.uri}/relacao-vitimas`);
  }
}
