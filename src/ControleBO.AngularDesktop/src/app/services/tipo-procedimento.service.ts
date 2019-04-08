import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { TipoProcedimento } from '../models/tipo-procedimento';
import { IServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class TipoProcedimentoService implements IServiceBase<TipoProcedimento> {

  private readonly uri: string = 'api/tipo-procedimento';

  constructor(private baseService: BaseService) { }

  create(tipoProcedimento: TipoProcedimento) {
    return this.baseService.post<TipoProcedimento>(this.uri, tipoProcedimento);
  }

  update(tipoProcedimento: TipoProcedimento) {
    return this.baseService.put<TipoProcedimento>(`${this.uri}/${tipoProcedimento.id}`, tipoProcedimento);
  }

  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }

  getAll() {
    return this.baseService.get<TipoProcedimento[]>(this.uri);
  }

  getAllPaged(page: number = 1, pageSize: number = 10) {
    return this.baseService.get<TipoProcedimento[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
}
