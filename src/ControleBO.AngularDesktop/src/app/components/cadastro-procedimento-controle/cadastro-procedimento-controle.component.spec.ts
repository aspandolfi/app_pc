import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroProcedimentoControleComponent } from './cadastro-procedimento-controle.component';

describe('CadastroProcedimentoControleComponent', () => {
  let component: CadastroProcedimentoControleComponent;
  let fixture: ComponentFixture<CadastroProcedimentoControleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroProcedimentoControleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroProcedimentoControleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
