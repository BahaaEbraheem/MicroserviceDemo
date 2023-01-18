using MsDemo.Shared.Dtos;
using MsDemo.Shared.Etos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace AmlManagement.Samples
{
    public interface ISampleAppService : IApplicationService, ITransientDependency
    {
        Task<PagedResultDto<RemittanceEto>> GetListRemittancesForAmlChecker(GetRemittanceListPagedAndSortedResultRequestDto input);
        Task CheckAML(Guid id);


        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
