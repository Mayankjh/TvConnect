import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorplansComponent } from './vendorplans.component';

describe('VendorplansComponent', () => {
  let component: VendorplansComponent;
  let fixture: ComponentFixture<VendorplansComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorplansComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorplansComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
