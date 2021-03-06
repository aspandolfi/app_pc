﻿import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { TipoProcedimento } from '../models/tipoProcedimento';

@Injectable()
export class TipoProcedimentoService {

    private readonly uri: string = 'api/tipoprocedimento';

    constructor(private baseService: BaseService) {

    }

    create(tipoProcedimento: TipoProcedimento) {
        return this.baseService.post<TipoProcedimento>(this.uri, tipoProcedimento);
    }

    update(tipoProcedimento: TipoProcedimento) {
        return this.baseService.put<TipoProcedimento>(`${this.uri}/${tipoProcedimento.id}`, tipoProcedimento);
    }

    delete(id: string) {
        return this.baseService.delete(`${this.uri}/${id}`);
    }

    getAll() {
        return this.baseService.get<TipoProcedimento[]>(this.uri);
    }
}