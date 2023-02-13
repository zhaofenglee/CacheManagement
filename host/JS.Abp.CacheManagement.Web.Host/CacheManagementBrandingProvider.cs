using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace JS.Abp.CacheManagement;

[Dependency(ReplaceServices = true)]
public class CacheManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CacheManagement";
}
