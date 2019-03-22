/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CadastroTipoProcedimentoComponent } from './cadastro-tipo-procedimento.component';

let component: CadastroTipoProcedimentoComponent;
let fixture: ComponentFixture<CadastroTipoProcedimentoComponent>;

describe('cadastro-tipo-procedimento component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CadastroTipoProcedimentoComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CadastroTipoProcedimentoComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});