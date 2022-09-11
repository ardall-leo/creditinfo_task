using CreditInfo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CreditInfo.Domain.Model
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://creditinfo.com/schemas/Sample/Data")]
    public class Amount
    {
        [XmlElement("Value")]
        public decimal? Value { get; set; }

        [XmlElement("Currency")]
        public CurrencyCode Currency { get; set; }
    }
}
