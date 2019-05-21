import { TestBed } from '@angular/core/testing';

import { IndiciadoService } from './indiciado.service';

describe('IndiciadoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: IndiciadoService = TestBed.get(IndiciadoService);
    expect(service).toBeTruthy();
  });
});
