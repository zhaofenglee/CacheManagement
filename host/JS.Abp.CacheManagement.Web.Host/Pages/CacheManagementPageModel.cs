using JS.Abp.CacheManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace JS.Abp.CacheManagement.Pages;

public abstract class CacheManagementPageModel : AbpPageModel
{
    protected CacheManagementPageModel()
    {
        LocalizationResourceType = typeof(CacheManagementResource);
    }
}
