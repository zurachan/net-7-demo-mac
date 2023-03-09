import { AuthenticateService } from './shared/services/authenticate.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'bikestore.Client';
  IsAuthenticated!: boolean;

  /**
   *
   */
  constructor(private authenticateService: AuthenticateService) {
    this.IsAuthenticated = authenticateService.IsAuthenticated;
  }

  Logout(authenticated: boolean) {
    this.authenticateService.Logout(authenticated);
    this.IsAuthenticated = authenticated;
  }
}
