import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientUserRegistrationComponent } from './patient-user-registration.component';

describe('PatientUserRegistrationComponent', () => {
  let component: PatientUserRegistrationComponent;
  let fixture: ComponentFixture<PatientUserRegistrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientUserRegistrationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientUserRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
