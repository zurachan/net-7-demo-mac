import { StoreService } from './../store.service';
import { Store } from './../../../model/store.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-store.detail',
  templateUrl: './store.detail.component.html',
  styleUrls: ['./store.detail.component.css'],
})
export class StoreDetailComponent implements OnInit {
  store = new Store();

  constructor(
    private activatedRoute: ActivatedRoute,
    private service: StoreService
  ) { }

  ngOnInit() {
    this.InitData();
  }

  InitData() {
    let id = this.activatedRoute.snapshot.params['id'];
    if (id > 0) {
      this.service.GetById(id).subscribe((res: any) => {
        this.store = res.data;
        return;
      })
    }
    this.store.id = 0;
  }

  OnSubmit() {
    if (this.store.id === 0) {
      this.store.id = 0;
      this.service.Insert(this.store).subscribe((res: any) => {
        if (res.success) {
          this.store = res.data;
        }
      });
    } else {
      this.service.Update(this.store).subscribe((res: any) => {
        if (res.success) {
          this.store = res.data;
        }
      })
    }
  }
}
