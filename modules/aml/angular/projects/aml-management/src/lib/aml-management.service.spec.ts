import { TestBed } from '@angular/core/testing';

import { AmlManagementService } from './aml-management.service';

describe('AmlManagementService', () => {
  let service: AmlManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AmlManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
