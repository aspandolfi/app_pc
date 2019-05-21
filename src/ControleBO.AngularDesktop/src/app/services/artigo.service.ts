import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Artigo } from '../models/artigo';
import { IServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class ArtigoService implements IServiceBase<Artigo> {
  private readonly uri: string = 'api/artigo';

  constructor(private baseService: BaseService) { }

  create(model: Artigo) {
    return this.baseService.post(this.uri, model);
  }
  update(model: Artigo) {
    return this.baseService.put(`${this.uri}/${model.id}`, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get<Artigo>(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<Artigo[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<Artigo[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
}
