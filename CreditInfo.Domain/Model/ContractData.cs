using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditInfo.Domain.Model
{
    public class ContractData
    {
        public string PhaseOfContract { get; set; }

        public Amount OriginalAmount { get; set; }

        public Amount InstallmentAmount { get; set; }

        public Amount CurrentBalance { get; set; }

        public Amount OverdueBalance { get; set; }

        public DateTime? DateOfLastPayment { get; set; }

        public DateTime? NextPaymentDate { get; set; }

        public DateTime? DateAccountOpened { get; set; }

        public DateTime? RealEndDate { get; set; }
    }
}
