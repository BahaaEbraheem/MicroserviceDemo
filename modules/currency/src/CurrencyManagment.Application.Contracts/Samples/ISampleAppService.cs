using System.ServiceModel;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace CurrencyManagment.Samples;
[ServiceContract]

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
