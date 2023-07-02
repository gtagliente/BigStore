import { AfterViewInit, Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { Category, Client } from '../big-store-client.service';
import { RouterAnimations } from '../Animations/router.animation';
import { Observable } from 'rxjs/internal/Observable';
import { ItemsRoutingService } from './items-routing.service';
import { map, pairwise, share, startWith } from 'rxjs';



@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
  encapsulation: ViewEncapsulation.None,
  providers: [ItemsRoutingService],
  animations: [
    RouterAnimations.routeSlide,
    RouterAnimations.buttonClick
  ]
})


export class MenuComponent implements AfterViewInit {
  dumbCounter: number = 0;
  categories: Category[] = [];
  subCategories: Category[] = [];
  // constructor(){
  //   this.clientService.categories().then(
  //     (val) => this.categories = val,
  //     (err) => console.log(err)
  //   );
  // }

  constructor(
    itemsRouting: ItemsRoutingService, private clientService: Client) {
      console.log(this.categories)
      console.log(this.subCategories);
    this.clientService.getCategories().then(
      (val) =>{ this.categories = val},
      (err) => console.log(err)
    );
    //this.items = itemsService.getItems();
    this.itemChange$ = itemsRouting.itemChange$;

    this.setupRouting();
  }

  itemChange$: Observable<number>;
  next$!: Observable<number>;
  prev$!: Observable<number>;
  routeTrigger$!: Observable<object>;


  getState(outletRef: RouterOutlet) {
    console.log('getState outletRef: ');
    console.log(outletRef);
    console.log('returning value: ');
    console.log(outletRef.activatedRoute.snapshot.params['type']);
    return {
      value:  outletRef.activatedRoute.snapshot.params['type']
    }
  }


  RiseCounter() {
    console.log('routeTrigger: ');
    console.log(this.routeTrigger$);
 
  }
  // ngOnInit() {
  //   console.log('Init menu component')
  //   console.log( $('ul.nav.nav-tabs.mu-restaurant-menu li'));
  //   var x =  $('ul.mu-restaurant-menu');
  // }

  ngAfterViewInit() {
    //$($('ul.nav.nav-tabs.mu-restaurant-menu li').get(0)).addClass('active');
  }

  private setupRouting() {
    console.log('Setting up routing');
    this.prev$ = this.itemChange$
      .pipe(
        map(index => {
          let newIndex: number;
          console.log('Mapping prev Index: ' + index);
          newIndex = index === 0 ? index : index - 1;
          console.log('New prev Index: ' + newIndex);
          return newIndex;
        }
        ),
        share()
      );
    this.next$ = this.itemChange$
      .pipe(
        map(index => {
          let newIndex: number;
          console.log('Mapping next Index: ' + index);
          newIndex = index === this.categories.length - 1 ? index : index + 1;
          console.log('New next Index: ' + newIndex);
          return newIndex;
        }
        ),
        share()
      )

    this.routeTrigger$ = this.itemChange$
      .pipe(
        startWith(0),
        pairwise(),
        map(([prev, curr]) => {
          console.log(' RouteTrigger ');
          console.log('Previous: ' + prev);
          console.log('Current: ' + curr);
          console.log('GetSubCategories for CategoryId: '+curr);
          // if(this.categories.filter(c=> c.categoryId == curr).length>0){

            
          // }
          // else{
            
          // }
          this.clientService.getWithSubCategories(curr).then(
          (val) => {
            if(this.categories.filter(c=> c.categoryId == curr).length>0){
              this.subCategories = val.filter(c => c.categoryId != curr);
            }
            if(this.subCategories.filter(c=> c.categoryId == curr).length>0){
              this.categories = this.subCategories;
              this.subCategories = val.filter(c => c.categoryId != curr);
            }
            else{
              //this.categories = val.filter(c => c.categoryId != curr)
            }
          },
          (err) => console.log(err)
          );
          console.log('GetSubCategories list: ');
          console.log(this.subCategories);
          return {
            value: curr,
            params: {
              offsetEnter: prev > curr ? 100 : -100,
              offsetLeave: prev > curr ? -100 : 100
            }
          }
        },
        
        ),
      );

      // map(([prev, curr])=>{
      //   console.log('GetSubCategories for CategoryId: '+curr);
      //   this.clientService.getWithSubCategories(curr).then(
      //     (val) => this.subCategories = val,
      //     (err) => console.log(err)
      //     );
      //     console.log('GetSubCategories list: ');
      //     console.log(this.subCategories);
      // })

      // this.next$.subscribe(
      //   (next) => {
      //     console.log('GetSubCategories for CategoryId: '+next);
      //   this.clientService.getWithSubCategories(next).then(
      //     (val) => this.subCategories = val,
      //     (err) => console.log(err)
      //     );
      //     console.log('GetSubCategories list: ');
      //     console.log(this.subCategories);
      //   }
        
      // );
  }


}
