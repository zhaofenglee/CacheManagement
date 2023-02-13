import { ModuleWithProviders, NgModule } from '@angular/core';
import { CACHE_MANAGEMENT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class CacheManagementConfigModule {
  static forRoot(): ModuleWithProviders<CacheManagementConfigModule> {
    return {
      ngModule: CacheManagementConfigModule,
      providers: [CACHE_MANAGEMENT_ROUTE_PROVIDERS],
    };
  }
}
