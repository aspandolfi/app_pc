import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroMunicipioComponent } from './cadastro-municipio.component';

describe('CadastroMunicipioComponent', () => {
  let component: CadastroMunicipioComponent;
  let fixture: ComponentFixture<CadastroMunicipioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroMunicipioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroMunicipioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
