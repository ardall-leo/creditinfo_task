using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CreditInfo.Domain.Model
{
    [XmlRoot(Namespace = "http://creditinfo.com/schemas/Sample/Data", ElementName = "Batch")]
    public class Batch
    {
        [XmlElement]
        public List<Contract> Contract { get; set; }
    }
    [XmlRoot(Namespace = "http://creditinfo.com/schemas/Sample/Data", ElementName = "Contract")]
    public class Contract
    {
        [XmlElement]
        public string ContractCode { get; set; }
        [XmlElement]
        public ContractData ContractData { get; set; }
        [XmlElement]
        public Individual Individual { get; set; }
        [XmlElement]
        public SubjectRole SubjectRole { get; set; }

    }
}
