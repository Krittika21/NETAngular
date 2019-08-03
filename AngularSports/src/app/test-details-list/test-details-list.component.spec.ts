import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestDetailsListComponent } from './test-details-list.component';

describe('TestDetailsListComponent', () => {
  let component: TestDetailsListComponent;
  let fixture: ComponentFixture<TestDetailsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestDetailsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestDetailsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
