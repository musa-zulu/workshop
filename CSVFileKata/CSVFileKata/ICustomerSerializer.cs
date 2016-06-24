using System.Collections.Generic;
using System.Net;

namespace CSVFileKata
{
    public interface ICustomerSerializer
    {
        void Serialize(List<Customer> customers, string fileName);
    }
}