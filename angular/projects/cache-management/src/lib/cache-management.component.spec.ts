import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { CacheManagementComponent } from './components/cache-management.component';
import { CacheManagementService } from '@j-s.Abp/cache-management';
import { of } from 'rxjs';

describe('CacheManagementComponent', () => {
  let component: CacheManagementComponent;
  let fixture: ComponentFixture<CacheManagementComponent>;
  const mockCacheManagementService = jasmine.createSpyObj('CacheManagementService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [CacheManagementComponent],
      providers: [
        {
          provide: CacheManagementService,
          useValue: mockCacheManagementService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CacheManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
