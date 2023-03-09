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
  },
  {
    path: 'store/:id',
    component: StoreDetailComponent,
  },
  {
    path: 'staff',
    component: StaffComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
