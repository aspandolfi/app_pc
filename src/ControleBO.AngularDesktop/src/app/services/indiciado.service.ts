import { Injectable } from '@angular/core';
import { Indiciado } from '../models/indiciado';
import { IServiceBase } from './service-base';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class IndiciadoService implements IServiceBase<Indiciado> {

  private readonly uri = `api/indiciado`;

  constructor(private baseService: BaseService) { }

  create(model: Indiciado) {
    return this.baseService.post(this.uri, model);
  }
  update(model: Indiciado) {
    return this.baseService.put(`${this.uri}/${model.id}`, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get<Indiciado>(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<Indiciado[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<Indiciado[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
  getAllFiltered(procedimentoId: number) {
    return this.baseService.get<Indiciado[]>(`${this.uri}/procedimento/${procedimentoId}`);
  }
}
