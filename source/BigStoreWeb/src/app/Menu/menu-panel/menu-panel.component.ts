import {
   Component,
   ViewEncapsulation,
   Input,
   OnInit,
   OnChanges
 } from '@angular/core';

import { ActivatedRoute,Params, RouterOutlet } from '@angular/router';
import { Client, Product } from 'src/app/big-store-client.service';
import { ItemsRoutingService } from '../items-routing.service';

@Component({
  selector: 'app-menu-panel',
  templateUrl: './menu-panel.component.html',
  styleUrls: ['./menu-panel.component.css'],
  // encapsulation: ViewEncapsulation.None
})
export class MenuPanelComponent implements OnInit {
    public selectedPaneType: number | undefined = 0 ;

  productList: Product[] = [];

  constructor(private clientService:Client, private route: ActivatedRoute, itemsRouting: ItemsRoutingService) {
    console.log('Costruttore MenuPanelComponent');
      let index  = route.snapshot.params['type'];
    console.log(route.snapshot.params['type']);
    console.log('Index: '+index);

    itemsRouting.itemChange$.next(+index);
  }

  ngOnInit() {
    console.log('init');
   // this.dishList = this.dishService.getDishesByType(this.paneType);
    this.route.params.subscribe(
        (params:Params) =>{
          this.productList = [];
          let type : number | undefined;
          type = params['type'];
          this.selectedPaneType =type;
          console.log(type);
          this.clientService.getProducts().then(
            (val) => {
              console.log('meny panel Products: ');
              console.log(val);
              for(var i=0; i<val.length;i++)
                if(this.selectedPaneType == val[i].categoryId) 
                  this.productList.push(val[i]);
              console.log('ProductList calcolata');
              console.log(this.productList);
            },
            (err) => console.log(err)
          );
        }
    );
  }
}
