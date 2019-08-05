import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewAthleteComponent } from './new-athlete.component';

describe('NewAthleteComponent', () => {
  let component: NewAthleteComponent;
  let fixture: ComponentFixture<NewAthleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewAthleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewAthleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
