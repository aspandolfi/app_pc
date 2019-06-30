import { Injectable } from '@angular/core';
import { IServiceBase } from './service-base';
import { Municipio } from '../models/municipio';
import { BaseService } from './base.service';
import { Result } from '../models/result';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MunicipioService implements IServiceBase<Municipio> {

  private readonly uri: string = 'api/municipio';

  create(model: Municipio) {
    return this.baseService.post(this.uri, model);
  }
  update(model: Municipio) {
    return this.baseService.put(`${this.uri}/${model.id}`, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get<Municipio>(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<Municipio[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<Municipio[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
  getUltimaAtualizacao(): Observable<Result<string>> {
    return this.baseService.get(`${this.uri}/ultimaatualizacao`);
  }

  constructor(private baseService: BaseService) { }
}
