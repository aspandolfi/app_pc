import { TestBed } from '@angular/core/testing';

import { VitimaService } from './vitima.service';

describe('VitimaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VitimaService = TestBed.get(VitimaService);
    expect(service).toBeTruthy();
  });
});
