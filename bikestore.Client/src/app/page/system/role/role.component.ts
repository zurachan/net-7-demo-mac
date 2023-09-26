import { Component, OnInit } from '@angular/core';
import { RoleService } from 'src/app/shared/services/role.service';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']
})
export class RoleComponent implements OnInit {

  constructor(private roleService: RoleService) { }

  ngOnInit() {
    this.roleService.GetAll().subscribe((res: any) => {
      if (res.success) {
        console.log(res.data)
      }
    });
  }

}
