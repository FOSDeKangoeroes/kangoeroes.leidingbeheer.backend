import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TakLeidingAddComponent } from './tak-leiding-add.component';

describe('TakLeidingAddComponent', () => {
  let component: TakLeidingAddComponent;
  let fixture: ComponentFixture<TakLeidingAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TakLeidingAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TakLeidingAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
