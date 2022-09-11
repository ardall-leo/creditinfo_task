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
    [XmlType(AnonymousType =true, Namespace = "http://creditinfo.com/schemas/Sample/Data")]
    public class SubjectRole
    {
        [XmlElement("CustomerCode")]
        public string CustomerCode { get; set; }

        [XmlElement("RoleOfCustomer")]
        public RoleOfCustomer RoleOfCustomer { get; set; }

        [XmlElement("GuaranteeAmount")]
        public Amount GuaranteeAmount { get; set; }
    }
}
