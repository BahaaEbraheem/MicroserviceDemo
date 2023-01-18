using AmlManagement.Aml_Person;
using AmlManagement.Aml_Remittance;
using AmlManagement.EntityFrameworkCore;
using MsDemo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.Domain.Services;
using Volo.Abp.EntityFrameworkCore;

namespace AmlManagement.Aml_Remittance
{
    public class AmlRemittanceRepository : EfCoreRepository<AmlManagementDbContext, AmlRemittance, Guid>, IAmlRemittanceRepository
    {
        public AmlRemittanceRepository(
            IDbContextProvider<AmlManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

    }
}
