using System;
using System.Threading.Tasks;
using AmlManagement.Aml_Person;
using AmlManagement.Aml_Remittance;
using AmlManagement.Samples;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MsDemo.Shared.Dtos;
using MsDemo.Shared.Etos;
using RemittanceManagement.Remittances;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;
using IObjectMapper = Volo.Abp.ObjectMapping.IObjectMapper;

namespace AmlManagement.AmlHandler
{
    public class RemittanceCreatedDistributedEventHandler : IDistributedEventHandler<RemittanceEto>, ITransientDependency
    {
        private readonly IObjectMapper _ObjectMapper;
        private readonly AmlRemittanceManager _amlRemittanceManager;
        private readonly IAmlPersonRepository _amlPersonRepository;

        public RemittanceCreatedDistributedEventHandler(
            IAmlPersonRepository amlPersonRepository,
            IObjectMapper ObjectMapper,
            AmlRemittanceManager amlRemittanceManager)
        {
            _amlPersonRepository = amlPersonRepository;
            _ObjectMapper = ObjectMapper;
            _amlRemittanceManager = amlRemittanceManager;
        }

        public async Task HandleEventAsync(RemittanceEto eventData)
        {

            await _amlRemittanceManager.CreateAsync(_ObjectMapper.Map<RemittanceEto, AmlRemittance>(eventData));

           
        }



    }
}
