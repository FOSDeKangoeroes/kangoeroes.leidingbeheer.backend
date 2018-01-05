import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTakComponent } from './edit-tak.component';

describe('EditTakComponent', () => {
  let component: EditTakComponent;
  let fixture: ComponentFixture<EditTakComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditTakComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditTakComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
