import {makeEnvironmentProviders} from '@angular/core';
import { CACHE_MANAGEMENT_ROUTE_PROVIDERS } from './providers/route.provider';

export function provideCacheManagementConfig() {
  return makeEnvironmentProviders([CACHE_MANAGEMENT_ROUTE_PROVIDERS])
}
