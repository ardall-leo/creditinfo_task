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
            var x = new XmlLoader();
            x.Load("data.xml", "structure.xsd", "http://creditinfo.com/schemas/Sample/Data");
        }
    }
}
