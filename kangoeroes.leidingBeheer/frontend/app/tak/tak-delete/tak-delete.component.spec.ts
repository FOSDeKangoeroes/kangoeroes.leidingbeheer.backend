import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TakDeleteComponent } from './tak-delete.component';

describe('TakDeleteComponent', () => {
  let component: TakDeleteComponent;
  let fixture: ComponentFixture<TakDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TakDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TakDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
