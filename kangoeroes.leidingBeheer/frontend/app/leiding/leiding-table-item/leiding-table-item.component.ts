import { Component, OnInit, Input } from '@angular/core';
import { Leiding } from '../leiding.model';

@Component({
  selector: 'app-leiding-table-item',
  templateUrl: './leiding-table-item.component.html',
  styleUrls: ['./leiding-table-item.component.scss']
})
export class LeidingTableItemComponent implements OnInit {

  @Input() public leiding: Leiding;

  constructor() { }

  ngOnInit() {
  }

}
