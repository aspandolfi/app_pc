import { TestBed } from '@angular/core/testing';

import { SituacaoProcedimentoService } from './situacao-procedimento.service';

describe('SituacaoProcedimentoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SituacaoProcedimentoService = TestBed.get(SituacaoProcedimentoService);
    expect(service).toBeTruthy();
  });
});
