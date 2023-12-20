using Volo.Abp.Modularity;

namespace JS.Abp.CacheManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class CacheManagementApplicationTestBase<TStartupModule> : CacheManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
