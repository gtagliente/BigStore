import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
 import { Client } from './big-store-client.service';
 import { DesignKitComponent } from './design-kit/design-kit.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'BigStoreWeb';

    constructor(private clientService:Client){

    }
   ngOnInit() {
   // this.service = new BigStoreClientComponent();

     //this.service = new Client("https://localhost:7008");
    //  console.log('Client: '+this.clientService.baseUrl);
     
    //  console.log('Products  : ');
    //  this.clientService.products().then(
    //   (val) => console.log( val),
    //   (err) => console.log(err)
    // );

    // console.log('Categories: ');
    // this.clientService.categories().then(
    //   (val) => console.log( val),
    //   (err) => console.log(err)
    // );
    }
}
