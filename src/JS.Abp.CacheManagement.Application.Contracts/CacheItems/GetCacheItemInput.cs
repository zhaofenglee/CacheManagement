using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;

namespace JS.Abp.CacheManagement.CacheItems
{
    public class GetCacheItemInput : PagedAndSortedResultRequestDto
    {
        [CanBeNull] public string FilterText { get; set; }
        public string CacheName { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IgnoreMultiTenancy { get; set; }

        public bool TenantAllowed { get; set; }
    }
}
