import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Datatablejs } from '../models/datatablejs';

@Injectable({
  providedIn: 'root'
})
export class RelatorioService {

  private readonly uri: string = 'api/relatorio';

  constructor(private baseService: BaseService) { }

  getEstatisticaPorAssunto() {
    return this.baseService.get<Datatablejs>(`${this.uri}/estatistica-assunto`);
  }
  getRelacaoProcedimentos(situacaoId: number) {
    return this.baseService.get<Datatablejs>(`${this.uri}/relacao-procedimentos?situacaoId=${situacaoId}`);
  }
  getRelacaoIndiciados() {
    return this.baseService.get<Datatablejs>(`${this.uri}/relacao-indiciados`);
  }
  getRelacaoVitimas() {
    return this.baseService.get<Datatablejs>(`${this.uri}/relacao-vitimas`);
  }
}
