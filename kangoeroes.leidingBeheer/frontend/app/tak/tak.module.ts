import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TakComponent } from './tak/tak.component';
import { RouterModule } from '@angular/router';
import { TakListComponent } from './tak-list/tak-list.component';
import { DataService } from '../data.service';
import { HttpModule } from '@angular/http';
import { LeidingModule } from '../leiding/leiding.module';
import { TakDetailComponent } from './tak-detail/tak-detail.component';
import { TakResolverService } from './tak-resolver.service';
import {MatTableModule} from '@angular/material';

const routes = [
  {
    path: '',
    component: TakListComponent,
    pathMatch: 'full',
    data: {
      title: 'Takken'
    }
   },
    {
      path: ':id',
      component: TakDetailComponent,
      resolve: {tak: TakResolverService},
      data: {
        title: 'Takdetail'
      }
    }
];

@NgModule({
  imports: [
    HttpModule,
    CommonModule,
    LeidingModule,
    MatTableModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    DataService,
    TakResolverService
  ],
  declarations: [TakComponent, TakListComponent, TakDetailComponent]
})
export class TakModule { }
