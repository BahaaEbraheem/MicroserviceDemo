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

namespace RemittanceManagement.Web.Pages.RemittanceManagement;

    public class UpdateModel : RemittanceManagementPageModel
{
   

        [BindProperty]
      //  public CreateUpdateCurrencyDto Currency { get; set; }
        public RemittanceUpdateViewModel Remittance { get; set; } = new RemittanceUpdateViewModel();

    private readonly IRemittanceAppService _remittanceAppService;
    public List<SelectListItem> CustomerListItems { get; set; } = new List<SelectListItem>();
    //public ListResultDto<CustomerLookupDto> CustomerList { get; set; } 

    public List<SelectListItem> CurrencyListItems { get; set; } = new List<SelectListItem>();
    public UpdateModel(IRemittanceAppService remittanceAppService)
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

        //List<SelectListItem> CurrencyListItems = new List<SelectListItem>();
        var CurrencyList = _remittanceAppService.GetCurrencyLookupAsync().Result.Items;
        foreach (var currency in CurrencyList)
        {
            var item = new SelectListItem { Value = currency.Id.ToString(), Text = currency.Name };
            CurrencyListItems.Add(item);
        }
        var remittanceDto = await _remittanceAppService.GetAsync(id);
        Remittance = ObjectMapper.Map<RemittanceDto, RemittanceUpdateViewModel>(remittanceDto);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _remittanceAppService.UpdateAsync(Remittance.Id, new UpdateRemittanceDto()
            {
                Amount = Remittance.Amount,
                Type = (RemittanceType)Remittance.Type,
                SenderBy=Remittance.SenderBy,
                CurrencyId= (Guid)Remittance.CurrencyId,
                ReceiverFullName=Remittance.ReceiverFullName,
            });
            return NoContent();
        }
        public class RemittanceUpdateViewModel
    {
            [HiddenInput]
            [Required]
            public Guid Id { get; set; }
        public double Amount { get; set; }
        [HiddenInput]

        public double TotalAmount { get; set; }

        public RemittanceType Type { get; set; }
        [HiddenInput]

        public string SerialNumber { get; set; }
        [HiddenInput]

        public Guid? ApprovedBy { get; set; }
        [HiddenInput]

        public DateTime? ApprovedDate { get; set; }
        [HiddenInput]

        public Guid? ReleasedBy { get; set; }
        [HiddenInput]

        public DateTime? ReleasedDate { get; set; }

        [Required]
        [SelectItems(nameof(CustomerListItems))]
        public Guid SenderBy { get; set; }
        [HiddenInput]

        public string SenderName { get; set; }
        [HiddenInput]

        public Guid? ReceiverBy { get; set; }
        public string ReceiverFullName { get; set; }
        [HiddenInput]

        public string ReceiverName { get; set; }
        [Required]
        [SelectItems(nameof(CurrencyListItems))]
        public Guid? CurrencyId { get; set; }
        [HiddenInput]

        public string CurrencyName { get; set; }

        [HiddenInput]

        public DateTime? StatusDate { get; set; }

        [HiddenInput]
        public DateTime? LastModificationTime { get; set; }
        [HiddenInput]

        public Guid? LastModifierId { get; set; }
        [HiddenInput]

        public DateTime CreationTime { get; set; }
        [HiddenInput]

        public Guid? CreatorId { get; set; }
    }
}
