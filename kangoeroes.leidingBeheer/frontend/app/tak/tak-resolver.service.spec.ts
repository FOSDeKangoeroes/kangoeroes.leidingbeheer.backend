import { TestBed, inject } from '@angular/core/testing';

import { TakResolverService } from './tak-resolver.service';

describe('TakResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TakResolverService]
    });
  });

  it('should be created', inject([TakResolverService], (service: TakResolverService) => {
    expect(service).toBeTruthy();
  }));
});
