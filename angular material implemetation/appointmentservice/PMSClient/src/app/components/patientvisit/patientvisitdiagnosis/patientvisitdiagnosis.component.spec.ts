import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientvisitdiagnosisComponent } from './patientvisitdiagnosis.component';

describe('PatientvisitdiagnosisComponent', () => {
  let component: PatientvisitdiagnosisComponent;
  let fixture: ComponentFixture<PatientvisitdiagnosisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientvisitdiagnosisComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientvisitdiagnosisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
