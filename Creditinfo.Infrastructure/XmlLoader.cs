using CreditInfo.Domain.Interface;
using CreditInfo.Domain.Model;
using CreditInfo.Domain.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Creditinfo.Infrastructure
{
    public class XmlLoader : IDataLoader
    {

        public Task Load(string fileName, string xsdLocation, string ns)
        {

            var streamQuery =
              from c in StreamElements(fileName, xsdLocation, ns, "Contract")
              select c;

            XmlSerializer ser = new XmlSerializer(typeof(Contract));

            List<Contract> contracts = new();
            List<string> invalidContractsCode = new();

            foreach (var i in streamQuery)
            {
                try
                {
                    var contract = (Contract)ser.Deserialize(i.CreateReader());
                    var contractValidator = new ContractValidator { RuleLevelCascadeMode = CascadeMode.Stop };
                    var result = contractValidator.Validate(contract);

                    if (result.IsValid)
                    {
                        contracts.Add(contract);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return Task.CompletedTask;
        }

        private IEnumerable<XElement> StreamElements(string fileName, string xsdLocation, string ns, string elementName)
        {

            XmlSchemaSet xmlSchema = new XmlSchemaSet();
            xmlSchema.Add(ns, xsdLocation);
            var settings = new XmlReaderSettings
            {
                Schemas = xmlSchema,
                ConformanceLevel = ConformanceLevel.Document,
                ValidationType = ValidationType.Schema,
                ValidationFlags = XmlSchemaValidationFlags.ProcessSchemaLocation |
                     XmlSchemaValidationFlags.ProcessInlineSchema,
            };

            settings.ValidationEventHandler += (obj, ea) => {
                if (ea.Severity == XmlSeverityType.Warning)
                {
                    Console.WriteLine(ea.Message);
                }
                else
                {
                    Console.WriteLine(ea.Message);
                }
            };

            using (var rdr = XmlReader.Create(fileName, settings))
            {
                rdr.MoveToContent();
                while (rdr.Read())
                {
                    if ((rdr.NodeType == XmlNodeType.Element) && (rdr.Name == elementName))
                    {
                        var e = XElement.ReadFrom(rdr) as XElement;

                        yield return e;
                    }
                }
                rdr.Close();
            }
        }
    }
}
