import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CacheManagementComponent } from './components/cache-management.component';
import { CacheManagementRoutingModule } from './cache-management-routing.module';

@NgModule({
  declarations: [CacheManagementComponent],
  imports: [CoreModule, ThemeSharedModule, CacheManagementRoutingModule],
  exports: [CacheManagementComponent],
})
export class CacheManagementModule {
  static forChild(): ModuleWithProviders<CacheManagementModule> {
    return {
      ngModule: CacheManagementModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CacheManagementModule> {
    return new LazyModuleFactory(CacheManagementModule.forChild());
  }
}
