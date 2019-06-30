import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroAssuntoComponent } from './cadastro-assunto.component';

describe('CadastroAssuntoComponent', () => {
  let component: CadastroAssuntoComponent;
  let fixture: ComponentFixture<CadastroAssuntoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroAssuntoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroAssuntoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
