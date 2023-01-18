using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AmlManagement
{
    [Dependency(ReplaceServices = true)]
    public class AmlManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AmlManagement";
    }
}
