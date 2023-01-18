using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlManagement.Aml_Person;
using AmlManagement.Aml_Remittance;
using AmlManagement.Permissions;
using CurrencyManagment.Currencies;
using CustomerManagement.Customers;
using Microsoft.AspNetCore.Authorization;
using MsDemo.Shared.Dtos;
using MsDemo.Shared.Etos;
using RemittanceManagement;
using RemittanceManagement.Remittances;
using RemittanceManagement.Status;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Users;
using static CustomerManagement.Permissions.CustomerManagementPermissions;
using static MsDemo.Shared.Enums.Enums;

namespace AmlManagement.Samples
{
    public class SampleAppService : AmlManagementAppService, ISampleAppService, ITransientDependency
    {

        private readonly AmlRemittanceManager _amlRemittanceManager;
        private readonly IAmlPersonRepository _amlPersonRepository;
        private readonly IAmlRemittanceRepository _amlRemittanceRepository;
        private readonly IDistributedEventBus _distributedEventBus;

        public SampleAppService(
            AmlRemittanceManager amlRemittanceManager,
            IAmlRemittanceRepository amlRemittanceRepository,
            IDistributedEventBus distributedEventBus)
        {

            _amlRemittanceManager = amlRemittanceManager;
            _amlRemittanceRepository = amlRemittanceRepository;
            _distributedEventBus = distributedEventBus;

        }


        public async Task<PagedResultDto<RemittanceEto>> GetListRemittancesForAmlChecker(GetRemittanceListPagedAndSortedResultRequestDto input)
        {
            try
            {
                bool CanCheckAmlRemittances = await AuthorizationService
                     .IsGrantedAsync(AmlManagementPermissions.AmlRemittances.Check);
                //Get the IQueryable<remittance> from the repository
                var remittancequeryable = _amlRemittanceRepository.GetQueryableAsync().Result
                 .WhereIf(!input.Amount.Equals(0), x => x.Amount.ToString().Contains(input.Amount.ToString()))
                 .WhereIf(!input.SerialNumber.IsNullOrWhiteSpace(), x => x.SerialNumber.Contains(input.SerialNumber))
               .ToList();

                var query = from remittance in remittancequeryable
                            where (remittance.State == Remittance_Status.Ready && CanCheckAmlRemittances)
                            select new { remittance };

                //Paging
                query = query.AsQueryable()
             .Skip(input.SkipCount)
             .Take(input.MaxResultCount);

                //Convert the query result to a list of RemittanceDto objects
                var remittanceEtos = query.Select(x =>
                {
                    var remittanceEto = ObjectMapper.Map<AmlRemittance, RemittanceEto>(x.remittance);
                    remittanceEto.State=x.remittance.State;
                    remittanceEto.CreationTime= x.remittance.CreationTime;
                    remittanceEto.CreatorId= x.remittance.CreatorId;
                    return remittanceEto;
                }).ToList();

                //Get the total count with another query
                var totalCount = await _amlRemittanceRepository.GetCountAsync();

                return new PagedResultDto<RemittanceEto>(
                    totalCount,
                    remittanceEtos
                );
            }
            catch (Exception)
            {

                throw;
            }


        }


        public async Task CheckAML(Guid id)
        {
            try
            {
                if (id != null)
                {
                    var remittance = await _amlRemittanceManager.GetAsync(id);

                    if (remittance != null && remittance.State == Remittance_Status.Ready)
                    {
                        var amlPerson = _amlRemittanceManager.GetAmlPersonByFirstAndFatherAndLastName(
                            remittance.FirstName, remittance.FatherName, remittance.LastName).Result;
                        if (amlPerson != null)
                        {
                            throw new CustomerAmlWantedException(amlPerson.FirstName);
                        }

                        remittance.State = Remittance_Status.CheckedAML;

                        await _distributedEventBus.PublishAsync<RemittanceAfterCheckedAmlEto>(eventData: new RemittanceAfterCheckedAmlEto
                        {
                            RemittanceId=remittance.RemittanceId,
                        });
                        await _amlRemittanceManager.UpdateAsync(remittance);

                    }
                }
            }

            catch (Exception)
            {

                throw;
            }
        }
  
        public Task<SampleDto> GetAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }

        [Authorize]
        public Task<SampleDto> GetAuthorizedAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }
    }
}