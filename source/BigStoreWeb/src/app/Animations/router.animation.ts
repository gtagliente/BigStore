import { trigger, transition, group, query, style, animate } from '@angular/animations';

export class RouterAnimations {
  static routeSlide =
  trigger('routeSlide', [
    transition('* <=> *', [
      group([
        query(':enter', [
          style({transform: 'translateX(-100%)'}),
          animate('0.4s ease-in-out', style({transform: 'translateX(0%)'}))
        ], {optional: true}),
        query(':leave', [
          style({transform: 'translateX(0%)'}),
          animate('0.4s ease-in-out', style({transform: 'translateX(100%)'}))
        ], {optional: true}),
      ])
    ]),
  ]);
 static buttonClick = 
    trigger('buttonClick', [
      transition('* <=> *',
      animate('2s 1s ease-in', style({backgroundColor:'red',transform: 'translateX(10%)'}))
      )
    ]);


    // static routeSlide =
    // trigger('routeSlide', [
    //   transition('* <=> *', [
    //     style({ position: 'relative' }),
    //     query(':enter, :leave', [
    //       style({
    //         position: 'absolute',
    //         top: 0,
    //         left: 0,
    //         width: '100%'
    //       })
    //     ]),
    //     query(':enter', [
    //       style({ left: '-100%' })
    //     ]),
    //    // query(':leave', animateChild()),
    //     group([
    //       query(':leave', [
    //         animate('3s ease-out', style({ left: '100%' }))
    //       ]),
    //       query(':enter', [
    //         animate('3s ease-out', style({ left: '0%' }))
    //       ]),
    //     ]),
    //   ])
    // ]);
}
    