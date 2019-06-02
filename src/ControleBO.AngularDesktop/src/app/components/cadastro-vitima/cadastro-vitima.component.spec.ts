import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroVitimaComponent } from './cadastro-vitima.component';

describe('CadastroVitimaComponent', () => {
  let component: CadastroVitimaComponent;
  let fixture: ComponentFixture<CadastroVitimaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroVitimaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroVitimaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
