using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditInfo.Domain.Model
{
    public class Individual
	{
		public string CustomerCode { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Gender { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string IdentificationNumbers { get; set; }
    }
}
