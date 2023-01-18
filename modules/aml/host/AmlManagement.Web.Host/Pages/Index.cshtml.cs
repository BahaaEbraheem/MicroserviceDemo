using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace AmlManagement.Pages
{
    public class IndexModel : AmlManagementPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}