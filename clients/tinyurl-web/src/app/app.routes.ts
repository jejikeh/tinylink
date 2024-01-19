import { Route } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AppComponent } from './app.component';

export const appRoutes: Route[] = [
  {
    path: '',
    component: AppComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
  },
];
