using AmlManagement.Aml_Remittance;
using MsDemo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace AmlManagement.Aml_Person
{
    public interface IAmlRemittanceRepository : IRepository<AmlRemittance, Guid>, IDomainService
    {
 

    }

}
