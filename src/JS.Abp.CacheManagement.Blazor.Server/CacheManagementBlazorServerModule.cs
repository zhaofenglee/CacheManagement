using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace JS.Abp.CacheManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(CacheManagementBlazorModule)
    )]
public class CacheManagementBlazorServerModule : AbpModule
{

}
