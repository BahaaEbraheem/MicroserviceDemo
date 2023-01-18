using AmlManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AmlManagement.Pages
{
    public abstract class AmlManagementPageModel : AbpPageModel
    {
        protected AmlManagementPageModel()
        {
            LocalizationResourceType = typeof(AmlManagementResource);
        }
    }
}