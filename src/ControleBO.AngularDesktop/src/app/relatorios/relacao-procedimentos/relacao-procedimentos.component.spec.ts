import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RelacaoProcedimentosComponent } from './relacao-procedimentos.component';

describe('RelacaoProcedimentosComponent', () => {
  let component: RelacaoProcedimentosComponent;
  let fixture: ComponentFixture<RelacaoProcedimentosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RelacaoProcedimentosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RelacaoProcedimentosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
