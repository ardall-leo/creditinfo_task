using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditInfo.Domain.Model
{
    public class Amount
    {
        public decimal? Value { get; set; }

        public string Currency { get; set; }
    }
}
