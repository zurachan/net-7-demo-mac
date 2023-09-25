import { GoogleLogin } from './../../model/google-login.model';
import { Router } from '@angular/router';
import { Register } from './../../model/register.model';
import { UserService } from './user.service';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, lastValueFrom } from 'rxjs';
import { AuthenRequest } from 'src/app/model/login.model';
import { Credential } from 'src/app/model/credential.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { SocialAuthService } from '@abacritt/angularx-social-login';

@Injectable({
  providedIn: 'root'
})

export class AuthenticateService {
  constructor(private userService: UserService,
    private router: Router,
    private authGoogleService: SocialAuthService) {
    this.credentialSubject = new BehaviorSubject<Credential>(
      JSON.parse(localStorage.getItem('token'))
    );
    this.credential = this.credentialSubject.asObservable();
  }

  private credentialSubject: BehaviorSubject<Credential>;
  public credential: Observable<Credential>;

  get LoggedIn(): boolean {
    return !!this.credentialSubject.value;
  }

  get GetToken() {
    return this.credentialSubject.value;
  }

  Logout() {
    localStorage.removeItem('token');
    this.credentialSubject.next(null);
    this.authGoogleService.signOut();
    this.router.navigate(['/login']);
  }

  async Login(model: AuthenRequest) {
    try {
      let rs = await lastValueFrom<any>(this.userService.Login(model));
      if (rs.success) {
        let credential = new Credential();
        credential.token = rs.data.token;
        this.credentialSubject.next(credential);

        localStorage.setItem('token', JSON.stringify(rs.data.token));
        this.router.navigate(['']);
        return {
          isOk: true,
          data: credential,
          message: '',
        };
      } else {
        return {
          isOk: false,
          data: this.credentialSubject.value,
          message: rs.message,
        };
      }
    } catch {
      return {
        isOk: false,
        message: 'Authentication failed',
      };
    }
  }

  async LoginWithGoogle(model: GoogleLogin) {
    try {
      let rs = await lastValueFrom<any>(this.userService.LoginWithGoogle(model));
      if (rs.success) {
        let credential = new Credential();
        credential.token = rs.data.token;
        this.credentialSubject.next(credential);
        localStorage.setItem('token', JSON.stringify(rs.data));
        this.router.navigate(['']);
        return {
          isOk: true,
          data: credential,
          message: '',
        };
      } else {
        return {
          isOk: false,
          data: this.credentialSubject.value,
          message: rs.message,
        };
      }
    } catch {
      return {
        isOk: false,
        message: 'Authentication failed',
      };
    }
  }

  LogoutGoogle() {
    this.authGoogleService.signOut();
  }

  async Signup(model: Register) {

  }
}

const jwtHelperService = new JwtHelperService();

@Injectable({
  providedIn: 'root'
})

export class AuthenticateGuard {
  constructor(
    private authService: AuthenticateService,
  ) { }

  canActivate(): boolean {
    let isLoggedIn = this.authService.LoggedIn;
    let currentUser = this.authService.GetToken;

    //Check if the token is expired or not and if token is expired then redirect to login page and return false
    if (isLoggedIn && currentUser.token && !jwtHelperService.isTokenExpired(currentUser.token)) {
      return true;
    }
    this.authService.Logout();
    return false;
  }
}