import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SystemRoutingModule } from './system-routing.module';
import { RoleComponent } from './role/role.component';
import { MenuComponent } from './menu/menu.component';

@NgModule({
  declarations: [
    RoleComponent,
    MenuComponent
  ],
  imports: [
    CommonModule, SystemRoutingModule
  ],
})
export class SystemModule { }
