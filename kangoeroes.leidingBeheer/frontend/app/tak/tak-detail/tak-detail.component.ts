import { Component, ViewChild, OnInit, Output, EventEmitter } from '@angular/core';
import { Tak } from '../tak.model';
import { ActivatedRoute } from '@angular/router';
import { DataSource, CollectionViewer } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import { Leiding } from '../../leiding/leiding.model';
import { DataService } from '../../data.service';
import { ModalDirective } from 'ngx-bootstrap/modal/modal.component';
import { Router } from '@angular/router/src/router';
import { ModalContainerComponent } from 'ngx-bootstrap/modal/modal-container.component';
import { BsModalService } from 'ngx-bootstrap/modal/bs-modal.service';
import { BsModalRef } from 'ngx-bootstrap/modal/modal-options.class';
import { TakEditComponent } from '../tak-edit/tak-edit.component';
import { TakDeleteComponent } from '../tak-delete/tak-delete.component';
import { TakLeidingAddComponent } from '../tak-leiding-add/tak-leiding-add.component';




@Component({
  selector: 'app-tak-detail',
  templateUrl: './tak-detail.component.html',
  styleUrls: ['./tak-detail.component.scss']
})
export class TakDetailComponent implements OnInit {

  // Modals
  public editModal: BsModalRef;
  public deleteModal: BsModalRef;
  public addLeidingModal: BsModalRef;

  // Entity
  private _tak: Tak;
  public hasLeiding: boolean;

  // Angular Material table
  private _dataSource: LeidingDataSource;
  displayedColumns = ['naam', 'email', 'leidingSinds', 'datumGestopt'];

  constructor(private route: ActivatedRoute,
    private dataService: DataService,
    private modalService: BsModalService) {
  }
  ngOnInit() {
    this.route.data.subscribe(item => this._tak = item['tak']);
    this._dataSource = new LeidingDataSource(this.dataService, this._tak.id);
    this.hasLeiding = this._tak.leiding.length > 0;

  }

  get tak() {
    return this._tak;
  }

  get dataSource() {
    return this._dataSource;
  }

  openEditModal() {
    this.editModal = this.modalService.show(TakEditComponent);
    this.editModal.content.takId = this._tak.id;
    this.editModal.content.naam = this._tak.naam;
    this.editModal.content.volgorde = this._tak.volgorde;
  }

  openDeleteModal() {
    this.deleteModal = this.modalService.show(TakDeleteComponent);
    this.deleteModal.content.takId = this._tak.id;
    this.deleteModal.content.title = this._tak.naam;

  }

  openAddModal() {
    this.addLeidingModal = this.modalService.show(TakLeidingAddComponent);
    this.addLeidingModal.content.naam = this._tak.naam;
    this.addLeidingModal.content.takId = this._tak.id;
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
