import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientvisitvitalsignsComponent } from './patientvisitvitalsigns.component';

describe('PatientvisitvitalsignsComponent', () => {
  let component: PatientvisitvitalsignsComponent;
  let fixture: ComponentFixture<PatientvisitvitalsignsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientvisitvitalsignsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientvisitvitalsignsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
