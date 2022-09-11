using CreditInfo.Domain.Interface;
using CreditInfo.Domain.Model;
using CreditInfo.Domain.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
              from c in StreamElements(fileName, xsdLocation, ns, "Contract", null)
              select c;

            XmlSerializer ser = new XmlSerializer(typeof(Contract), ns);

            List<Contract> contracts = new();
            List<string> invalidContractsCode = new();

            foreach (var i in streamQuery)
            {
                try
                {
                    Contract obj = (Contract)ser.Deserialize(i.CreateReader());
                    var contractValidator = new ContractValidator { RuleLevelCascadeMode = CascadeMode.Stop };
                    var result = contractValidator.Validate(obj);

                    if (obj.IsValid && result.IsValid)
                    {
                        contracts.Add(obj);
                    }
                    else
                    {
                        Console.WriteLine($"Contract code: {obj.ContractCode} have {obj.XsdErrorMessage.Count} error(s) in XSD Validation and {result.Errors.Count} errors(s) in extended validation" );

                        invalidContractsCode.Add(obj.ContractCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Uncaught validation. {ex.Message}");
                }
            }

            return Task.CompletedTask;
        }
        public IEnumerable<XElement> StreamElements(string fileName, string xsdLocation, string ns, string elementName, Stream s)
        {

            XmlSchemaSet xmlSchema = new XmlSchemaSet();
            xmlSchema.Add(ns, xsdLocation);
            var settings = new XmlReaderSettings
            {
                Schemas = xmlSchema,
                IgnoreWhitespace = false,
                ConformanceLevel = ConformanceLevel.Document,
                ValidationType = ValidationType.Schema,
                ValidationFlags = XmlSchemaValidationFlags.ProcessSchemaLocation | XmlSchemaValidationFlags.ProcessInlineSchema,
            };

            bool isContractValid = true;
            Stack<string> validationErrors = new Stack<string>();

            settings.ValidationEventHandler += (obj, ea) => {
                if (ea.Severity == XmlSeverityType.Warning)
                {
                    Console.WriteLine(ea.Message);
                }
                else
                {
                    isContractValid = false;
                    validationErrors.Push(ea.Message);
                }
            };

            using (var rdr = XmlReader.Create(fileName, settings))
            {
                while (!rdr.EOF)
                {
                    if (rdr.Name != elementName)
                    {
                        rdr.ReadToFollowing(elementName);
                    }

                    if (!rdr.EOF && rdr.IsStartElement())
                    {
                        var o = XElement.ReadFrom(rdr) as XElement;
                        var xelement = new XElement("XsdErrorMessage", from c in validationErrors
                                                                       select new XElement("Message", c));
                        // add XSD validation information to XML
                        o.SetAttributeValue("IsValid", isContractValid);
                        o.Add(xelement);

                        // reset
                        isContractValid = true;
                        validationErrors.Clear();

                        foreach (var node in o.Descendants())
                        {
                            node.Name = node.Parent.Name.Namespace + node.Name.LocalName;
                        }

                        yield return o;
                    }
                }

                rdr.Close();
            }
        }
    }
}
