import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { IServiceBase } from './service-base';
import { Procedimento, ProcedimentoList } from '../models/procedimento';
import { Observable } from 'rxjs';
import { Result } from '../models/result';

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
  getAll(): Observable<Result<ProcedimentoList[]>> {
    return this.baseService.get<ProcedimentoList[]>(this.uri);
  }
  getAllPaged(page: number = 1, pageSize: number = 10): Observable<Result<ProcedimentoList[]>> {
    return this.baseService.get<ProcedimentoList[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
  getUltimaAtualizacao(): Observable<Result<string>> {
    return this.baseService.get(`${this.uri}/ultimaatualizacao`);
  }
  get(id: number) {
    return this.baseService.get<Procedimento>(`${this.uri}/${id}`);
  }
}
