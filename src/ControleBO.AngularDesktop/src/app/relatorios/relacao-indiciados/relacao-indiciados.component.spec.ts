import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RelacaoIndiciadosComponent } from './relacao-indiciados.component';

describe('RelacaoIndiciadosComponent', () => {
  let component: RelacaoIndiciadosComponent;
  let fixture: ComponentFixture<RelacaoIndiciadosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RelacaoIndiciadosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RelacaoIndiciadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
