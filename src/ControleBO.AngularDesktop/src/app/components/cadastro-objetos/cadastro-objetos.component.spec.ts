import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroObjetosComponent } from './cadastro-objetos.component';

describe('CadastroObjetosComponent', () => {
  let component: CadastroObjetosComponent;
  let fixture: ComponentFixture<CadastroObjetosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroObjetosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroObjetosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
