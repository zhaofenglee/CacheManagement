using JS.Abp.CacheManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace JS.Abp.CacheManagement.Blazor.Server.Host;

public abstract class CacheManagementComponentBase : AbpComponentBase
{
    protected CacheManagementComponentBase()
    {
        LocalizationResource = typeof(CacheManagementResource);
    }
}
