import { Component } from '@angular/core';
import { BaseService } from '../../services/base.service';

@Component({
    selector: 'app-configuracao',
    templateUrl: './configuracao.component.html',
})
/** configuracao component*/
export class ConfiguracaoComponent {
    /** configuracao ctor */
    constructor(private baseService: BaseService) {

    }
}