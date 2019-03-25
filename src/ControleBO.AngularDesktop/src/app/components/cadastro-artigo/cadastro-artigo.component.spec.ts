import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroArtigoComponent } from './cadastro-artigo.component';

describe('CadastroArtigoComponent', () => {
  let component: CadastroArtigoComponent;
  let fixture: ComponentFixture<CadastroArtigoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroArtigoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroArtigoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
