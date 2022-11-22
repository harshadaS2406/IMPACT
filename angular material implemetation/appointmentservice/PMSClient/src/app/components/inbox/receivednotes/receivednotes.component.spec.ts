import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceivednotesComponent } from './receivednotes.component';

describe('ReceivednotesComponent', () => {
  let component: ReceivednotesComponent;
  let fixture: ComponentFixture<ReceivednotesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReceivednotesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReceivednotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
