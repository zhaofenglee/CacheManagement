using Volo.Abp.Modularity;

namespace JS.Abp.CacheManagement;

[DependsOn(
    typeof(CacheManagementDomainModule),
    typeof(CacheManagementTestBaseModule)
)]
public class CacheManagementDomainTestModule : AbpModule
{

}
