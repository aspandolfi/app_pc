import { TestBed } from '@angular/core/testing';

import { ProcedimentoService } from './procedimento.service';

describe('ProcedimentoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProcedimentoService = TestBed.get(ProcedimentoService);
    expect(service).toBeTruthy();
  });
});
