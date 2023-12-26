using System.Threading.Tasks;
using JS.Abp.CacheManagement.CacheItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JS.Abp.CacheManagement.Web.Pages.CacheManagement;

public class EditModal : CacheManagementPageModel
{
    // [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public string CacheKey { get; set; }
    
    [BindProperty]
    public string CacheValue { get; set; }
    
    protected ICacheItemAppService _cacheItemAppService;
    
    public EditModal(ICacheItemAppService cacheItemAppService)
    {
        _cacheItemAppService = cacheItemAppService;
        
    }
    
    public virtual async Task OnGetAsync()
    {
        CacheValue = await _cacheItemAppService.GetValueAsync(CacheKey);
       
    }
    
    public virtual async Task<NoContentResult> OnPostAsync()
    {

        await _cacheItemAppService.UpdateAsync(new CacheItemUpdateDto()
        {
            CacheKey = CacheKey, Value = CacheValue

        });
        return NoContent();
    }
}