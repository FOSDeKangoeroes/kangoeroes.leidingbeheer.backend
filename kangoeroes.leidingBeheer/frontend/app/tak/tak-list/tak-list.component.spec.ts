import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TakListComponent } from './tak-list.component';

describe('TakListComponent', () => {
  let component: TakListComponent;
  let fixture: ComponentFixture<TakListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TakListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TakListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
