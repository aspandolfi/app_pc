import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { IServiceBase } from './service-base';
import { ObjetoApreendido } from '../models/objeto-apreendido';

@Injectable({
  providedIn: 'root'
})
export class ObjetoApreendidoService implements IServiceBase<ObjetoApreendido> {

  private readonly uri: string = 'api/objeto-apreendido';

  constructor(private baseService: BaseService) { }

  create(model: ObjetoApreendido) {
    return this.baseService.post(this.uri, model);
  }
  update(model: ObjetoApreendido) {
    return this.baseService.put(`${this.uri}/${model.id}`, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get<ObjetoApreendido>(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<ObjetoApreendido[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<ObjetoApreendido[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
  getByProcedimento(procedimentoId: number) {
    return this.baseService.get<ObjetoApreendido[]>(`${this.uri}/procedimento/${procedimentoId}`);
  }
}
