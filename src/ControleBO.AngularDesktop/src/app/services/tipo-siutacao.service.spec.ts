import { TestBed } from '@angular/core/testing';

import { TipoSiutacaoService } from './tipo-siutacao.service';

describe('TipoSiutacaoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TipoSiutacaoService = TestBed.get(TipoSiutacaoService);
    expect(service).toBeTruthy();
  });
});
