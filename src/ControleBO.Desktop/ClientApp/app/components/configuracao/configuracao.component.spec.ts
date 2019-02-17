/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ConfiguracaoComponent } from './configuracao.component';

let component: ConfiguracaoComponent;
let fixture: ComponentFixture<ConfiguracaoComponent>;

describe('configuracao component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ConfiguracaoComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ConfiguracaoComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});