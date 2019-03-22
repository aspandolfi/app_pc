/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { TipoProcedimentoComponent } from './tipo-procedimento.component';

let component: TipoProcedimentoComponent;
let fixture: ComponentFixture<TipoProcedimentoComponent>;

describe('tipo-procedimento component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [TipoProcedimentoComponent],
            imports: [BrowserModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(TipoProcedimentoComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});