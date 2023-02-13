using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace JS.Abp.CacheManagement.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class CacheManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CacheManagement";
}
