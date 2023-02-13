import { TestBed } from '@angular/core/testing';
import { CacheManagementService } from './services/cache-management.service';
import { RestService } from '@abp/ng.core';

describe('CacheManagementService', () => {
  let service: CacheManagementService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(CacheManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
