import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { AmlManagementComponent } from './aml-management.component';

describe('AmlManagementComponent', () => {
  let component: AmlManagementComponent;
  let fixture: ComponentFixture<AmlManagementComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ AmlManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AmlManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
