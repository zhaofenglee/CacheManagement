using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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

    public virtual async Task<List<CacheItemDataDto>> GetAllAsync()
    {
        var keys = await GetKeysAsync(new CacheItem()
        {
            CacheName = "*",
        });

        var items = new List<CacheItemDataDto>(keys.Select(key => new CacheItemDataDto
            { CacheKey = key, CacheValue = key }));

        return items;
    }

    public virtual async Task<List<CacheItemDto>> GetTreeAsync(string? cacheKey = null)
    {
        var cacheItemDatas = (await GetAllAsync());
        var nodes = new List<CacheItemNode>();
        List<CacheItemDto> items = new List<CacheItemDto>();
        var cacheGroupsDictionary = new Dictionary<string, List<CacheItemDataDto>>();
        int id = 0;
        foreach (var cacheGroup in cacheItemDatas.Where(c=>c.CacheKey!=null))
        {
            CacheItemNode pnode = null;
            string[] cacheItems = cacheGroup.CacheKey.Split(':');
            string key = "";
            for (int i = 0; i < cacheItems.Length; i++)
            {
                key += cacheItems[i];
                var pnode1 = nodes.FirstOrDefault(x => x.CacheKey == key);
                if (pnode1 == null)
                {
                    pnode1 = new CacheItemNode() { 
                        NodeID = id++,
                        CacheName = cacheItems[i], 
                        Parentid = pnode == null ? -1 : pnode.NodeID,
                        CacheKey = key
                        
                    };
                    nodes.Add(pnode1);
                }
                key += ":";
                pnode = pnode1;
            }        

        }
        LoadRoot(nodes,items);
        return items;
    }
    
    private void LoadRoot(List<CacheItemNode> list,List<CacheItemDto> items)
    {
        foreach (var item in list.Where(x => x.Parentid == -1))
        {
            var tn = new CacheItemDto() { CacheName = item.CacheName,Children = new List<CacheItemDto>(),CacheKey = item.CacheKey};
            items.Add(tn);
            LoadChild(list, tn, item);
        }
    }

    private void LoadChild(List<CacheItemNode> list, CacheItemDto tn, CacheItemNode node)
    {
        foreach (var item in list.Where(x => x.Parentid == node.NodeID))
        {
            var childen = new CacheItemDto() { CacheName = item.CacheName,Children = new List<CacheItemDto>(),CacheKey = item.CacheKey };
            tn.Children.Add(childen);
            LoadChild(list, childen, item);
        }
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
        if (!input.FilterText.IsNullOrWhiteSpace())
        {
            items = items.Where(c=>c.CacheKey.Contains(input.FilterText) || c.CacheValue.Contains(input.FilterText)).ToList();
        }
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

    public virtual async Task UpdateAsync(CacheItemUpdateDto input)
    {
        var byteArray = Encoding.UTF8.GetBytes(input.Value);
        await _redisCache.SetAsync(input.CacheKey,byteArray);
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