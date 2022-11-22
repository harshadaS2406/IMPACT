import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientvisitprocedureComponent } from './patientvisitprocedure.component';

describe('PatientvisitprocedureComponent', () => {
  let component: PatientvisitprocedureComponent;
  let fixture: ComponentFixture<PatientvisitprocedureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientvisitprocedureComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientvisitprocedureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
