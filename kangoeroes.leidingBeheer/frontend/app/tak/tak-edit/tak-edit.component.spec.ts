import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TakEditComponent } from './tak-edit.component';

describe('TakEditComponent', () => {
  let component: TakEditComponent;
  let fixture: ComponentFixture<TakEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TakEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TakEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
