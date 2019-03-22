import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Observable';
import { DatatableJsModel } from '../models/datatablejsModel';

@Injectable()
export class ProcedimentoService {

    private readonly uri: string = 'api/procedimento';

    constructor(private baseService: BaseService) {

    }

    //getAll(): Observable<DatatableJsModel> {
    //    //return this.baseService.get()
    //}
}