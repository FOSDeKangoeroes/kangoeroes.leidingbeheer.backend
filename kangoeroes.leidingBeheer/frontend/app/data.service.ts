import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable} from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import { Tak } from './tak/tak.model';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Leiding } from './leiding/leiding.model';



@Injectable()
export class DataService {

  private _takUrl = '/api/tak';

  constructor(private http: Http) { }


  get takken(): Observable<Tak[]> {
    return this.http.get(this._takUrl).map(response =>
      response.json().result.map(item => Tak.fromJSON(item))
    );
  }

  getTak(id): Observable<Tak> {
    return this.http.get(`${this._takUrl}/${id}`)
      .map(response => response.json().result).map(item => Tak.fromJSON(item));
  }

  getLeidingForTak(id): Observable<Leiding[]> {
    return this.http.get(`${this._takUrl}/${id}/leiding`)
      .map(response =>
        response.json().result.map(item => Leiding.fromJSON(item)));
  }
}