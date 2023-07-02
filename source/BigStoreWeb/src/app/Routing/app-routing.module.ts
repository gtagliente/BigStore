import { NgModule } from '@angular/core';
import { Routes, RouterModule, RouteReuseStrategy } from '@angular/router';
import { MenuPanelComponent } from '../Menu/menu-panel/menu-panel.component';
import { MenuItemComponent } from '../Menu/menu-item/menu-item.component';
import { CustomReuseStrategy } from './route-reuse-strategy';
import { MenuComponent } from '../Menu/menu.component';
import { DesignKitComponent } from '../design-kit/design-kit.component';

// const appRoutes: Routes = [
//     { path: '', component: MenuPanelComponent},
//     { path: 'MenuPanel/:type', component: MenuPanelComponent}
//   ];

  const appRoutes: Routes = [
    { path: '', component: MenuComponent},
    { path: 'MenuPanel', component: MenuComponent,
    children: [
      {path: '', redirectTo: '0', pathMatch: 'full'},
      {path: ':type', component: MenuPanelComponent}
    ]
    },
    { path: 'design-kit', component: DesignKitComponent }
  ];


@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  providers: [
    {
      provide: RouteReuseStrategy,
      useClass: CustomReuseStrategy
    }
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
