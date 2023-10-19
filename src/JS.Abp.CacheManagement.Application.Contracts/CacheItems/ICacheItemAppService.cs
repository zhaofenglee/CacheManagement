using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace JS.Abp.CacheManagement.CacheItems;

public interface ICacheItemAppService : IApplicationService
{
    Task<List<CacheItemDataDto>> GetAllAsync();
    Task<PagedResultDto<CacheItemDataDto>> GetListAsync(GetCacheItemInput input);
    Task<IEnumerable<string>> GetKeysAsync(CacheItem cacheItem);

    Task ClearAllAsync();

    Task ClearAsync(CacheItem cacheItem);

    Task ClearSpecificAsync(CacheItem cacheItem, string cacheKey);

    Task<string> GetValueAsync(string cacheKey);

    Task UpdateAsync(CacheItemUpdateDto input);
    
    Task DeleteAsync(string cacheKey);
}