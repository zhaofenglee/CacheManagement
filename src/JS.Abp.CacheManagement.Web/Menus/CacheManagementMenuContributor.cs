using System.Collections.Generic;
using System.Threading.Tasks;
using JS.Abp.CacheManagement.Localization;
using JS.Abp.CacheManagement.Permissions;
using Microsoft.Extensions.Configuration;
using Volo.Abp.UI.Navigation;

namespace JS.Abp.CacheManagement.Web.Menus;

public class CacheManagementMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;
    public CacheManagementMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name != StandardMenus.Main)
        {
            return;
         
        }
        
        var moduleMenu = ConfigureMainMenuAsync(context);
        bool redisEnable = false;
        var redisEnabled = _configuration["Redis:IsEnabled"];
        if (string.IsNullOrWhiteSpace(redisEnabled) || bool.Parse(redisEnabled))
        {
            var redisConfiguration = _configuration["Redis:Configuration"];
            if (!string.IsNullOrWhiteSpace(redisConfiguration))
            {
                redisEnable = true;
            }
        }
        if (redisEnable)
        {
            AddMenuItemCacheManagements(context, moduleMenu);
        }
    }

    private static ApplicationMenuItem ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<CacheManagementResource>();
        //Add main menu items.
       var moduleMenu = new ApplicationMenuItem(CacheManagementMenus.Prefix, 
            displayName: l["Menu:CacheManagement"] 
           , icon: "fa fa-globe");
        context.Menu.Items.AddIfNotContains(moduleMenu);
        return moduleMenu;
    }

    private static void AddMenuItemCacheManagements(MenuConfigurationContext context, ApplicationMenuItem parentMenu)
    {
        var administration = context.Menu.GetAdministration();
        administration.AddItem(
            new ApplicationMenuItem(
                Menus.CacheManagementMenus.CacheManagement,
                context.GetLocalizer<CacheManagementResource>()["Menu:CacheManagement"],
                "/CacheManagement",
                icon: "fa fa-file-alt",
                requiredPermissionName: CacheManagementPermissions.CacheManagement.Default,
                order: 1002
            )
        );
    }
    
}
