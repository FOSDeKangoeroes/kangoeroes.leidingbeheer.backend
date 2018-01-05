import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Tak } from '../tak.model';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { DataService } from '../../data.service';
import { Router } from '@angular/router';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'modal-content',
  templateUrl: './tak-edit.component.html',
  styleUrls: ['./tak-edit.component.scss']
})
export class TakEditComponent implements OnInit {

  // Wijzigen
  public editTakFormGroup: FormGroup;

 // tak: Tak;
  naam: string;
  volgorde: number;
  takId: number;

  constructor(public editModalRef: BsModalRef, private fb: FormBuilder, private dataService: DataService, private _router: Router) { }

  ngOnInit() {
    this.editTakFormGroup = this.fb.group({
      naam: ['', [Validators.required, Validators.minLength(2)]],
      volgorde: ['', [Validators.required, , Validators.min(1)]]

    });
  }

  onSubmit() {
   const tak = new Tak(this.editTakFormGroup.value.naam, this.editTakFormGroup.value.volgorde);
    tak.id = this.takId;
    this.dataService.updateTak(tak).subscribe(res => {
      if (res) {
        this.editModalRef.hide();
        this._router.navigate(['tak']);
      }
    });

  }

}
