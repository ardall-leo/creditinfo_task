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
	public class Individual
	{
		public int Age => DateTime.UtcNow.Year - this.DateOfBirth.Year;

		[XmlElement("CustomerCode")]
		public string CustomerCode { get; set; }

		[XmlElement("FirstName")]
		public string FirstName { get; set; }

		[XmlElement("LastName")]
		public string LastName { get; set; }

		[XmlElement("Gender")]
		public string Gender { get; set; }

		[XmlElement("DateOfBirth")]
		public DateTime DateOfBirth { get; set; }

		[XmlElement("IdentificationNumbers")]
		public IdentificationNumbers IdentificationNumbers { get; set; }
    }

	[Serializable]
	[XmlType(AnonymousType = true, Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class IdentificationNumbers
	{
		[XmlElement("NationalID")]
		public string NationalId { get; set; }
	}
}
