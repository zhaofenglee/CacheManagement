using System.Collections.Generic;
using System.Threading.Tasks;
using JS.Abp.CacheManagement.CacheItems;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace JS.Abp.CacheManagement.Controllers.CacheItems;

[RemoteService]
[Area("app")]
[ControllerName("CacheItem")]
[Route("api/app/cache-item")]
public class CacheItemController : AbpController, ICacheItemAppService
{
    private readonly ICacheItemAppService _cacheItemAppService;

    public CacheItemController(ICacheItemAppService cacheItemAppService)
    {
        _cacheItemAppService = cacheItemAppService;
    }
    [HttpGet]
    public Task<PagedResultDto<CacheItemDataDto>> GetListAsync(GetCacheItemInput input)
    {
        return _cacheItemAppService.GetListAsync(input);
    }
    [HttpGet]
    [Route("key")]
    public Task<IEnumerable<string>> GetKeysAsync(CacheItem cacheItem)
    {
        return _cacheItemAppService.GetKeysAsync(cacheItem);
    }
    [HttpDelete]
    [Route("clear-all")]
    public Task ClearAllAsync()
    {
        return _cacheItemAppService.ClearAllAsync();
    }
    [HttpDelete]
    public Task ClearAsync(CacheItem cacheItem)
    {
        return _cacheItemAppService.ClearAsync(cacheItem);
    }
    [HttpDelete]
    [Route("clear-specific")]
    public Task ClearSpecificAsync(CacheItem cacheItem, string cacheKey)
    {
        return _cacheItemAppService.ClearSpecificAsync(cacheItem, cacheKey);
    }
    [HttpGet]
    [Route("value")]
    public Task<string> GetValueAsync(string cacheKey)
    {
        return _cacheItemAppService.GetValueAsync(cacheKey);
    }
    [HttpDelete]
    [Route("{cachekey}")]
    public Task DeleteAsync(string cacheKey)
    {
        return _cacheItemAppService.DeleteAsync(cacheKey);
    }
}