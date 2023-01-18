using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CurrencyManagment.Currencies;
using CurrencyManagment.Currencies.Dtos;
using Microsoft.AspNetCore.Mvc;
using RemittanceManagement.Remittances;
using MsDemo.Shared.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.ObjectMapping;
using static MsDemo.Shared.Enums.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using MsDemo.Shared.Etos;

namespace RemittanceManagement.Web.Pages.RemittanceForReleaser;

    public class ReceiverModel : RemittanceManagementPageModel
{
   

        [BindProperty]
    public CustomerViewModel Receiver { get; set; } = new CustomerViewModel();

    private readonly IRemittanceAppService _remittanceAppService;

    public List<SelectListItem> CustomerListItems { get; set; } = new List<SelectListItem>();
    public List<SelectListItem> CurrencyListItems { get; set; } = new List<SelectListItem>();




    public ReceiverModel(IRemittanceAppService remittanceAppService)
        {
        _remittanceAppService = remittanceAppService;
        }

        public async Task<ActionResult> OnGetAsync(Guid id)
           {
        var CustomerList = _remittanceAppService.GetCustomerLookupAsync().Result.Items;
        foreach (var customer in CustomerList)
        {
            var item = new SelectListItem { Value = customer.Id.ToString(), Text = customer.FirstName + " " + customer.FatherName + " " + customer.LastName };
            CustomerListItems.Add(item);
        }
        var CurrencyList = _remittanceAppService.GetCurrencyLookupAsync().Result.Items;
        foreach (var currency in CurrencyList)
        {
            var item = new SelectListItem { Value = currency.Id.ToString(), Text = currency.Name };
            CurrencyListItems.Add(item);
        }
        //var remittanceDto = await _remittanceAppService.GetAsync(id);
        //Remittance = ObjectMapper.Map<RemittanceDto, RemittanceReleaseViewModel>(remittanceDto);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
        //var remittanceDtoAfterRelease = ObjectMapper.Map<RemittanceReleaseViewModel,RemittanceDto>(Remittance);
        //await _remittanceAppService.SetRelease(remittanceDtoAfterRelease);
            return NoContent();
        }
        public class CustomerViewModel
    {
        [HiddenInput]
        [Required]
        public Guid Id { get; set; }
        [DisabledInput]
        public double Amount { get; set; }
        [DisabledInput]
        public RemittanceType Type { get; set; }


        [DisabledInput]

        public Guid SenderBy { get; set; }

        [SelectItems(nameof(CustomerListItems))]
        public Guid? ReceiverBy { get; set; }
        [DisabledInput]
        public string ReceiverFullName { get; set; }
        [DisabledInput]
        public Guid? CurrencyId { get; set; }
        [HiddenInput]
        public DateTime? LastModificationTime { get; set; }
        [HiddenInput]
        public Guid? LastModifierId { get; set; }
        [HiddenInput]
        public DateTime CreationTime { get; set; }
        [HiddenInput]
        public DateTime? ReleasedDate { get; set; }
        [HiddenInput]
        public Guid? ReleasedBy { get; set; }
        [HiddenInput]
        public Guid? CreatorId { get; set; }

        [HiddenInput]
        public double TotalAmount { get; set; }
        [HiddenInput]
        public string SerialNumber { get; set; }
        [HiddenInput]
        public Guid? ApprovedBy { get; set; }
        [HiddenInput]
        public DateTime? ApprovedDate { get; set; }
 
        [HiddenInput]
        public DateTime? StatusDate { get; set; }
        [HiddenInput]
        public string SenderName { get; set; }
        [HiddenInput]
        public string ReceiverName { get; set; }
        [HiddenInput]
        public string CurrencyName { get; set; }

    }
}
