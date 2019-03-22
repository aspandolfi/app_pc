import { Component, Input, Output, EventEmitter } from '@angular/core';
import { TipoProcedimento } from '../../models/tipoProcedimento';
import { TipoProcedimentoService } from '../../services/tipo-procedimento.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-cadastro-tipo-procedimento',
    templateUrl: './cadastro-tipo-procedimento.component.html',
    styleUrls: ['./cadastro-tipo-procedimento.component.css'],
    providers: [TipoProcedimentoService, ToastrService]
})
/** cadastro-tipo-procedimento component*/
export class CadastroTipoProcedimentoComponent {
    /** cadastro-tipo-procedimento ctor */

    loaded: boolean = false;

    @Input() tipoProcedimento: TipoProcedimento;
    @Output() onCreatedTipoProcedimento = new EventEmitter<TipoProcedimento>();

    constructor(private tipoProcedimentoService: TipoProcedimentoService, private toastr: ToastrService) {
        this.tipoProcedimento = new TipoProcedimento();
    }

    open(tipoProcedimento?: TipoProcedimento) {
        this.loaded = !this.loaded;

        this.toastr.show('opened', 'toast');

        if (tipoProcedimento != null) {
            this.tipoProcedimento = tipoProcedimento;
        }
    }

    close() {
        this.loaded = false;
    }

    save() {
        if (this.tipoProcedimento.id) {
            this.tipoProcedimentoService.update(this.tipoProcedimento)
                .subscribe(res => {
                    if (res.success) {
                        this.toastr.success(res.message);
                        this.onCreatedTipoProcedimento.emit(res.data);
                    }
                },
                    error => console.log(error));
        }
    }


}