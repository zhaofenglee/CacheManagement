using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Threading;

namespace JS.Abp.CacheManagement.CacheItems;

[RemoteService(IsEnabled = false)]

public class CacheItemAppService : ApplicationService, ICacheItemAppService
{
    private IDatabase _redisDatabase;

    private readonly RedisCache _redisCache;
    private readonly IDistributedCacheKeyNormalizer _keyNormalizer;
    private readonly ICancellationTokenProvider _cancellationTokenProvider;
    protected IDatabase RedisDatabase => GetRedisDatabase();

    public CacheItemAppService(
        IDistributedCache distributedCache,
        IDistributedCacheKeyNormalizer keyNormalizer,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        if (distributedCache is not RedisCache redisCache)
        {
            throw new NotImplementedException();
        }

        _redisCache = redisCache;
        _keyNormalizer = keyNormalizer;
        _cancellationTokenProvider = cancellationTokenProvider;
    }
    private IDatabase GetRedisDatabase()
    {
        if (_redisDatabase == null)
        {
            var redisDatabaseField =
                typeof(RedisCache).GetField("_cache", BindingFlags.Instance | BindingFlags.NonPublic);

            _redisDatabase = redisDatabaseField!.GetValue(_redisCache) as IDatabase;
        }

        return _redisDatabase;
    }

    public async Task<PagedResultDto<CacheItemDataDto>> GetListAsync(GetCacheItemInput input)
    {
        var token = _cancellationTokenProvider.FallbackToProvider();
        var keys = await GetKeysAsync(new CacheItem()
        {
            CacheName = input.CacheName,
            DisplayName = input.DisplayName,
            Description = input.Description,
            IgnoreMultiTenancy = input.IgnoreMultiTenancy,
            TenantAllowed = input.TenantAllowed
        });

        var items = new List<CacheItemDataDto>(keys.Select(key => new CacheItemDataDto
        { CacheKey = key, CacheValue = key }));
        return new PagedResultDto<CacheItemDataDto>()
        {
            Items = items.Skip(input.SkipCount).Take(input.MaxResultCount).ToList(),
            TotalCount = items.Count(),
        };
    }

    public virtual async Task<IEnumerable<string>> GetKeysAsync(CacheItem cacheItem)
    {
        var normalizedKey = GetNormalizedKey(cacheItem, "*");

        if (string.IsNullOrEmpty(cacheItem.DisplayName))
            return await Task.FromResult(RedisDatabase.Multiplexer.GetServer(RedisDatabase.Multiplexer.GetEndPoints().First())
                .Keys(RedisDatabase.Database, normalizedKey).Select(k => k.ToString()));
        else
            return await Task.FromResult(RedisDatabase.Multiplexer.GetServer(RedisDatabase.Multiplexer.GetEndPoints().First())
                .Keys(RedisDatabase.Database, normalizedKey).Select(k => k.ToString()).Where(m => m.Contains(cacheItem.DisplayName)));
    }

    public virtual async Task ClearAllAsync()
    {
        var token = _cancellationTokenProvider.FallbackToProvider();

        var keys = await GetKeysAsync(new CacheItem() { CacheName = "*" });

        foreach (var key in keys)
        {
            await _redisCache.RemoveAsync(key, token);
        }

    }

    public virtual async Task ClearAsync(CacheItem cacheItem)
    {
        var token = _cancellationTokenProvider.FallbackToProvider();

        var keys = await GetKeysAsync(cacheItem);

        foreach (var key in keys)
        {
            await _redisCache.RemoveAsync(key, token);
        }
    }

    public virtual async Task ClearSpecificAsync(CacheItem cacheItem, string cacheKey)
    {
        var key = GetNormalizedKey(cacheItem, cacheKey);

        await _redisCache.RemoveAsync(key, _cancellationTokenProvider.FallbackToProvider());
    }

    public virtual async Task<string> GetValueAsync(string cacheKey)
    {
        return await _redisCache.GetStringAsync(cacheKey, _cancellationTokenProvider.FallbackToProvider());
    }

    protected virtual string GetNormalizedKey(CacheItem cacheItem, string cacheKey)
    {
        return _keyNormalizer.NormalizeKey(new DistributedCacheKeyNormalizeArgs(cacheKey, cacheItem.CacheName,
            cacheItem.IgnoreMultiTenancy));
    }

    public async Task DeleteAsync(string cacheKey)
    {
        await _redisCache.RemoveAsync(cacheKey, _cancellationTokenProvider.FallbackToProvider());
    }
}