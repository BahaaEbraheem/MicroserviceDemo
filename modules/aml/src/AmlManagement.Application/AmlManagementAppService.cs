using AmlManagement.Localization;
using Volo.Abp.Application.Services;

namespace AmlManagement
{
    public abstract class AmlManagementAppService : ApplicationService
    {
        protected AmlManagementAppService()
        {
            LocalizationResource = typeof(AmlManagementResource);
            ObjectMapperContext = typeof(AmlManagementApplicationModule);
        }
    }
}
