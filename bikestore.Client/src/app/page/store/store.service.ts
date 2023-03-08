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
  constructor(private http: HttpClient) { }
  /** GET ALL: select all */
  GetAll(): Observable<Store[]> {
    return this.http.get<Store[]>(`${urlApi}` + `${currentData}`).pipe();
  }
  /** GET ONE: find exactly by id */
  GetById(id: number): Observable<Store> {
    return this.http.get<Store>(`${urlApi}` + `${currentData}` + `/${id}`).pipe();
  }
  /** CREATE: add  new  */
  Insert(model: Store): Observable<Store> {
    return this.http.post<Store>(`${urlApi}` + `${currentData}`, model).pipe();
  }
  /** UPDATE: edit by id */
  Update(model: Store): Observable<Store> {
    return this.http.put<Store>(`${urlApi}` + `${currentData}`, model).pipe();
  }
  /** DELETE: delete from the server by id */
  Delete(id: number): Observable<Store> {
    return this.http.delete<Store>(`${urlApi}` + `${currentData}` + `/${id}`).pipe();
  }
}
