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
}
