using JS.Abp.CacheManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace JS.Abp.CacheManagement;

public abstract class CacheManagementController : AbpControllerBase
{
    protected CacheManagementController()
    {
        LocalizationResource = typeof(CacheManagementResource);
    }
}
