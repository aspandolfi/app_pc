import { TestBed } from '@angular/core/testing';

import { SituacaoService } from './situacao.service';

describe('SituacaoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SituacaoService = TestBed.get(SituacaoService);
    expect(service).toBeTruthy();
  });
});
