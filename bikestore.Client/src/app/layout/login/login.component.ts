import { NotifierModule, NotifierService } from 'angular-notifier';
import { AuthenticateService } from './../../shared/services/authenticate.service';
import { Component } from '@angular/core';
import { Login } from 'src/app/model/login.model'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  model = new Login();

  /**
   *
   */
  constructor(private authenticateService: AuthenticateService, private notifier: NotifierService) { }

  async OnClickLogin() {
    this.model.email.trim();
    this.model.password.trim();
    const loginResult = await this.authenticateService.Login(this.model);
    if (!loginResult.isOk) {
      this.notifier.notify('error', loginResult.message);
    }
  }

  OnClickForgetPassword() {

  }
}
