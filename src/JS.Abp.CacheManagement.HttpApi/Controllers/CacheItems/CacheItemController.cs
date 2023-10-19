using System.Collections.Generic;
using System.Threading.Tasks;
using JS.Abp.CacheManagement.CacheItems;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace JS.Abp.CacheManagement.Controllers.CacheItems;

[RemoteService(Name = CacheManagementRemoteServiceConsts.RemoteServiceName)]
[Area("cacheManagement")]
[ControllerName("CacheItem")]
[Route("api/cache-management/cache-item")]
public class CacheItemController : AbpController, ICacheItemAppService
{
    private readonly ICacheItemAppService _cacheItemAppService;

    public CacheItemController(ICacheItemAppService cacheItemAppService)
    {
        _cacheItemAppService = cacheItemAppService;
    }
    [HttpGet]
    [Route("all")]
    public virtual Task<List<CacheItemDataDto>> GetAllAsync()
    {
        return _cacheItemAppService.GetAllAsync();
    }

    [HttpGet]
    public virtual Task<PagedResultDto<CacheItemDataDto>> GetListAsync(GetCacheItemInput input)
    {
        return _cacheItemAppService.GetListAsync(input);
    }
    [HttpGet]
    [Route("key")]
    public virtual Task<IEnumerable<string>> GetKeysAsync(CacheItem cacheItem)
    {
        return _cacheItemAppService.GetKeysAsync(cacheItem);
    }
    [HttpDelete]
    [Route("clear-all")]
    public virtual Task ClearAllAsync()
    {
        return _cacheItemAppService.ClearAllAsync();
    }
    [HttpDelete]
    public virtual Task ClearAsync(CacheItem cacheItem)
    {
        return _cacheItemAppService.ClearAsync(cacheItem);
    }
    [HttpDelete]
    [Route("clear-specific")]
    public virtual Task ClearSpecificAsync(CacheItem cacheItem, string cacheKey)
    {
        return _cacheItemAppService.ClearSpecificAsync(cacheItem, cacheKey);
    }
    [HttpGet]
    [Route("value")]
    public virtual Task<string> GetValueAsync(string cacheKey)
    {
        return _cacheItemAppService.GetValueAsync(cacheKey);
    }
    [HttpPut]
    public virtual Task UpdateAsync(CacheItemUpdateDto input)
    {
        return _cacheItemAppService.UpdateAsync(input);
    }

    [HttpDelete]
    [Route("{cachekey}")]
    public virtual Task DeleteAsync(string cacheKey)
    {
        return _cacheItemAppService.DeleteAsync(cacheKey);
    }
}