import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './menu/menu.component';
import { RoleComponent } from './role/role.component';

const routes: Routes = [
  { path: 'menu', component: MenuComponent },
  { path: 'role', component: RoleComponent },
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class SystemRoutingModule { }
