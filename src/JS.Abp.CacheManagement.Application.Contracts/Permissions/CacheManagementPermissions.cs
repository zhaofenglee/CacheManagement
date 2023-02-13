using Volo.Abp.Reflection;

namespace JS.Abp.CacheManagement.Permissions;

public class CacheManagementPermissions
{
    public const string GroupName = "CacheManagement";

    public class CacheManagement
    {
        public const string Default = GroupName + ".CacheManagement";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CacheManagementPermissions));
    }
}
