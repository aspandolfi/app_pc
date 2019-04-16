import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroProcedimentoVitimasAutoresComponent } from './cadastro-procedimento-vitimas-autores.component';

describe('CadastroProcedimentoVitimasAutoresComponent', () => {
  let component: CadastroProcedimentoVitimasAutoresComponent;
  let fixture: ComponentFixture<CadastroProcedimentoVitimasAutoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroProcedimentoVitimasAutoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroProcedimentoVitimasAutoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
