import { Component, OnInit, Input } from '@angular/core';
import { Tak } from '../tak.model';

@Component({
  selector: 'app-tak',
  templateUrl: './tak.component.html',
  styleUrls: ['./tak.component.scss']
})
export class TakComponent implements OnInit {

  @Input() public tak: Tak;
  constructor() { }

  ngOnInit() {
  }

}
