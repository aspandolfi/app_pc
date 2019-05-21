import { TestBed } from '@angular/core/testing';

import { TabsMessageService } from './tabs-message.service';

describe('TabsMessageService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TabsMessageService = TestBed.get(TabsMessageService);
    expect(service).toBeTruthy();
  });
});
