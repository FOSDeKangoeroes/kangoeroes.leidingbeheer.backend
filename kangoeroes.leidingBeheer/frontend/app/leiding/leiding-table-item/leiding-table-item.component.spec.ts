import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeidingTableItemComponent } from './leiding-table-item.component';

describe('LeidingTableItemComponent', () => {
  let component: LeidingTableItemComponent;
  let fixture: ComponentFixture<LeidingTableItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeidingTableItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeidingTableItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
