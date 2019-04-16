import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TabsCadastroProcedimentoComponent } from './tabs-cadastro-procedimento.component';

describe('TabsCadastroProcedimentoComponent', () => {
  let component: TabsCadastroProcedimentoComponent;
  let fixture: ComponentFixture<TabsCadastroProcedimentoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TabsCadastroProcedimentoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TabsCadastroProcedimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
