import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VaraCriminalComponent } from './vara-criminal.component';

describe('VaraCriminalComponent', () => {
  let component: VaraCriminalComponent;
  let fixture: ComponentFixture<VaraCriminalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VaraCriminalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VaraCriminalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
