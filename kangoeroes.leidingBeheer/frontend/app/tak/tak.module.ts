import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TakComponent } from './tak/tak.component';
import { RouterModule } from '@angular/router';
import { TakListComponent } from './tak-list/tak-list.component';
import { DataService } from '../data.service';
import { HttpModule } from '@angular/http';
import { LeidingModule } from '../leiding/leiding.module';

const routes = [
  {
    path: '',
    component: TakListComponent,
    pathMatch: 'full',
    data: {
      title: 'Takken'
    } }
];

@NgModule({
  imports: [
    HttpModule,
    CommonModule,
    LeidingModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    DataService
  ],
  declarations: [TakComponent, TakListComponent]
})
export class TakModule { }
