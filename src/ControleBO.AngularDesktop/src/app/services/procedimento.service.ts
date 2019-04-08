import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { IServiceBase } from './service-base';
import { Procedimento } from '../models/procedimento';
import { Observable } from 'rxjs';
import { Result } from '../models/result';
import { Datatablejs } from '../models/datatablejs';

@Injectable({
  providedIn: 'root'
})
export class ProcedimentoService implements IServiceBase<Procedimento> {

  private readonly uri: string = 'api/procedimento';
  public readonly url: string;

  constructor(private baseService: BaseService) {
    this.url = baseService.apiUrl + this.uri;
  }

  create(model: Procedimento): Observable<Result<Procedimento>> {
    return this.baseService.post<Procedimento>(this.uri, model);
  }
  update(model: Procedimento): Observable<Result<Procedimento>> {
    return this.baseService.put<Procedimento>(`${this.uri}/${model.id}`, model);
  }
  delete(id: number): Observable<Result<any>> {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  getAll(): Observable<Result<Datatablejs>> {
    return this.baseService.get<Datatablejs>(this.uri);
  }
  getAllPaged(page: number = 1, pageSize: number = 10): Observable<Result<Datatablejs>> {
    return this.baseService.get<Datatablejs>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
}
