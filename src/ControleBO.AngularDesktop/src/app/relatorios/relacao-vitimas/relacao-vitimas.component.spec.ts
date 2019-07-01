import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RelacaoVitimasComponent } from './relacao-vitimas.component';

describe('RelacaoVitimasComponent', () => {
  let component: RelacaoVitimasComponent;
  let fixture: ComponentFixture<RelacaoVitimasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RelacaoVitimasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RelacaoVitimasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
