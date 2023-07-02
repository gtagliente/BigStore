import { Component, OnInit, Input,ViewEncapsulation } from '@angular/core';
import { Product } from 'src/app/big-store-client.service';


@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class MenuItemComponent implements OnInit {
  @Input() item!: Product;


  constructor() { }

  ngOnInit() {
    // popupInitialize();
  }

}
