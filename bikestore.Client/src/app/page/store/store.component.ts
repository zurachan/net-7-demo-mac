import { StoreService } from './store.service';
import { Store } from './../../model/store.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css'],
})
export class StoreComponent implements OnInit {
  store!: Store[];
  constructor(
    private service: StoreService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.InitData();
  }

  InitData() {
    this.service.GetAll().subscribe((res: any) => {
      this.store = res.data;
    });
  }

  OnDelete(model: Store) {
    this.service.Delete(model.id).subscribe((res: any) => {
      this.InitData();
    })
  }

  OnEdit(model: Store) {
    this.router.navigateByUrl('/store/' + model.id);
  }
}
