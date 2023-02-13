using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace JS.Abp.CacheManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(CacheManagementBlazorModule),
    typeof(CacheManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class CacheManagementBlazorWebAssemblyModule : AbpModule
{

}
