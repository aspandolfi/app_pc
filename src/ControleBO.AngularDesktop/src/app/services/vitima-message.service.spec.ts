import { TestBed } from '@angular/core/testing';

import { VitimaMessageService } from './vitima-message.service';

describe('VitimaMessageService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VitimaMessageService = TestBed.get(VitimaMessageService);
    expect(service).toBeTruthy();
  });
});
