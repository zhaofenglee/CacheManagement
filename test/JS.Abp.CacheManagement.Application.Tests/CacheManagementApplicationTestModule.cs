using Volo.Abp.Modularity;

namespace JS.Abp.CacheManagement;

[DependsOn(
    typeof(CacheManagementApplicationModule),
    typeof(CacheManagementTestBase<>)
    )]
public class CacheManagementApplicationTestModule : AbpModule
{

}
