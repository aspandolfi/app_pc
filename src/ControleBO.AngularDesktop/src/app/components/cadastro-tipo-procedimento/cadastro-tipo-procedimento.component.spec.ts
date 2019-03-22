import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroTipoProcedimentoComponent } from './cadastro-tipo-procedimento.component';

describe('CadastroTipoProcedimentoComponent', () => {
  let component: CadastroTipoProcedimentoComponent;
  let fixture: ComponentFixture<CadastroTipoProcedimentoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroTipoProcedimentoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroTipoProcedimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
