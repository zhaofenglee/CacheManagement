using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using JS.Abp.CacheManagement.Localization;
using JS.Abp.CacheManagement.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using JS.Abp.CacheManagement.Permissions;
using Volo.Abp.Mapperly;

namespace JS.Abp.CacheManagement.Web;

[DependsOn(
    typeof(CacheManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpMapperlyModule)
    )]
public class CacheManagementWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(CacheManagementResource), typeof(CacheManagementWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CacheManagementWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new CacheManagementMenuContributor(configuration));
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CacheManagementWebModule>();
        });

        context.Services.AddMapperlyObjectMapper<CacheManagementWebModule>();

        Configure<RazorPagesOptions>(options =>
        {
                //Configure authorization.
            });
    }
}
