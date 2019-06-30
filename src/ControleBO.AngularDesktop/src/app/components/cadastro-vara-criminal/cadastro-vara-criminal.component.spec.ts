import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroVaraCriminalComponent } from './cadastro-vara-criminal.component';

describe('CadastroVaraCriminalComponent', () => {
  let component: CadastroVaraCriminalComponent;
  let fixture: ComponentFixture<CadastroVaraCriminalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroVaraCriminalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroVaraCriminalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
