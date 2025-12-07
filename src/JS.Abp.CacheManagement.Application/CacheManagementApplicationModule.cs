using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Mapperly;

namespace JS.Abp.CacheManagement;

[DependsOn(
    //typeof(CacheManagementDomainModule),
    typeof(CacheManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpMapperlyModule),
    typeof(AbpCachingStackExchangeRedisModule)
    )]
public class CacheManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMapperlyObjectMapper<CacheManagementApplicationModule>();
    }
}
