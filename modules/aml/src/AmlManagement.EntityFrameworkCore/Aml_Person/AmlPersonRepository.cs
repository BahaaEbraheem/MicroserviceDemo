using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using static MsDemo.Shared.Enums.Enums;
using Volo.Abp.Domain.Services;
using AmlManagement.EntityFrameworkCore;
using MsDemo.Shared.Dtos;
using AmlManagement.Aml_Person;

namespace AmlManagement.Aml_Person
{
    public class AmlPersonRepository : EfCoreRepository<AmlManagementDbContext,AmlPerson, Guid>, IAmlPersonRepository
    {
        public AmlPersonRepository(
            IDbContextProvider<AmlManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<AmlPerson> GetAmlPersonByFirstAndFatherAndLastName(string firstName, string fatherName, string lastName)
        {
            var dbSet = await GetDbSetAsync();
            var checkAmlPerson =  dbSet
                .WhereIf(!firstName.IsNullOrWhiteSpace(), aml => aml.FirstName == firstName || aml.FirstName.Contains(firstName))
                .WhereIf(!fatherName.IsNullOrWhiteSpace(), aml => aml.FatherName == firstName || aml.FatherName.Contains(fatherName))
                .WhereIf(!lastName.IsNullOrWhiteSpace(), aml => aml.LastName == firstName || aml.LastName.Contains(lastName)).FirstOrDefault() ;
           return checkAmlPerson;


        }

        //public async Task<AmlRemittance> FindBySerialNumAsync(string serialNum)
        //{
        //    var dbSet = await GetDbSetAsync();
        //    return await dbSet.FirstOrDefaultAsync(Remittance => Remittance.SerialNumber == serialNum);
        //}

        //public async Task<bool> IsApprovedRemittanceAsync(AmlRemittance remittance)
        //{
        //    var dbSet = await GetDbSetAsync();
        //    AmlRemittance checkApprovedRemittance = await dbSet.FirstOrDefaultAsync(Remittance => Remittance.Id == remittance.Id);
        //    if (checkApprovedRemittance.ApprovedBy.Equals(null) && checkApprovedRemittance.ApprovedDate.Equals(null))
        //    {
        //        return true;
        //    }
        //    return false;

        //}

        //public async Task<List<AmlRemittance>> GetListRemittancesStatusAsync(int skipCount, int maxResultCount, string sorting, AmlRemittance filter)
        //{
        //    var dbSet = await GetDbSetAsync();

        //    var remittances = await dbSet
        //        .WhereIf(!filter.ReceiverFullName.IsNullOrWhiteSpace(), x => x.ReceiverFullName.Contains(filter.ReceiverFullName))
        //        .WhereIf(!filter.Amount.Equals(0), x => x.Amount.ToString().Contains(filter.Amount.ToString()))
        //        .WhereIf(!filter.TotalAmount.Equals(0), x => x.TotalAmount.ToString().Contains(filter.TotalAmount.ToString()))
        //        .WhereIf(!filter.SerialNumber.IsNullOrWhiteSpace(), x => x.SerialNumber.Contains(filter.SerialNumber))
        //        .OrderBy(sorting).Skip(skipCount).Take(maxResultCount).ToListAsync();
        //    return remittances;

        //}

        //public async Task<int> GetTotalCountAsync(AmlRemittance filter)
        //{
        //    var dbSet = await GetDbSetAsync();
        //    var remittances = await dbSet
        //     .WhereIf(!filter.ReceiverFullName.IsNullOrWhiteSpace(), x => x.ReceiverFullName.Contains(filter.ReceiverFullName))
        //        .WhereIf(!filter.Amount.Equals(0), x => x.Amount.ToString().Contains(filter.Amount.ToString()))
        //        .WhereIf(!filter.TotalAmount.Equals(0), x => x.TotalAmount.ToString().Contains(filter.TotalAmount.ToString()))
        //        .WhereIf(!filter.SerialNumber.IsNullOrWhiteSpace(), x => x.SerialNumber.Contains(filter.SerialNumber))
        //        .ToListAsync();
        //    return remittances.Count;
        //}







    }
}