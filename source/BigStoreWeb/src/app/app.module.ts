import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER } from '@angular/core';
import { AppConfigService }       from './Config/app.config';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { BigStoreClientService, Client } from './big-store-client.service';
import {HttpClient, HttpClientModule, HttpHandler} from '@angular/common/http';
import { MenuComponent } from './Menu/menu.component';
import { RouterModule, Routes } from '@angular/router';
import { MenuPanelComponent } from './Menu/menu-panel/menu-panel.component';
import { MenuItemComponent } from './Menu/menu-item/menu-item.component';
import { AppRoutingModule } from './Routing/app-routing.module';




// const appRoutes: Routes = [
//     { path: '', component: MenuPanelComponent},
//     { path: 'MenuPanel/:type', component: MenuPanelComponent}
//   ];


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    MenuPanelComponent,
    MenuItemComponent
  ],
  imports: [
    BrowserModule,
    //RouterModule.forRoot(appRoutes),
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      multi: true,
      deps: [AppConfigService],
      useFactory: (appConfigService: AppConfigService) => {
        return () => {
          //Make sure to return a promise!
          return appConfigService.loadAppConfig();
        };
      }
    },
    {
      provide: Client,
      deps: [AppConfigService],
      useFactory: (appConfigService: AppConfigService) => {
          return new Client(appConfigService.apiBaseUrl);
      }
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
