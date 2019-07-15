import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroTipoSituacaoComponent } from './cadastro-tipo-situacao.component';

describe('CadastroTipoSituacaoComponent', () => {
  let component: CadastroTipoSituacaoComponent;
  let fixture: ComponentFixture<CadastroTipoSituacaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroTipoSituacaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroTipoSituacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
