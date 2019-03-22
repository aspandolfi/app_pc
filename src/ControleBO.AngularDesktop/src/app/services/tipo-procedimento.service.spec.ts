import { TestBed } from '@angular/core/testing';

import { TipoProcedimentoService } from './tipo-procedimento.service';

describe('TipoProcedimentoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TipoProcedimentoService = TestBed.get(TipoProcedimentoService);
    expect(service).toBeTruthy();
  });
});
