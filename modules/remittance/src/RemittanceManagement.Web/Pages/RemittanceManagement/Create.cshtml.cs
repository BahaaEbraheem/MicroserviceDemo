using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RemittanceManagement.Remittances;
using MsDemo.Shared.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using static MsDemo.Shared.Enums.Enums;

namespace RemittanceManagement.Web.Pages.RemittanceManagement;

    public class CreateModel : RemittanceManagementPageModel
{
        private readonly IRemittanceAppService _remittanceAppService;


        [BindProperty]
        public RemittanceCreateViewModel Remittance { get; set; } = new RemittanceCreateViewModel();

    public List<SelectListItem> CustomerListItems { get; set; } = new List<SelectListItem>();
   //public ListResultDto<CustomerLookupDto> CustomerList { get; set; } 

    public List<SelectListItem> CurrencyListItems { get; set; } = new List<SelectListItem>();
    //public ListResultDto<CurrencyLookupDto> CurrencyList { get; set; }

    public CreateModel(IRemittanceAppService remittanceAppService)
        {
        _remittanceAppService = remittanceAppService;
        }



    public    void OnGet()
    {
        //List<SelectListItem> CustomerListItems = new List<SelectListItem>();
     var CustomerList = _remittanceAppService.GetCustomerLookupAsync().Result.Items;
        foreach (var customer in CustomerList)
        {
           var item= new SelectListItem { Value = customer.Id.ToString(), Text = customer.FirstName+" "+customer.FatherName+" "+customer.LastName };
            CustomerListItems.Add(item);
        }

        //List<SelectListItem> CurrencyListItems = new List<SelectListItem>();
       var CurrencyList = _remittanceAppService.GetCurrencyLookupAsync().Result.Items;
        foreach (var currency in CurrencyList)
        {
            var item = new SelectListItem { Value = currency.Id.ToString(), Text = currency.Name };
            CurrencyListItems.Add(item);
        }

    }



    public async Task<IActionResult> OnPostAsync()
        {
            var createRemittanceDto = ObjectMapper.Map<RemittanceCreateViewModel, CreateRemittanceDto>(Remittance);

            await _remittanceAppService.CreateAsync(createRemittanceDto);

            return NoContent();
        }
        public class RemittanceCreateViewModel
    {
        [Required]
        public double Amount { get; set; }

        [Required]
        public RemittanceType Type { get; set; }

        //[Required]
        [HiddenInput]
        public Guid? CreatorId { get; set; }
        [HiddenInput]
        public DateTime CreationTime { get; set; }

        [Required]
        [SelectItems(nameof(CustomerListItems))]
        public Guid SenderBy { get; set; }

        [Required]
        public string ReceiverFullName { get; set; }

        [Required]
        [SelectItems(nameof(CurrencyListItems))]
        public Guid CurrencyId { get; set; }


        }
    }
