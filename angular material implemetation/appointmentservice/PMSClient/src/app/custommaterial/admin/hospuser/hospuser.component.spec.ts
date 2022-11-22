import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HospuserComponent } from './hospuser.component';

describe('HospuserComponent', () => {
  let component: HospuserComponent;
  let fixture: ComponentFixture<HospuserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HospuserComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HospuserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
