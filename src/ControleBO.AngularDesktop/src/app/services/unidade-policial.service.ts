import { Injectable } from '@angular/core';
import { IServiceBase } from './service-base';
import { UnidadePolicial } from '../models/unidade-policial';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class UnidadePolicialService implements IServiceBase<UnidadePolicial> {

  private readonly uri: string = 'api/unidade-policial';

  constructor(private baseService: BaseService) { }

  create(model: UnidadePolicial) {
    return this.baseService.post(this.uri, model);
  }
  update(model: UnidadePolicial) {
    return this.baseService.put(`${this.uri}/${model.id}`, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get<UnidadePolicial>(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<UnidadePolicial[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<UnidadePolicial[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
}
