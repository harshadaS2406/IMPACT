import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientvisitmedicationComponent } from './patientvisitmedication.component';

describe('PatientvisitmedicationComponent', () => {
  let component: PatientvisitmedicationComponent;
  let fixture: ComponentFixture<PatientvisitmedicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientvisitmedicationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientvisitmedicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
