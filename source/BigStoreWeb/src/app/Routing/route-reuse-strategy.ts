import { ActivatedRouteSnapshot, DetachedRouteHandle, RouteReuseStrategy } from '@angular/router';
import { MenuPanelComponent } from '../Menu/menu-panel/menu-panel.component';

export class CustomReuseStrategy implements RouteReuseStrategy {

  handlers: {[key: string]: DetachedRouteHandle} = {};

  shouldDetach(route: ActivatedRouteSnapshot): boolean {
    return false;
  }

  store(route: ActivatedRouteSnapshot, handle: DetachedRouteHandle): void {
     let  path: string = route.routeConfig?.path!;
    this.handlers[path] = {};
  }

  shouldAttach(route: ActivatedRouteSnapshot): boolean {
    return !!route.routeConfig && !!this.handlers[route.routeConfig?.path!];
  }

  retrieve(route: ActivatedRouteSnapshot): DetachedRouteHandle {
    if (!route.routeConfig) {
      return {};
    }
    return this.handlers[route.routeConfig?.path!];
  }

  shouldReuseRoute(future: ActivatedRouteSnapshot, curr: ActivatedRouteSnapshot): boolean {
    console.log('CurrentComponent: ');
    console.log(curr.component);
    let shoulReuseBool = curr.component !== MenuPanelComponent;
    console.log('Should reuse result: '+ shoulReuseBool);
    return shoulReuseBool;
  }
}
