import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientvisitdetailsComponent } from './patientvisitdetails.component';

describe('PatientvisitdetailsComponent', () => {
  let component: PatientvisitdetailsComponent;
  let fixture: ComponentFixture<PatientvisitdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientvisitdetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientvisitdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
