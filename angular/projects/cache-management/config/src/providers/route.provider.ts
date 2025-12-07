import { eLayoutType, RoutesService } from '@abp/ng.core';
import { inject, provideAppInitializer } from '@angular/core';
import { eCacheManagementRouteNames } from '../enums/route-names';

export const CACHE_MANAGEMENT_ROUTE_PROVIDERS = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

export function configureRoutes() {
  const routesService = inject(RoutesService);
  routesService.add([
    {
      path: '/cache-management',
      name: eCacheManagementRouteNames.CacheManagement,
      iconClass: 'fas fa-book',
      layout: eLayoutType.application,
      order: 3,
    },
  ]);
}
