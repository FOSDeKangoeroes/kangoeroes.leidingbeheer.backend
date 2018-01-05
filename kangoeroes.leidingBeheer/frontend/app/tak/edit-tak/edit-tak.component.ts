import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Tak } from '../tak.model';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'modal-content',
  templateUrl: './edit-tak.component.html',
  styleUrls: ['./edit-tak.component.scss']
})
export class EditTakComponent implements OnInit {

  // Wijzigen
  @Output() public updatedTak = new EventEmitter<Tak>();
  public editDebtFormGroup: FormGroup;
  title: string;

  constructor(public editModalRef: BsModalRef, private fb: FormBuilder) { }

  ngOnInit() {
    this.editDebtFormGroup = this.fb.group({
      naam: ['', [Validators.required, Validators.minLength(2)]],
      volgorde: ['', [Validators.required]]

    });
  }

  onSubmit()
  {
    this.editModalRef.hide();
  }

}
