using Volo.Abp.Bundling;

namespace JS.Abp.CacheManagement.Blazor.Host.Client;

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
