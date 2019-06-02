import { TestBed } from '@angular/core/testing';

import { IndiciadoMessageService } from './indiciado-message.service';

describe('IndiciadoMessageService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: IndiciadoMessageService = TestBed.get(IndiciadoMessageService);
    expect(service).toBeTruthy();
  });
});
