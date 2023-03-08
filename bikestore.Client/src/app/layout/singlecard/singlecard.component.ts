import { Component, Input, NgModule } from '@angular/core';

@Component({
  selector: 'app-singlecard',
  templateUrl: './singlecard.component.html',
  styleUrls: ['./singlecard.component.css']
})
export class SinglecardComponent {
  @Input()
  title!: string;

  @Input()
  description!: string;
  
  constructor() { }
}

@NgModule({
  imports: [],
  exports: [SinglecardComponent],
  declarations: [SinglecardComponent]
})

export class SinglecardModule {

}