import { GoogleLogin } from './../../model/google-login.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from 'src/app/model/login.model';
import { Register } from 'src/app/model/register.model';

const urlApi = 'https://localhost:7071/';
const currentData = 'account';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  // Call api
  Signup(model: Register): Observable<Register> {
    return this.http.post<Register>(`${urlApi}` + `${currentData}` + "/signup", model).pipe();
  }

  Login(model: Login) {
    return this.http.post(`${urlApi}` + `${currentData}` + "/login", model);
  }

  LoginWithGoogle(model: GoogleLogin) {
    return this.http.post(`${urlApi}` + `${currentData}` + "/googlelogin", model);
  }
}
