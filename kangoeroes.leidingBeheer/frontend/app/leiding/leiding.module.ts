import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeidingTableItemComponent } from './leiding-table-item/leiding-table-item.component';
import { TakModule } from '../tak/tak.module';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [LeidingTableItemComponent],
  declarations: [LeidingTableItemComponent]
})
export class LeidingModule { }
