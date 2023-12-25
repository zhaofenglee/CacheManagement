using System;

namespace JS.Abp.CacheManagement.CacheItems;

public class CacheItemDataDto
{
    public Guid Id { get; set; }

    public string? CacheKey { get; set; }

    public string? CacheValue { get; set; }
}