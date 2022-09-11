using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace CreditInfo.Domain.Model
{
    [Serializable]
    [XmlRoot(Namespace = "http://creditinfo.com/schemas/Sample/Data", ElementName = "Batch")]
    public class Batch
    {
        [XmlArray]
        public List<Contract> Contract { get; set; }
    }

    [Serializable]
    [XmlRoot(Namespace = "http://creditinfo.com/schemas/Sample/Data", ElementName = "Contract")]
    [XmlType(AnonymousType = true, Namespace = "http://creditinfo.com/schemas/Sample/Data")]
    public class Contract
    {
        [XmlAttribute]
        public bool IsValid { get; set; }

        [XmlElement("ContractCode")]
        public string ContractCode { get; set; }

        [XmlElement("ContractData")]
        public ContractData ContractData { get; set; }

        [XmlElement("Individual")]
        public List<Individual> Individual { get; set; }

        [XmlElement("SubjectRole")]
        public List<SubjectRole> SubjectRole { get; set; }

        [XmlArray("XsdErrorMessage")]
        [XmlArrayItem("Message", Type = typeof(string))]
        public List<string> XsdErrorMessage { get; set; }
    }
}
