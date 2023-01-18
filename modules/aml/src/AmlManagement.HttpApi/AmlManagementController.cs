using AmlManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AmlManagement
{
    public abstract class AmlManagementController : AbpControllerBase
    {
        protected AmlManagementController()
        {
            LocalizationResource = typeof(AmlManagementResource);
        }
    }
}
