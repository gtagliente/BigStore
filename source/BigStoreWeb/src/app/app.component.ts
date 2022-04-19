import { Component, OnInit } from '@angular/core';
import { BigStoreClientComponent, Client } from './big-store-client/big-store-client.component';
import {HttpClient} from "@angular/common/http";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'BigStoreWeb';
    service!: Client; 

    constructor(private http:HttpClient){

    }
   ngOnInit() {
   // this.service = new BigStoreClientComponent();

     this.service = new Client("https://localhost:7008");
     console.log('Products: ');
     this.service.products().then(
      (val) => console.log( val),
      (err) => console.log(err)
    );

    console.log('Categories: ');
    this.service.categories().then(
      (val) => console.log( val),
      (err) => console.log(err)
    );
    }
}
