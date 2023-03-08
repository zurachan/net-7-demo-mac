import { CommonModule } from '@angular/common';
import { Component, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SinglecardModule } from './layout/singlecard/singlecard.component';
import { Router } from '@angular/router';

@Component({
    selector: 'app-unauthenticated-content',
    template: `
    <app-singlecard [title]="title" [description]="description">
      <router-outlet></router-outlet>
    </app-singlecard>
  `,
    styles: [`
    :host {
      width: 100%;
      height: 100%;
    }
  `]
})
export class UnauthenticatedContentComponent {

    constructor(private router: Router) {
    }

    get title() {
        return 'Title demo'
        // const path = this.router.url.split('/')[1];
        // switch (path) {
        //     case 'login-form': return 'Sign In';
        //     case 'reset-password': return 'Reset Password';
        //     case 'forgot-password': return 'Forgot Password';
        //     case 'create-account': return 'Sign Up';
        //     default:
        //         return;
        //     //case 'change-password': return 'Change Password';
        // }
    }

    get description() {
        return 'Description demo'
        // const path = this.router.url.split('/')[1];
        // switch (path) {
        //     case 'forgot-password': return '';
        //     case 'reset-password': return 'Reset password';
        //     default:
        //         return;
        // }
    }
}
@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        SinglecardModule
    ],
    declarations: [UnauthenticatedContentComponent],
    exports: [UnauthenticatedContentComponent]
})
export class UnauthenticatedContentModule { }
