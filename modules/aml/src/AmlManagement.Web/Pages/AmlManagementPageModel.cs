using AmlManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AmlManagement.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AmlManagementPageModel : AbpPageModel
    {
        protected AmlManagementPageModel()
        {
            LocalizationResourceType = typeof(AmlManagementResource);
            ObjectMapperContext = typeof(AmlManagementWebModule);
        }
    }
}