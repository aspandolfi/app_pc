import { TestBed } from '@angular/core/testing';

import { UnidadePolicialService } from './unidade-policial.service';

describe('UnidadePolicialService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UnidadePolicialService = TestBed.get(UnidadePolicialService);
    expect(service).toBeTruthy();
  });
});
