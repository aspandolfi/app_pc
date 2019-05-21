import { Injectable } from '@angular/core';
import { IServiceBase } from './service-base';
import { VaraCriminal } from '../models/vara-criminal';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class VaraCriminalService implements IServiceBase<VaraCriminal> {

  private readonly uri: string = 'api/varacriminal';

  constructor(private baseService: BaseService) { }

  create(model: VaraCriminal) {
    return this.baseService.post<VaraCriminal>(this.uri, model);
  }
  update(model: VaraCriminal) {
    return this.baseService.put<VaraCriminal>(this.uri, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<VaraCriminal[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<VaraCriminal[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
}
