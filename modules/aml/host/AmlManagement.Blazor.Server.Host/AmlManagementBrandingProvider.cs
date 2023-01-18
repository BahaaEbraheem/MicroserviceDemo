using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AmlManagement.Blazor.Server.Host
{
    [Dependency(ReplaceServices = true)]
    public class AmlManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AmlManagement";
    }
}
