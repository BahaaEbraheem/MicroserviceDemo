using Volo.Abp.Bundling;

namespace AmlManagement.Blazor.Host
{
    public class AmlManagementBlazorHostBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {

        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css", true);
        }
    }
}
