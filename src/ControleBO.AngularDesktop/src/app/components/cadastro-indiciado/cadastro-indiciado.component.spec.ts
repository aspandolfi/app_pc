import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroIndiciadoComponent } from './cadastro-indiciado.component';

describe('CadastroIndiciadoComponent', () => {
  let component: CadastroIndiciadoComponent;
  let fixture: ComponentFixture<CadastroIndiciadoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroIndiciadoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroIndiciadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
