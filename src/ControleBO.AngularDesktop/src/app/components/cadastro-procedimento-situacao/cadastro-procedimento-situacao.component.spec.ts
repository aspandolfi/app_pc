import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroProcedimentoSituacaoComponent } from './cadastro-procedimento-situacao.component';

describe('CadastroProcedimentoSituacaoComponent', () => {
  let component: CadastroProcedimentoSituacaoComponent;
  let fixture: ComponentFixture<CadastroProcedimentoSituacaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroProcedimentoSituacaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroProcedimentoSituacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
