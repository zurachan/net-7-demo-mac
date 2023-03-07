import { StoreDetailComponent } from './page/store/store.detail/store.detail.component';
import { StaffComponent } from './page/staff/staff.component';
import { StoreComponent } from './page/store/store.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
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
export class AppRoutingModule {}
