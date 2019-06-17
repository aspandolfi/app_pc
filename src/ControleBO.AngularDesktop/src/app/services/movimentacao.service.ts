import { Injectable } from '@angular/core';
import { IServiceBase } from './service-base';
import { Movimentacao } from '../models/movimentacao';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class MovimentacaoService implements IServiceBase<Movimentacao> {

  private readonly uri: string = 'api/movimentacao';

  constructor(private baseService: BaseService) { }

  create(model: Movimentacao) {
    return this.baseService.post(this.uri, model);
  }
  update(model: Movimentacao) {
    return this.baseService.put(`${this.uri}/${model.id}`, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get<Movimentacao>(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<Movimentacao[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<Movimentacao[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
  getByProcedimentoId(procedimentoId: number) {
    return this.baseService.get<Movimentacao[]>(`${this.uri}/procedimento/${procedimentoId}`);
  }
}
