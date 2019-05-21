import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Vitima } from '../models/vitima';
import { IServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class VitimaService implements IServiceBase<Vitima> {

  private readonly keyProcedimentoId = '{procedimentoId}';
  private readonly uri = `api/${this.keyProcedimentoId}/vitima`;

  constructor(private baseService: BaseService) { }

  private buildUri(id: number) {
    if (id !== undefined)
      return this.uri.replace(this.keyProcedimentoId, `${id}`);
  }

  create(model: Vitima) {
    return this.baseService.post(this.buildUri(model.procedimentoId), model);
  }
  update(model: Vitima) {
    return this.baseService.put(`${this.uri}/${model.id}`, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get<Vitima>(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<Vitima[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<Vitima[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
  getAllFiltered(procedimentoId: number) {
    return this.baseService.get<Vitima[]>(this.buildUri(procedimentoId));
  }
}
