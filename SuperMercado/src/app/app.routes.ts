import { Routes } from '@angular/router';
import { LoginComponent } from './login/login';
import { Layout } from './layout/layout';
import { Dashboard } from './dashboard/dashboard';
import { Landing } from './landing/landing';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },


  {
    path: 'login',
    component: LoginComponent
  },

  {
    path: '',
    component: Layout,
    children: [
      { path: 'landing', component: Landing, canActivate: [authGuard] },
      { path: 'dashboard', component: Dashboard, canActivate: [authGuard] } 
    ]
  }

];
