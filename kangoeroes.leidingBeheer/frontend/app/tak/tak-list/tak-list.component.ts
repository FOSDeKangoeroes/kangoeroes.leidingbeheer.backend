import { Component, OnInit } from '@angular/core';
import { Tak } from '../tak.model';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-tak-list',
  templateUrl: './tak-list.component.html',
  styleUrls: ['./tak-list.component.scss']
})
export class TakListComponent implements OnInit {

  private _takken: Tak[];
  constructor(private _dataService: DataService) { }

  ngOnInit() {
    this._dataService.takken.subscribe(items => this._takken = items);
  }

  get takken()  {
    return this._takken;
  }

}
