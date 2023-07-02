import { Component, OnInit,ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-menu-edit-item',
  templateUrl: './menu-edit-item.component.html',
  styleUrls: ['./menu-edit-item.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class MenuEditItemComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  onSubmit(form: NgForm){
    console.log(form);
  }

}
