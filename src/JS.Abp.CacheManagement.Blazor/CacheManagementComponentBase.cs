using JS.Abp.CacheManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components;

namespace JS.Abp.CacheManagement.Blazor
{
    public abstract class CacheManagementComponentBase : AbpComponentBase
    {
        protected CacheManagementComponentBase()
        {
            LocalizationResource = typeof(CacheManagementResource);
        }
    }
}
