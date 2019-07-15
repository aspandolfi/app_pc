import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoSituacaoComponent } from './tipo-situacao.component';

describe('TipoSituacaoComponent', () => {
  let component: TipoSituacaoComponent;
  let fixture: ComponentFixture<TipoSituacaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TipoSituacaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TipoSituacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
