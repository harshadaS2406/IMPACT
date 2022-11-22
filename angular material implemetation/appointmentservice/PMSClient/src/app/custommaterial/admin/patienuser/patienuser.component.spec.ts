import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatienuserComponent } from './patienuser.component';

describe('PatienuserComponent', () => {
  let component: PatienuserComponent;
  let fixture: ComponentFixture<PatienuserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatienuserComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatienuserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
