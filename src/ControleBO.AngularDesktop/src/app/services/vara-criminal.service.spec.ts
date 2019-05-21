import { TestBed } from '@angular/core/testing';

import { VaraCriminalService } from './vara-criminal.service';

describe('VaraCriminalService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VaraCriminalService = TestBed.get(VaraCriminalService);
    expect(service).toBeTruthy();
  });
});
