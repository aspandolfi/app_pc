import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoProcedimentoComponent } from './tipo-procedimento.component';

describe('TipoProcedimentoComponent', () => {
  let component: TipoProcedimentoComponent;
  let fixture: ComponentFixture<TipoProcedimentoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TipoProcedimentoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TipoProcedimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
