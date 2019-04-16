import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroProcedimentoComponent } from './cadastro-procedimento.component';

describe('CadastroProcedimentoComponent', () => {
  let component: CadastroProcedimentoComponent;
  let fixture: ComponentFixture<CadastroProcedimentoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroProcedimentoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroProcedimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
