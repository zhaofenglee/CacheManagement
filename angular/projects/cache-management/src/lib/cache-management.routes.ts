import { RouterOutletComponent } from '@abp/ng.core';
import { Routes } from '@angular/router';
import { CacheManagementComponent } from './components/cache-management.component';

export const cacheManagementRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: RouterOutletComponent,
    children: [
      {
        path: '',
        component: CacheManagementComponent,
      },
    ],
  },
];
