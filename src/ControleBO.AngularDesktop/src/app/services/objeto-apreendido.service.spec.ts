import { TestBed } from '@angular/core/testing';

import { ObjetoApreendidoService } from './objeto-apreendido.service';

describe('ObjetoApreendidoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ObjetoApreendidoService = TestBed.get(ObjetoApreendidoService);
    expect(service).toBeTruthy();
  });
});
