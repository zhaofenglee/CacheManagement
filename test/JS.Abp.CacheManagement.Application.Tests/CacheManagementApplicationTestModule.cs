using Volo.Abp.Modularity;

namespace JS.Abp.CacheManagement;

[DependsOn(
    typeof(CacheManagementApplicationModule),
    typeof(CacheManagementDomainTestModule)
    )]
public class CacheManagementApplicationTestModule : AbpModule
{

}
