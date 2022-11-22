import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HospUserRegistrationComponent } from './hosp-user-registration.component';

describe('HospUserRegistrationComponent', () => {
  let component: HospUserRegistrationComponent;
  let fixture: ComponentFixture<HospUserRegistrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HospUserRegistrationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HospUserRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
