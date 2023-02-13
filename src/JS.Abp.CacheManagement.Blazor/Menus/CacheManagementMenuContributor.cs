using JS.Abp.CacheManagement.Localization;
using JS.Abp.CacheManagement.Permissions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace JS.Abp.CacheManagement.Blazor.Menus;

public class CacheManagementMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;
    public CacheManagementMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<CacheManagementResource>();
        //Add main menu items.
        //context.Menu.AddItem(new ApplicationMenuItem(CacheManagementMenus.Prefix, displayName: "CacheManagement", "/CacheManagement", icon: "fa fa-globe"));
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
            var administrationMenu = context.Menu.GetAdministration();
            administrationMenu.Items.Add(
                     new ApplicationMenuItem(
                         CacheManagementMenus.CacheManagement,
                         l["Menu:CacheManagement"],
                         url: "/cache-management",
                         icon: "fa fa-file-alt"
                         ,
                         requiredPermissionName: CacheManagementPermissions.CacheManagement.Default,
                         order: 1002)
                 );
        }

        return Task.CompletedTask;
    }
}
