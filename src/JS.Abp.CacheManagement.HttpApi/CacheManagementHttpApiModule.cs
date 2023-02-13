using Localization.Resources.AbpUi;
using JS.Abp.CacheManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace JS.Abp.CacheManagement;

[DependsOn(
    typeof(CacheManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class CacheManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CacheManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CacheManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
