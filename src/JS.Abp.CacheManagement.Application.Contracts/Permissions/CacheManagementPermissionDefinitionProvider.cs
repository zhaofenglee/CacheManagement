using JS.Abp.CacheManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace JS.Abp.CacheManagement.Permissions;

public class CacheManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CacheManagementPermissions.GroupName, L("Permission:CacheManagement"));


        var cacheManagementPermission = myGroup.AddPermission(CacheManagementPermissions.CacheManagement.Default, L("Permission:CacheManagements"));
        cacheManagementPermission.AddChild(CacheManagementPermissions.CacheManagement.Create, L("Permission:Create"));
        cacheManagementPermission.AddChild(CacheManagementPermissions.CacheManagement.Edit, L("Permission:Edit"));
        cacheManagementPermission.AddChild(CacheManagementPermissions.CacheManagement.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CacheManagementResource>(name);
    }
}
