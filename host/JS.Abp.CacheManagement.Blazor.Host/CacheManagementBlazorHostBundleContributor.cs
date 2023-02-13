using Volo.Abp.Bundling;

namespace JS.Abp.CacheManagement.Blazor.Host;

public class CacheManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
