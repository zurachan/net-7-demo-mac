import { GoogleLogin } from './../../model/google-login.model';
import { NotifierService } from 'angular-notifier';
import { AuthenticateService } from './../../shared/services/authenticate.service';
import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/model/login.model'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model = new Login();

  /**
   *
   */
  constructor(private authenticateService: AuthenticateService, private notifier: NotifierService) { }
  ngOnInit(): void {
    (window as any).handleCredentialResponse = async (res: any) => {
      let model = new GoogleLogin();
      model.googleTokenId = res.credential;
      await this.OnClickLoginGoogle(model);
    }
  }

  async OnClickLogin() {
    this.model.email.trim();
    this.model.password.trim();
    const loginResult = await this.authenticateService.Login(this.model);
    if (!loginResult.isOk) {
      this.notifier.notify('error', loginResult.message);
    }
  }

  async OnClickLoginGoogle(model: GoogleLogin) {
    let loginResult = await this.authenticateService.LoginWithGoogle(model);
    if (!loginResult.isOk) {
      this.notifier.notify('error', loginResult.message);
    }
  }

  OnClickForgetPassword() {

  }
}
