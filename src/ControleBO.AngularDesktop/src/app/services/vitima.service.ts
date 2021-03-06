import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Vitima } from '../models/vitima';
import { IServiceBase } from './service-base';
import { mergeMap, map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VitimaService implements IServiceBase<Vitima> {

  private readonly uri = 'api/vitima';

  constructor(private baseService: BaseService) { }

  create(model: Vitima) {
    return this.baseService.post(this.uri, model);
  }
  update(model: Vitima) {
    return this.baseService.put(`${this.uri}/${model.id}`, model);
  }
  delete(id: number) {
    return this.baseService.delete(`${this.uri}/${id}`);
  }
  get(id: number) {
    return this.baseService.get<Vitima>(`${this.uri}/${id}`);
  }
  getAll() {
    return this.baseService.get<Vitima[]>(this.uri);
  }
  getAllPaged(page: number, pageSize: number) {
    return this.baseService.get<Vitima[]>(`${this.uri}/paginate/page=${page}&pageSize=${pageSize}`);
  }
  getByProcedimentoId(procedimentoId: number) {
    return this.baseService.get<Vitima[]>(`${this.uri}/procedimento/${procedimentoId}`);
  }
  getByText(text: string): Observable<string[]> {
    return this.baseService.get(`${this.uri}/searchByName?s=${text}`)
      .pipe(
        map((res) => res.data as string[])
      );
  }
}
