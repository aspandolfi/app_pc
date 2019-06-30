import { Injectable } from '@angular/core';
import { Assunto } from '../models/assunto';
import { IServiceBase } from './service-base';
import { BaseService } from './base.service';
import { Result } from '../models/result';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AssuntoService implements IServiceBase<Assunto> {
  private readonly uri: string = 'api/assunto';

  constructor(private baseService: BaseService) { }

  create(model: Assunto) {
    return this.baseService.post(this.uri, model);
  }
  update(model: Assunto) {
    return this.baseService.put(`${this.uri}/${model.id}`, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get<Assunto>(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<Assunto[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<Assunto[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
  getUltimaAtualizacao(): Observable<Result<string>> {
    return this.baseService.get(`${this.uri}/ultimaatualizacao`);
  }
}
