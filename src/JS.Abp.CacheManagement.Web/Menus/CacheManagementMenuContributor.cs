using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace JS.Abp.CacheManagement.Web.Menus;

public class CacheManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(CacheManagementMenus.Prefix, displayName: "CacheManagement", "~/CacheManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
