﻿using Volo.Abp.Modularity;

namespace JS.Abp.CacheManagement;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class CacheManagementDomainTestBase<TStartupModule> : CacheManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
