import { Store } from './../../model/store.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const urlApi = 'https://localhost:7071/';
const currentData = 'store';

@Injectable({
  providedIn: 'root',
})
export class StoreService {
  constructor(private http: HttpClient) {}
  /** GET ALL: select all brand */
  GetAll(): Observable<Store[]> {
    return this.http.get<Store[]>(`${urlApi}` + `${currentData}`).pipe();
  }
}
