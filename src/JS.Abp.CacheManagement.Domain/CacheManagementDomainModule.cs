using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace JS.Abp.CacheManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CacheManagementDomainSharedModule)
)]
public class CacheManagementDomainModule : AbpModule
{

}
