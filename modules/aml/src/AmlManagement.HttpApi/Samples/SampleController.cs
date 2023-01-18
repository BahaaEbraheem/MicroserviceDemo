using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MsDemo.Shared.Dtos;
using MsDemo.Shared.Etos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace AmlManagement.Samples
{
    [Area(AmlManagementRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = AmlManagementRemoteServiceConsts.RemoteServiceName)]
    [Route("api/AmlManagement/sample")]
    public class SampleController : AmlManagementController, ISampleAppService
    {
        private readonly ISampleAppService _sampleAppService;

        public SampleController(ISampleAppService sampleAppService)
        {
            _sampleAppService = sampleAppService;
        }


        [HttpGet]
        [Route("GetListRemittancesForAmlChecker")]
        public virtual async Task<PagedResultDto<RemittanceEto>> GetListRemittancesForAmlChecker(GetRemittanceListPagedAndSortedResultRequestDto input)
        {
            return await _sampleAppService.GetListRemittancesForAmlChecker(input);

        }

        [HttpGet]
        [Route("CheckAML")]
        public async Task CheckAML(Guid id)
        {
             await _sampleAppService.CheckAML(id);
        }

        [HttpGet]
        public async Task<SampleDto> GetAsync()
        {
            return await _sampleAppService.GetAsync();
        }

        [HttpGet]
        [Route("authorized")]
        [Authorize]
        public async Task<SampleDto> GetAuthorizedAsync()
        {
            return await _sampleAppService.GetAsync();
        }
    }
}
