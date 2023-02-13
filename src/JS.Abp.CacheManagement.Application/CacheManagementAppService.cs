using JS.Abp.CacheManagement.Localization;
using Volo.Abp.Application.Services;

namespace JS.Abp.CacheManagement;

public abstract class CacheManagementAppService : ApplicationService
{
    protected CacheManagementAppService()
    {
        LocalizationResource = typeof(CacheManagementResource);
        ObjectMapperContext = typeof(CacheManagementApplicationModule);
    }
}
