using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace JS.Abp.CacheManagement;

[DependsOn(
    typeof(CacheManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class CacheManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CacheManagementApplicationContractsModule).Assembly,
            CacheManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CacheManagementHttpApiClientModule>();
        });

    }
}
