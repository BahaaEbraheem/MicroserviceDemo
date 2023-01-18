using AmlManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace RemittanceManagement.Remittances
{
    public class CustomerAmlWantedException : BusinessException
    {
        public CustomerAmlWantedException(string customerName)
            : base(AmlManagementErrorCodes.CustomerAmlWantedException)
        {
            WithData("customerName", customerName);
        }
    
    }
}
