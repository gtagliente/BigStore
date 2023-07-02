import { TestBed } from '@angular/core/testing';

import { BigStoreClientService } from './big-store-client.service';

describe('BigStoreClientService', () => {
  let service: BigStoreClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BigStoreClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
