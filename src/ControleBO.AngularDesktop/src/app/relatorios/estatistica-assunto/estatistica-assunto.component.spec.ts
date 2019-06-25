import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EstatisticaAssuntoComponent } from './estatistica-assunto.component';

describe('EstatisticaAssuntoComponent', () => {
  let component: EstatisticaAssuntoComponent;
  let fixture: ComponentFixture<EstatisticaAssuntoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EstatisticaAssuntoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EstatisticaAssuntoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
