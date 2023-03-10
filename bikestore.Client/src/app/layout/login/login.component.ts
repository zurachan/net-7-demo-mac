import { AuthenticateService } from './../../shared/services/authenticate.service';
import { Component } from '@angular/core';
import { Login } from 'src/app/model/login.model';

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
  constructor(private authenticateService: AuthenticateService) { }

  OnClickLogin() {
    this.authenticateService.Login(this.model).subscribe((res: any) => {
      debugger;
      
    })
  }

  OnClickForgetPassword() {

  }
}
