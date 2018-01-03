import { Component, OnInit } from '@angular/core';
import { Tak } from '../tak.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tak-detail',
  templateUrl: './tak-detail.component.html',
  styleUrls: ['./tak-detail.component.scss']
})
export class TakDetailComponent implements OnInit {
private _tak: Tak;

  constructor(private route: ActivatedRoute) { }

  get tak() {
    return this._tak;
  }

  ngOnInit() {
    this.route.data.subscribe(item => this._tak = item['tak']);
  }

}
