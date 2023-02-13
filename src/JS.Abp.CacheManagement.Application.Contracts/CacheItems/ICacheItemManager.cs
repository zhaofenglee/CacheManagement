using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace JS.Abp.CacheManagement.CacheItems;

public interface ICacheItemManager : IApplicationService
{
    Task<PagedResultDto<CacheItemDataDto>> GetListAsync(GetCacheItemInput input);
    Task<IEnumerable<string>> GetKeysAsync(CacheItem cacheItem, CancellationToken cancellationToken = default);

    Task ClearAllAsync(CancellationToken cancellationToken = default);

    Task ClearAsync(CacheItem cacheItem, CancellationToken cancellationToken = default);

    Task ClearSpecificAsync(CacheItem cacheItem, string cacheKey, CancellationToken cancellationToken = default);

    Task<string> GetValueAsync(string cacheKey, CancellationToken cancellationToken = default);

    Task DeleteAsync(string cacheKey, CancellationToken cancellationToken = default);
}