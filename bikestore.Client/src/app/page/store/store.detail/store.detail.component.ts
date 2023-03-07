import { StoreService } from './../store.service';
import { Store } from './../../../model/store.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-store.detail',
  templateUrl: './store.detail.component.html',
  styleUrls: ['./store.detail.component.css'],
})
export class StoreDetailComponent implements OnInit {
  store!: Store;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private service: StoreService
  ) {}

  ngOnInit() {
    this.store = history.state;
    console.log(this.store.id);
  }

  OnSubmit() {
    if (this.store.id === undefined) {
      this.store.id = 0;
    } else {
    }
  }
}
