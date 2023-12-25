using System.Collections.Generic;

namespace JS.Abp.CacheManagement.CacheItems;

public class CacheItemDto
{
    public string CacheKey { get; set; }
    
    public string CacheName { get; set; }
    
    public List<CacheItemDto> Children { get; set; }
}