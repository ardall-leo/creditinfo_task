using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditInfo.Domain.Interface
{
    public interface IDataLoader
    {
        public Task Load(string fileName, string xsdLocation, string ns);
    }
}
