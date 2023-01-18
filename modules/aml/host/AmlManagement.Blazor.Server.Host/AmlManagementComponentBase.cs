using AmlManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AmlManagement.Blazor.Server.Host
{
    public abstract class AmlManagementComponentBase : AbpComponentBase
    {
        protected AmlManagementComponentBase()
        {
            LocalizationResource = typeof(AmlManagementResource);
        }
    }
}
