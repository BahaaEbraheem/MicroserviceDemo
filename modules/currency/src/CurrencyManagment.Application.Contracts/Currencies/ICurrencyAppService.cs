using JetBrains.Annotations;
using CurrencyManagment.Currencies.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using MsDemo.Shared.Dtos;

namespace CurrencyManagment.Currencies
{
    public interface ICurrencyAppService : 
         ICrudAppService< //Defines CRUD methods
             CurrencyDto, //Used to show currencies
             Guid, //Primary key of the currency entity
             CurrencyPagedAndSortedResultRequestDto, //Used for paging/sorting
             CreateUpdateCurrencyDto> //Used to create/update a currency
    {
        Task<CurrencyDto> FindByNameAndSymbolAsync(string name, string symbol);
        Task<ListResultDto<RemittanceLookupDto>> GetRemittanceLookupAsync();
        Task<List<CurrencyDto>> GetAllAsync();
       // Task<List<CurrencyDto>> GetFromReposListAsync(int skipCount, int maxResultCount, string sorting, CurrencyDto filter);
      //  Task<int> GetTotalCountAsync(CurrencyDto filter);
    }
 
}
