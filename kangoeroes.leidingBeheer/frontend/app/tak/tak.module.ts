import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TakComponent } from './tak/tak.component';
import { RouterModule } from '@angular/router';
import { TakListComponent } from './tak-list/tak-list.component';

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
    CommonModule,
    RouterModule.forChild(routes)
  ],
  declarations: [TakComponent, TakListComponent]
})
export class TakModule { }
