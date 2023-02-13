using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.Caching.StackExchangeRedis;

namespace JS.Abp.CacheManagement;

[DependsOn(
    //typeof(CacheManagementDomainModule),
    typeof(CacheManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpCachingStackExchangeRedisModule)
    )]
public class CacheManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<CacheManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CacheManagementApplicationModule>(validate: true);
        });
    }
}
