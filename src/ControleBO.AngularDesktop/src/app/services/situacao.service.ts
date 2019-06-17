import { Injectable } from '@angular/core';
import { IServiceBase } from './service-base';
import { Situacao } from '../models/situacao';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SituacaoService implements IServiceBase<Situacao> {

  private readonly uri: string = 'api/situacao';

  constructor(private baseService: BaseService) { }

  create(model: Situacao) {
    return this.baseService.post<Situacao>(this.uri, model);
  }
  update(model: Situacao) {
    return this.baseService.put<Situacao>(this.uri, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<Situacao[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<Situacao[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
  getByProcedimento(procedimentoId: number) {
    return this.baseService.get<Situacao>(`${this.uri}/procedimento/${procedimentoId}`);
  }
}
