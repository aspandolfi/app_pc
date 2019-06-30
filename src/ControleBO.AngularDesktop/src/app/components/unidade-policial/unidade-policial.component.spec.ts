import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnidadePolicialComponent } from './unidade-policial.component';

describe('UnidadePolicialComponent', () => {
  let component: UnidadePolicialComponent;
  let fixture: ComponentFixture<UnidadePolicialComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnidadePolicialComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnidadePolicialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
