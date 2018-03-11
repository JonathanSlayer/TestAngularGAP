import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
@Injectable()
export class CarServiceService {

  constructor(private http: Http) { }

  public getCarJSON(): Observable<any> {
    return this.http.get("./assets/Mocks/carlist.mock.json")
      .map((res: any) => res.json());

  }
  public getCarbyId(id: number): Observable<any> {
    return this.http.get("./assets/Mocks/carlist.mock.json")
      .map((res: any) => res.json().find(car => car.id == id));
  }
}
