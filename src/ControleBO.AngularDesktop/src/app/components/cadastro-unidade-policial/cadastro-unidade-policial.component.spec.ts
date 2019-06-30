import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroUnidadePolicialComponent } from './cadastro-unidade-policial.component';

describe('CadastroUnidadePolicialComponent', () => {
  let component: CadastroUnidadePolicialComponent;
  let fixture: ComponentFixture<CadastroUnidadePolicialComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroUnidadePolicialComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroUnidadePolicialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
