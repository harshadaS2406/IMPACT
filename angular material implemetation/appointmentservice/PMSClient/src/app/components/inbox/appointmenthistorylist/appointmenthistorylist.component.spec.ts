import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmenthistorylistComponent } from './appointmenthistorylist.component';

describe('AppointmenthistorylistComponent', () => {
  let component: AppointmenthistorylistComponent;
  let fixture: ComponentFixture<AppointmenthistorylistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppointmenthistorylistComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmenthistorylistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
