import { TestBed } from '@angular/core/testing';

import { MovimentacaoService } from './movimentacao.service';

describe('MovimentacaoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MovimentacaoService = TestBed.get(MovimentacaoService);
    expect(service).toBeTruthy();
  });
});
