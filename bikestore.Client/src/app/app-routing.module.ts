import { AuthenticateGuard } from './shared/services/authenticate.service';
import { SignupComponent } from './layout/signup/signup.component';
import { LoginComponent } from './layout/login/login.component';
import { StoreDetailComponent } from './page/store/store.detail/store.detail.component';
import { StaffComponent } from './page/staff/staff.component';
import { StoreComponent } from './page/store/store.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'signup',
    component: SignupComponent,
  },
  {
    path: 'store',
    component: StoreComponent,
    canActivate: [AuthenticateGuard]
  },
  {
    path: 'store/:id',
    component: StoreDetailComponent,
  },
  {
    path: 'staff',
    component: StaffComponent,
  },
  {
    path: 'system',
    loadChildren: () => import('../app/page/system/system.module').then((m) => m.SystemModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
