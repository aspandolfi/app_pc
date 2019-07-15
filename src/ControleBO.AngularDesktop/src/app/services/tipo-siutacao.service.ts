import { Injectable } from '@angular/core';
import { IServiceBase } from './service-base';
import { TipoSituacao } from '../models/tipo-situacao';
import { BaseService } from './base.service';
import { Result } from '../models/result';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TipoSiutacaoService implements IServiceBase<TipoSituacao> {

  private readonly uri: string = 'api/tipo-situacao';

  constructor(private baseService: BaseService) { }

  create(model: TipoSituacao) {
    return this.baseService.post(this.uri, model);
  }
  update(model: TipoSituacao) {
    return this.baseService.put(`${this.uri}/${model.id}`, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get<TipoSituacao>(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<TipoSituacao[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<TipoSituacao[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
  getUltimaAtualizacao(situacaoId: number): Observable<Result<string>> {
    return this.baseService.get(`${this.uri}/ultimaatualizacao/situacao/${situacaoId}`);
  }
}
