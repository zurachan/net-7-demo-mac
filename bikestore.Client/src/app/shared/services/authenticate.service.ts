import { Register } from './../../model/register.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const urlApi = 'https://localhost:7071/';
const currentData = 'account';

@Injectable({
  providedIn: 'root'
})

export class AuthenticateService {
  constructor(private http: HttpClient) { }

  IsAuthenticated: boolean = false;

  Logout(authenticated: boolean) {
    this.IsAuthenticated = authenticated;
  }

  Signup(model: Register): Observable<Register> {
    return this.http.post<Register>(`${urlApi}` + `${currentData}` + "/signup", model).pipe();
  }
}
