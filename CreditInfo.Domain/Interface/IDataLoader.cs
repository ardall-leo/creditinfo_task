using CreditInfo.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreditInfo.Domain.Interface
{
    public interface IDataLoader
    {
        /// <summary>
        /// This is the entry point for handling single xml file input and validate against the XSD file and do extra bussiness validation
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="xsdLocation"></param>
        /// <param name="ns"></param>
        /// <returns></returns>
        public Task Load(string fileName, string xsdLocation, string ns);

        /// <summary>
        /// Process XML stream and validate aganst the XSD file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="xsdLocation"></param>
        /// <param name="ns"></param>
        /// <param name="elementName"></param>
        /// <returns></returns>
        IEnumerable<XElement> StreamElements(string fileName, string xsdLocation, string ns, string elementName, Stream s);
    }
}
