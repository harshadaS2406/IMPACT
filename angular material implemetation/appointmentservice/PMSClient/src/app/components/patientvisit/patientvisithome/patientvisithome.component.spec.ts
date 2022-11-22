import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientvisithomeComponent } from './patientvisithome.component';

describe('PatientvisithomeComponent', () => {
  let component: PatientvisithomeComponent;
  let fixture: ComponentFixture<PatientvisithomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientvisithomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientvisithomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
