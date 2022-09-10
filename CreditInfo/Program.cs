using Creditinfo.Infrastructure;
using CreditInfo.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CreditInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            XNamespace aw = "http://creditinfo.com/schemas/Sample/Data";
            var x = new XmlLoader();
            x.Load(@"C:\creditinfo\data.xml", @"C:\creditinfo\structure.xsd", "http://creditinfo.com/schemas/Sample/Data");
        }

        
    }
}
