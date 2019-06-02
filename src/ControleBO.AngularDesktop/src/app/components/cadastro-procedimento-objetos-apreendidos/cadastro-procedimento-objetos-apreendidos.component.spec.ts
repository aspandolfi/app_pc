import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroProcedimentoObjetosApreendidosComponent } from './cadastro-procedimento-objetos-apreendidos.component';

describe('CadastroProcedimentoObjetosApreendidosComponent', () => {
  let component: CadastroProcedimentoObjetosApreendidosComponent;
  let fixture: ComponentFixture<CadastroProcedimentoObjetosApreendidosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroProcedimentoObjetosApreendidosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroProcedimentoObjetosApreendidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
