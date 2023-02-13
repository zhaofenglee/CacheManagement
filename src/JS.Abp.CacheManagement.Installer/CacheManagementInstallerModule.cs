using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace JS.Abp.CacheManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class CacheManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CacheManagementInstallerModule>();
        });
    }
}
