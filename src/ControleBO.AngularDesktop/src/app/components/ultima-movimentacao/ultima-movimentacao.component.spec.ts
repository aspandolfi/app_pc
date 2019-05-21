import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UltimaMovimentacaoComponent } from './ultima-movimentacao.component';

describe('UltimaMovimentacaoComponent', () => {
  let component: UltimaMovimentacaoComponent;
  let fixture: ComponentFixture<UltimaMovimentacaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UltimaMovimentacaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UltimaMovimentacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
