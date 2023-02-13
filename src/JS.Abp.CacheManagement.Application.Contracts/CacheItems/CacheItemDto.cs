namespace JS.Abp.CacheManagement.CacheItems;

public class CacheItemDto
{
    public string CacheName { get; set; }

    public string DisplayName { get; set; }

    public string Description { get; set; }

    public bool IgnoreMultiTenancy { get; set; }

    public bool TenantAllowed { get; set; }
}