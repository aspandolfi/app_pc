import { Injectable } from '@angular/core';
import { IServiceBase } from './service-base';
import { SituacaoProcedimento } from '../models/situacao-procedimento';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SituacaoProcedimentoService implements IServiceBase<SituacaoProcedimento> {

  private readonly uri: string = 'api/situacao-procedimento';

  constructor(private baseService: BaseService) { }

  create(model: SituacaoProcedimento) {
    return this.baseService.post<SituacaoProcedimento>(this.uri, model);
  }
  update(model: SituacaoProcedimento) {
    return this.baseService.put<SituacaoProcedimento>(this.uri, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<SituacaoProcedimento[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<SituacaoProcedimento[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
  getByProcedimento(procedimentoId: number) {
    return this.baseService.get<SituacaoProcedimento>(`${this.uri}/procedimento/${procedimentoId}`);
  }
}
