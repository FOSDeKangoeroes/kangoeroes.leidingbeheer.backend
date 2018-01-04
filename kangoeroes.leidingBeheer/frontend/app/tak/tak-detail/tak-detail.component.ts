import { Component, ViewChild, OnInit, Output, EventEmitter } from '@angular/core';
import { Tak } from '../tak.model';
import { ActivatedRoute } from '@angular/router';
import { DataSource, CollectionViewer } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import { Leiding } from '../../leiding/leiding.model';
import { DataService } from '../../data.service';
import { ModalDirective } from 'ngx-bootstrap/modal/modal.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router/src/router';
import { ModalContainerComponent } from 'ngx-bootstrap/modal/modal-container.component';




@Component({
  selector: 'app-tak-detail',
  templateUrl: './tak-detail.component.html',
  styleUrls: ['./tak-detail.component.scss']
})
export class TakDetailComponent implements OnInit {

  // Modals
  public editModal;
  public deleteModal;

  // Entity
  private _tak: Tak;
  public hasLeiding: boolean;

  // Wijzigen
  @Output() public updatedTak = new EventEmitter<Tak>();
  public editDebtFormGroup: FormGroup;

  // Angular Material table
  private _dataSource: LeidingDataSource;
  displayedColumns = ['naam', 'email', 'leidingSinds', 'datumGestopt'];

  constructor(private route: ActivatedRoute, private dataService: DataService, private fb: FormBuilder) {
  }
  ngOnInit() {
    this.route.data.subscribe(item => this._tak = item['tak']);
    this._dataSource = new LeidingDataSource(this.dataService, this._tak.id);
    this.hasLeiding = this._tak.leiding.length > 0;

    this.editDebtFormGroup = this.fb.group({
      naam: ['', [Validators.required, Validators.minLength(2)]],
      volgorde: ['', [Validators.required]]

    });
  }

  get tak() {
    return this._tak;
  }

  get dataSource() {
    return this._dataSource;
  }

  onSubmit() {

  }

  onDelete() {

  }

  onAdd() {

  }

}

// Datasource voor de tabel
export class LeidingDataSource extends DataSource<any> {
  constructor(private dataService: DataService, private takId: number) {
    super();
  }
  connect(collectionViewer: CollectionViewer): Observable<any[]> {
    return this.dataService.getLeidingForTak(this.takId);
  }
  disconnect(collectionViewer: CollectionViewer): void { }

}
