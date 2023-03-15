import { ToastrService } from 'ngx-toastr';
import { AuthenticateService } from './../../shared/services/authenticate.service';
import { Register } from './../../model/register.model';
import { Component } from '@angular/core';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  model = new Register();

  /**
   *
   */
  constructor(private authenticateService: AuthenticateService, private toast: ToastrService) { }
  async OnClickRegister() {
    let result = await this.authenticateService.Signup(this.model);
  }
}
