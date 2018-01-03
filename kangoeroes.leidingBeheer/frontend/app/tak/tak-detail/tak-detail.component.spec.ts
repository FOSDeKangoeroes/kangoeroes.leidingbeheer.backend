import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TakDetailComponent } from './tak-detail.component';

describe('TakDetailComponent', () => {
  let component: TakDetailComponent;
  let fixture: ComponentFixture<TakDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TakDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TakDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
