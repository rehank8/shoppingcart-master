import { TestBed } from '@angular/core/testing';

import { SharableService } from './sharable.service';

describe('SharableService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SharableService = TestBed.get(SharableService);
    expect(service).toBeTruthy();
  });
});
