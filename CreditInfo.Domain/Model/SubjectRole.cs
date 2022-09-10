using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditInfo.Domain.Model
{
    public class SubjectRole
    {
        public string CustomerCode { get; set; }

        public string RoleOfCustomer { get; set; }

        public decimal? GuaranteeAmount { get; set; }
    }
}
